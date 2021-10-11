using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public abstract class CollisionDetector
    {
        private readonly List<KeyValuePair<CelestialBody, CelestialBody>> _collisions;

        protected CollisionDetector()
        {
            _collisions = new List<KeyValuePair<CelestialBody, CelestialBody>>();
        }

        protected abstract void Collide(ISimulator simulator);

        public void Detect(ISimulator simulator)
        {
            Collide(simulator);

            TriggerEnd();
        }

        public void AddCollision(CelestialBody body1, CelestialBody body2)
        {
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
