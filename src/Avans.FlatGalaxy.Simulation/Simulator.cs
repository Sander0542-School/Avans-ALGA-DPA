using System;
using System.Threading;
using System.Threading.Tasks;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Bookmark;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;
using Avans.FlatGalaxy.Simulation.Collision;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation
{
    public class Simulator : ISimulator
    {
        private const float Second = 1000;
        private const float TpsTarget = 20;
        private const float TpsTime = Second / TpsTarget;

        private Galaxy _galaxy;
        private DateTime _lastTick = DateTime.UtcNow;

        private int _speed = 50;
        private bool _running = false;
        private DateTime _lastBookmark;

        private CancellationTokenSource _source;
        private CancellationToken _token;
        private readonly CollisionHandler _collisionHandler;
        private readonly GalaxyOriginator _originator;
        private readonly Caretaker<Galaxy> _caretaker;

        public Simulator(Galaxy galaxy)
        {
            _galaxy = galaxy;
            _collisionHandler = new CollisionHandler();
            _originator = new GalaxyOriginator(_galaxy);
            _caretaker = new Caretaker<Galaxy>(_originator);
        }

        public Galaxy Galaxy => _galaxy;

        public QuadTree QuadTree { get; set; }

        public void Resume()
        {
            if (_running) return;

            _running = true;
            _source = new CancellationTokenSource();
            _token = _source.Token;
            _lastTick = DateTime.UtcNow;
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
            _galaxy = _originator.State;
        }

        public void Tick(CancellationToken token)
        {
            if (_running)
            {
                Task.Run(async () => {
                    var currentTime = DateTime.UtcNow;
                    var tickTime = (currentTime - _lastTick).TotalMilliseconds;
                    var deltaTime = tickTime * _speed / 1000;

                    Update(deltaTime);

                    _collisionHandler.Detect(this);

                    _lastTick = DateTime.UtcNow;
                    if ((DateTime.UtcNow - _lastBookmark).TotalSeconds >= 1)
                    {
                        _caretaker.Backup();
                        _lastBookmark = DateTime.UtcNow;
                    }

                    var nextTick = (int)(TpsTime - tickTime);
                    await Task.Delay(nextTick >= 0 ? nextTick : 0, token);
                    Tick(token);
                }, token);
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
    }
}
