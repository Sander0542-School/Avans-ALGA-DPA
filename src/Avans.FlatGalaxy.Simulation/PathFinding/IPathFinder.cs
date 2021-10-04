using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public interface IPathFinder
    {
        List<Planet> Calculate(Planet start, Planet end);
    }
}