using Avans.FlatGalaxy.Simulation.Collision;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation.Extensions
{
    public static class QuadTreeExtensions
    {
        public static void Collisions(this QuadTree quadTree, CollisionHandler collisionHandler)
        {
            if (quadTree.Elements != null)
            {
                foreach (var element1 in quadTree.Elements)
                {
                    foreach (var element2 in quadTree.Elements)
                    {
                        if (element1 != element2 && element1.IsColliding(element2))
                            collisionHandler.AddCollision(element1, element2);
                    }
                }
            }
            else
            {
                quadTree.NorthEast.Collisions(collisionHandler);
                quadTree.NorthWest.Collisions(collisionHandler);
                quadTree.SouthEast.Collisions(collisionHandler);
                quadTree.SouthWest.Collisions(collisionHandler);
            }
        }
    }
}
