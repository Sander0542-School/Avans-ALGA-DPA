using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding
{
    public abstract class PathFinder
    {
        public abstract List<Planet> Find(Planet start, Planet end);

        public List<Planet> Get(ISimulator simulator)
        {
            var stepPlanets = simulator.Galaxy.CelestialBodies.OfType<Planet>().OrderByDescending(planet => planet.Radius).ToList();
            return stepPlanets.Count < 2 ? null : Find(stepPlanets[0], stepPlanets[1]);
        }
    }
}