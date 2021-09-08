using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class NamedCelestialBody : CelestialBody
    {
        public string Name { get; set; }

        public NamedCelestialBody(string name, int x, int y, double vx, double vy, int radius, Color color, ICollisionState collisionState) : base(x, y, vx, vy, radius, color, collisionState)
        {
        }
    }
}