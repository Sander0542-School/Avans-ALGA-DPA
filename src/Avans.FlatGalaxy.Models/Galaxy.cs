using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public Galaxy(IEnumerable<CelestialBody> celestialBodies) : this()
        {
            foreach (var body in celestialBodies)
            {
                Add(body);
            }
        }

        public void Add(CelestialBody celestialBody)
        {
            if (_celestialBodies.ContainsKey(celestialBody))
            {
                _celestialBodies[celestialBody]?.Dispose();
            }
            _celestialBodies[celestialBody] = celestialBody.Subscribe(this);
        }

        public void Remove(CelestialBody celestialBody)
        {
            if (!_celestialBodies.ContainsKey(celestialBody)) return;

            _celestialBodies[celestialBody]?.Dispose();
            _celestialBodies.Remove(celestialBody);
        }

        public void MapNeighbours(IDictionary<Planet, string[]> planetNeighbours)
        {
            foreach (var (planet, neighbours) in planetNeighbours)
            {
                foreach (var neighbour in neighbours)
                {
                    planet.Neighbours.Add(CelestialBodies.OfType<Planet>().First(b => b.Name == neighbour));
                }
            }
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(CelestialBody celestialBody)
        {
            switch (celestialBody.CollisionState.GetType().Name)
            {
                case "BounceState":
                    celestialBody.CollisionState = new BlinkState();
                    break;
                case "DisappearState":
                    Remove(celestialBody);
                    break;
                case "ExplodeState":
                    ExplodeStateEvent(celestialBody);
                    break;
                case "GrowState":
                    celestialBody.CollisionState = new ExplodeState();
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
