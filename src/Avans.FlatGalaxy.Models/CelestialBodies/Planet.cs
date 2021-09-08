using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class Planet : CelestialBody
    {
        public Planet(int x, int y, int vx, int vy, int radius, Color color, ICollisionState collisionState) : base(x, y, vx, vy, radius, color, collisionState)
        {
        }
    }
}