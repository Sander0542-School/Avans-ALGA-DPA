using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class CollisionHandler
    {
        private readonly List<ICollisionDetector> _detectors;
        private readonly List<KeyValuePair<CelestialBody, CelestialBody>> _collisions;

        private int _currentDetector;

        public CollisionHandler()
        {
            _detectors = new List<ICollisionDetector>
            {
                new QuadTreeCollisionDetector(),
                new NaiveCollisionDetector()
            };
            _collisions = new List<KeyValuePair<CelestialBody, CelestialBody>>();
        }

        public void Toggle()
        {
            if (++_currentDetector >= _detectors.Count)
            {
                _currentDetector = 0;
            }
        }

        public void Detect(ISimulator simulator)
        {
            _detectors[_currentDetector].Detect(simulator, this);

            TriggerEnd();
        }

        public void AddCollision(CelestialBody body1, CelestialBody body2)
        {
            if (body1 == body2) return;

            var pair = body1.GetHashCode() < body2.GetHashCode() ? new KeyValuePair<CelestialBody, CelestialBody>(body1, body2) : new KeyValuePair<CelestialBody, CelestialBody>(body2, body1);

            if (!_collisions.Contains(pair))
            {
                _collisions.Add(pair);
                body1.Collide(body2);
                body2.Collide(body1);
            }
        }

        private void TriggerEnd()
        {
            _collisions.RemoveAll(pair => !pair.Key.IsColliding(pair.Value));
        }
    }
}
