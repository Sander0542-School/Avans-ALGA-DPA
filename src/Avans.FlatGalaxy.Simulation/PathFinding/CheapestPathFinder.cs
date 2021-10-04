using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public class CheapestPathFinder : PathFinder
    {
        public override List<Planet> Find(Planet start, Planet end)
        {
            return new();
        }
    }
}