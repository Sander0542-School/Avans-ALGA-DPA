using Avans.FlatGalaxy.Simulation.Data;
using Avans.FlatGalaxy.Simulation.Extensions;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class QuadTreeCollisionDetector : ICollisionDetector
    {
        public void Detect(ISimulator simulator, CollisionHandler handler)
        {
            var quadTree = new QuadTree(new(0, ISimulator.Width, ISimulator.Height, 0));

            foreach (var celestialBody in simulator.Galaxy.CelestialBodies)
            {
                quadTree.Insert(celestialBody);
            }

            quadTree.Collisions(handler);

            simulator.QuadTree = quadTree;
        }
    }
}
