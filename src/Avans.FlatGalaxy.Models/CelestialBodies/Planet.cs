using System.Collections.Generic;
using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class Planet : CelestialBody
    {
        public string Name { get; private set; }

        public List<Planet> Neighbours { get; set; } = new();

        public Planet(string name, double x, double y, double vx, double vy, int radius, Color color, ICollisionState collisionState) : base(x, y, vx, vy, radius, color, collisionState)
        {
            Name = name;
        }

        public override CelestialBody Clone()
        {
            return new Planet(Name, X, Y, VX, VY, Radius, Color, CollisionState.Clone());
        }
    }
}
