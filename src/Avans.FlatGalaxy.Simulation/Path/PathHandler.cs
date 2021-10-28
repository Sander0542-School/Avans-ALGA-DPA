using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Common;

namespace Avans.FlatGalaxy.Simulation.Path
{
    public class PathHandler : ImplementationSwapper<IPathAlgorithm>
    {
        public PathHandler()
        {
            Add(new DijkstraPathAlgorithm());
            Add(new BreadthFirstPathAlgorithm());
        }

        public List<Planet> Find(Galaxy galaxy)
        {
            var planets = galaxy.CelestialBodies.OfType<Planet>().OrderByDescending(planet => planet.Radius).ToList();
            return planets.Count < 2 ? null : Find(planets[0], planets[1], galaxy);
        }

        public List<Planet> Find(Planet start, Planet end, Galaxy galaxy)
        {
            return Find(start, end, galaxy.CelestialBodies.OfType<Planet>().ToList());
        }

        public List<Planet> Find(Planet start, Planet end, List<Planet> planets)
        {
            return planets.Contains(start) && planets.Contains(end) ? Current.Find(start, end, planets) : null;
        }
    }
}
