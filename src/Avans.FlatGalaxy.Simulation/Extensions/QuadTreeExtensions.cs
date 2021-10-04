using System;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Collision;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation.Extensions
{
    public static class QuadTreeExtensions
    {
        public static void Collisions(this QuadTree quadTree, CollisionDetector collisionDetector)
        {
            if (quadTree.Elements != null)
            {
                foreach (var element1 in quadTree.Elements)
                {
                    foreach (var element2 in quadTree.Elements)
                    {
                        if (element1 != element2 && element1.IsColliding(element2))
                            collisionDetector.AddCollision(element1, element2);
                    }
                }
            }
            else
            {
                quadTree.NorthEast.Collisions(collisionDetector);
                quadTree.NorthWest.Collisions(collisionDetector);
                quadTree.SouthEast.Collisions(collisionDetector);
                quadTree.SouthWest.Collisions(collisionDetector);
            }
        }
    }
}
