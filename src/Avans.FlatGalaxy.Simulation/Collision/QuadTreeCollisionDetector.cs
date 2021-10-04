using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Data;
using Avans.FlatGalaxy.Simulation.Extensions;

namespace Avans.FlatGalaxy.Simulation.Collision
{
    public class QuadTreeCollisionDetector : CollisionDetector
    {
        protected override void Collide(Galaxy galaxy)
        {
            var quadTree = new QuadTree(new Bounds(0, 0, ISimulator.Height, ISimulator.Width));

            foreach (var celestialBody in galaxy.CelestialBodies)
            {
                quadTree.Insert(celestialBody);
            }

            quadTree.Collisions(this);
        }
    }
}
