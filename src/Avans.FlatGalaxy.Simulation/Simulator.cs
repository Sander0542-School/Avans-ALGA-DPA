using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Collision;
using Avans.FlatGalaxy.Simulation.Data;
using Avans.FlatGalaxy.Models.CelestialBodies.States;
using Avans.FlatGalaxy.Simulation.Bookmark;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;
using Avans.FlatGalaxy.Simulation.Extensions;
using Avans.FlatGalaxy.Models.Common;
using Avans.FlatGalaxy.Simulation.Path;

namespace Avans.FlatGalaxy.Simulation
{
    public class Simulator : ISimulator
    {
        private List<IObserver<ISimulator>> _observers;
        
        private const float Second = 1000;
        private const float TpsTarget = 20;
        private const float TpsTime = Second / TpsTarget;

        private DateTime _lastTick = DateTime.UtcNow;

        private double _speed = 25;
        private bool _running = false;
        private DateTime _lastBookmark;

        private CancellationTokenSource _source;
        private CancellationToken _token;
        private readonly CollisionHandler _collisionHandler;
        private readonly PathHandler _pathHandler;
        private readonly ICaretaker _caretaker;

        public Simulator(Galaxy galaxy)
        {
            Galaxy = galaxy;
            _collisionHandler = new();
            _pathHandler = new();
            _caretaker = new SimulatorCaretaker(this);
        }

        public Galaxy Galaxy { get; set; }

        public QuadTree QuadTree { get; set; }

        public List<Planet> PathSteps { get; set; }

        public bool CollisionVisible { get; set; } = false;

        public void Resume()
        {
            if (_running) return;
            _running = true;

            _source = new();
            _token = _source.Token;

            _lastTick = DateTime.UtcNow;

            _caretaker.Save();
            _lastBookmark = DateTime.UtcNow;

            Tick(_token);
        }

        public void Pause()
        {
            _source?.Cancel();
            _running = false;
        }

        public void Restore()
        {
            _caretaker.Undo();
        }

        public void SpeedUp(double speed)
        {
            _speed += speed;
        }

        public void SpeedDown(double speed)
        {
            _speed -= speed;
        }

        public void SwitchCollisionAlgo()
        {
            _collisionHandler.Next();
        }

        public void SwitchPathAlgo()
        {
            _pathHandler.Next();
        }

        public void ToggleCollisionVisibility()
        {
            CollisionVisible = !CollisionVisible;
        }

        public void OpenFile()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();
        }

        public void AddAsteroid()
        {
            var rnd = new Random();
            var x = rnd.NextDouble() * ISimulator.Width;
            var y = rnd.NextDouble() * ISimulator.Height;
            var vx = rnd.NextDouble() * 10 - 5;
            var vy = rnd.NextDouble() * 10 - 5;

            Galaxy.Add(new Asteroid(x, y, vx, vy, 5, Color.Black, new NullCollisionState()));
        }

        public void RemoveAsteroid()
        {
            var asteroids = Galaxy.CelestialBodies.OfType<Asteroid>().ToList();
            if (asteroids.Any()) Galaxy.Remove(asteroids.Random());
        }

        private void Tick(CancellationToken token)
        {
            if (_running)
            {
                try
                {
                    Task.Run(async () => {
                        var currentTime = DateTime.UtcNow;
                        var tickTime = (currentTime - _lastTick).TotalMilliseconds;
                        var deltaTime = tickTime * _speed / 1000;

                        Update(deltaTime);

                        _collisionHandler.Detect(this);
                        PathSteps = _pathHandler.Find(Galaxy);

                        _lastTick = DateTime.UtcNow;
                        if ((DateTime.UtcNow - _lastBookmark).TotalMilliseconds >= ISimulator.BookmarkTime)
                        {
                            _caretaker.Save();
                            _lastBookmark = DateTime.UtcNow;
                        }

                        var nextTick = (int)(TpsTime - tickTime);
                        await Task.Delay(nextTick >= 0 ? nextTick : 0, token);
                        Tick(token);
                    }, token);
                }
                catch (TaskCanceledException)
                {
                }
            }
        }

        private void Update(double deltaTime)
        {
            foreach (var celestialBody in Galaxy.CelestialBodies)
            {
                var nextX = celestialBody.X + celestialBody.VX * deltaTime;
                var nextY = celestialBody.Y + celestialBody.VY * deltaTime;

                var maxX = ISimulator.Width - celestialBody.Radius * 2;
                var maxY = ISimulator.Height - celestialBody.Radius * 2;

                if (nextX < 0)
                {
                    nextX -= nextX * 2;
                    celestialBody.VX = -celestialBody.VX;
                }

                if (nextY < 0)
                {
                    nextY -= nextY * 2;
                    celestialBody.VY = -celestialBody.VY;
                }

                if (nextX > maxX)
                {
                    nextX -= (nextX - maxX) * 2;
                    celestialBody.VX = -celestialBody.VX;
                }

                if (nextY > maxY)
                {
                    nextY -= (nextY - maxY) * 2;
                    celestialBody.VY = -celestialBody.VY;
                }

                celestialBody.X = nextX;
                celestialBody.Y = nextY;
            }
        }

        public IDisposable Subscribe(IObserver<ISimulator> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber<ISimulator>(_observers, observer);
        }
    }
}
