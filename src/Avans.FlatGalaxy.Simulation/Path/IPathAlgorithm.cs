using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.Path
{
    public interface IPathAlgorithm
    {
        public abstract List<Planet> Find(Planet start, Planet end, List<Planet> planets);
    }
}
