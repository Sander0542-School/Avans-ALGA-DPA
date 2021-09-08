using System.Collections.Generic;
using Avans.FlatGalaxy.Persistence.CelestialBodies;

namespace Avans.FlatGalaxy.Persistence
{
    public class Galaxy
    {
        public List<CelestialBody> CelestialBodies { get; set; } = new();
    }
}