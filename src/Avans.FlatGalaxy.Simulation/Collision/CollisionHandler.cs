using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Common;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class CollisionHandler : ImplementationSwapper<ICollisionDetector>
    {
        private readonly List<KeyValuePair<CelestialBody, CelestialBody>> _collisions;

        public CollisionHandler()
        {
            Add(new QuadTreeCollisionDetector());
            Add(new NaiveCollisionDetector());
            _collisions = new();
        }

        public void Detect(ISimulator simulator)
        {
            Current.Detect(simulator, this);

            TriggerEnd();
        }

        public void AddCollision(CelestialBody body1, CelestialBody body2)
        {
            if (body1 == body2) return;

            KeyValuePair<CelestialBody, CelestialBody> pair = body1.GetHashCode() < body2.GetHashCode() ? new(body1, body2) : new(body2, body1);

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
