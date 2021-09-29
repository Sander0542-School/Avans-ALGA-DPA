using System.Collections.Generic;
using System.Drawing;
using Avans.FlatGalaxy.Models.CelestialBodies.States;

namespace Avans.FlatGalaxy.Models.CelestialBodies
{
    public class Planet : CelestialBody
    {
        public string Name { get; private set; }
        
        public List<Planet> Neighbours { get; set; }

        public Planet(string name, int x, int y, double vx, double vy, int radius, Color color, ICollisionState collisionState) : base(x, y, vx, vy, radius, color, collisionState)
        {
            Name = name;
        }
    }
}
