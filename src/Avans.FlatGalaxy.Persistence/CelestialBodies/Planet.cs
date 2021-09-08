using System.Drawing;
using Avans.FlatGalaxy.Persistence.CelestialBodies.States;

namespace Avans.FlatGalaxy.Persistence.CelestialBodies
{
    public class Planet : CelestialBody
    {
        public Planet(string name, int x, int y, int vx, int vy, int radius, Color color, ICollisionState collisionState) : base(name, x, y, vx, vy, radius, color, collisionState)
        {
        }
    }
}