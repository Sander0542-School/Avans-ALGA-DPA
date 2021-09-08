using System.Drawing;
using Avans.FlatGalaxy.Persistence.CelestialBodies.States;

namespace Avans.FlatGalaxy.Persistence.CelestialBodies
{
    public abstract class CelestialBody
    {
        public string Name { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public double VX { get; set; }

        public double VY { get; set; }

        public int Radius { get; set; }

        public Color Color { get; set; }

        public ICollisionState CollisionState { get; set; }

        public CelestialBody(string name, int x, int y, int vx, int vy, int radius, Color color, ICollisionState collisionState)
        {
            Name = name;
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
            Radius = radius;
            Color = color;
            CollisionState = collisionState;
        }
    }
}