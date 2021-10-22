using System.Linq;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class NaiveCollisionDetector : ICollisionDetector
    {
        public void Detect(ISimulator simulator, CollisionHandler handler)
        {
            var celestialBodies = simulator.Galaxy.CelestialBodies.ToList();
            
            foreach (var celestialBody in celestialBodies)
            {
                foreach (var celestialBody1 in celestialBodies)
                {
                    if (celestialBody.IsColliding(celestialBody1) && celestialBody != celestialBody1)
                    {
                        handler.AddCollision(celestialBody, celestialBody1);
                    }
                }
            }
            
            simulator.QuadTree = null;
        }
    }
}
