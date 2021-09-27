using System;
using System.Threading.Tasks;
using System.Timers;
using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation
{
    public class Simulation
    {
        private Galaxy _galaxy;
        private int _speed = 100;
        private DateTime _lastTick = DateTime.UtcNow;
        private readonly Timer _timer;

        public Simulation()
        {
            _timer = new Timer
            {
                Interval = 50,
                Enabled = false
            };
            _timer.Elapsed += Tick;
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

        public void Resume()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Tick(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var currentTime = DateTime.UtcNow;
            var deltaTime = (currentTime - _lastTick).TotalMilliseconds * _speed;
            
            Update();
            _lastTick = DateTime.UtcNow;
        }

        private void Update()
        {
            
        }
    }
}
