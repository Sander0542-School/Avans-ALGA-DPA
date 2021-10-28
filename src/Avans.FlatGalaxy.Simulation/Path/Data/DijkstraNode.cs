using System.Collections.Generic;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.Path.Data
{
    public class DijkstraNode
    {
        public Planet Planet { get; }

        public KeyValuePair<Planet, double> Weight { get; set; }

        public List<DijkstraEdge> Neighbours { get; }

        public bool Visited { get; set; }

        public DijkstraNode(Planet planet)
        {
            Neighbours = new();
            Weight = new(null, double.PositiveInfinity);
            Planet = planet;
        }
    }
}
