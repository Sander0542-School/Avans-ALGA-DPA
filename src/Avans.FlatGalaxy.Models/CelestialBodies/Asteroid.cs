using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class Asteroid : CelestialBody
    {
        public Asteroid(double x, double y, double vx, double vy, int radius, Color color, ICollisionState collisionState) : base(x, y, vx, vy, radius, color, collisionState)
        {
        }

        public override CelestialBody Clone()
        {
            return new Asteroid(X, Y, VX, VY, Radius, Color, CollisionState.Clone());
        }
    }
}
