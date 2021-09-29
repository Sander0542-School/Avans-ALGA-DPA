using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Models
{
    public class Galaxy
    {
        public List<CelestialBody> CelestialBodies { get; set; } = new();
    }
}