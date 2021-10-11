using System;
using System.Collections.Generic;
using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models
{
    public class Galaxy : IObserver<CelestialBody>
    {
        private readonly IDictionary<CelestialBody, IDisposable> _celestialBodies;

        public IEnumerable<CelestialBody> CelestialBodies => _celestialBodies.Keys;

        public Galaxy()
        {
            _celestialBodies = new Dictionary<CelestialBody, IDisposable>();
        }

        public void Add(CelestialBody celestialBody)
        {
            _celestialBodies.Add(celestialBody, celestialBody.Subscribe(this));
        }

        public void Remove(CelestialBody celestialBody)
        {
            if (!_celestialBodies.ContainsKey(celestialBody)) return;

            _celestialBodies[celestialBody]?.Dispose();
            _celestialBodies.Remove(celestialBody);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(CelestialBody celestialBody)
        {
            switch (celestialBody.CollisionState.GetType().Name)
            {
                case "DisappearState":
                    Remove(celestialBody);
                    break;
                case "ExplodeState":
                    ExplodeStateEvent(celestialBody);
                    break;
            }
        }

        private void ExplodeStateEvent(CelestialBody celestialBody)
        {
            Remove(celestialBody);

            for (var i = 0; i < 5; i++)
            {
                Add(new Asteroid(celestialBody.X, celestialBody.Y, RandomSpeed(), RandomSpeed(), 5, Color.Black, new BounceState()));
            }
        }

        private double RandomSpeed()
        {
            return new Random().NextDouble() * 10 - 5;
        }
    }
}
