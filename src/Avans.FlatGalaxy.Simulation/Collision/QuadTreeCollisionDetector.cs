using Avans.FlatGalaxy.Simulation.Data;
using Avans.FlatGalaxy.Simulation.Extensions;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class QuadTreeCollisionDetector : CollisionDetector
    {
        protected override void Collide(ISimulator simulator)
        {
            var quadTree = new QuadTree(new Bounds(0, 0, ISimulator.Height, ISimulator.Width));

            foreach (var celestialBody in simulator.Galaxy.CelestialBodies)
            {
                quadTree.Insert(celestialBody);
            }

            quadTree.Collisions(this);

            simulator.QuadTree = quadTree;
        }
    }
}
