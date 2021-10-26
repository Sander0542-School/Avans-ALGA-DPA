using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Collision;
using Avans.FlatGalaxy.Simulation.Data;
using Avans.FlatGalaxy.Simulation.PathFinding;

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

        private CancellationTokenSource _source;
        private CancellationToken _token;
        private CollisionDetector _collisionDetector;

        public Simulator()
        {
            _collisionDetector = new QuadTreeCollisionDetector();
        }

        public Galaxy Galaxy
        {
            get => _galaxy;
            set
            {
                Pause();
                _galaxy = value;
            }
        }

        public QuadTree QuadTree { get; set; }
        public List<Planet> PathSteps { get; set; }

        public void Resume()
        {
            if (_running) return;

            _running = true;
            _source = new CancellationTokenSource();
            _token = _source.Token;
            _lastTick = DateTime.UtcNow;
            Tick(_token);
        }

        public void Pause()
        {
            _source?.Cancel();
            _running = false;
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

                    _collisionDetector.Detect(this);
                    
                    PathSteps = new BreadthFirstPathFinder().Get(this);
                    // PathSteps = new CheapestPathFinder().Get(this);

                    _lastTick = DateTime.UtcNow;

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
