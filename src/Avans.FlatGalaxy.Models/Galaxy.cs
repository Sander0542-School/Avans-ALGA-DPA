using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Models
{
    public class Galaxy
    {
        public List<CelestialBody> CelestialBodies { get; set; } = new();
        
        public List<Fold> Folds { get; set; } = new();
    }
}