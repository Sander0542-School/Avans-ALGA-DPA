using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation.Extensions
{
    public static class BoundsExtensions
    {
        public static bool Inside(this Bounds bounds, CelestialBody celestialBody)
        {
            return bounds.Inside(celestialBody.X, celestialBody.Y, celestialBody.X + celestialBody.Diameter, celestialBody.Y + celestialBody.Diameter);
        }
    }
}
