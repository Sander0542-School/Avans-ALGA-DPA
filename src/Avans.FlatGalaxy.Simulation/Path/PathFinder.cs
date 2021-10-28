using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.Path
{
    public abstract class PathFinder
    {
        protected abstract List<Planet> Find(Planet start, Planet end, List<Planet> planets);

        public List<Planet> Get(ISimulator simulator)
        {
            var planets = simulator.Galaxy.CelestialBodies.OfType<Planet>().ToList();
            var planets2 = planets.OrderByDescending(planet => planet.Radius).ToList();
            return planets2.Count < 2 ? null : Find(planets2[0], planets2[1], planets);
        }
    }
}