using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Persistence
{
    public class Galaxy
    {
        public List<CelestialBody> CelestialBodies { get; set; } = new();
    }
}