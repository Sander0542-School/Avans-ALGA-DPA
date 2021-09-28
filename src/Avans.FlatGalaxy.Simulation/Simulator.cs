using System;
using System.Threading;
using System.Threading.Tasks;
using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation
{
    public class Simulator : ISimulator
    {
        private const float Second = 1000;
        private const float TpsTarget = 20;
        private const float TpsTime = Second / TpsTarget;

        private Galaxy _galaxy;
        private DateTime _lastTick = DateTime.UtcNow;

        private int _speed = 100;
        private bool _running = false;

        private CancellationTokenSource _source;
        private CancellationToken _token;

        public Galaxy Galaxy
        {
            get => _galaxy;
            set
            {
                Pause();
                _galaxy = value;
            }
        }

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
                    var deltaTime = tickTime * _speed;

                    Update(deltaTime);

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
                celestialBody.X += celestialBody.VX;// / deltaTime;
                celestialBody.Y += celestialBody.VY;// / deltaTime;
            }
        }
    }
}
