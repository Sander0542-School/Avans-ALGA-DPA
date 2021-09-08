using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class Planet : NamedCelestialBody
    {
        public Planet(string name, int x, int y, double vx, double vy, int radius, Color color, ICollisionState collisionState) : base(name, x, y, vx, vy, radius, color, collisionState)
        {
        }
    }
}