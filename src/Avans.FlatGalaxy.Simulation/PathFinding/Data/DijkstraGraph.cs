using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Simulation.PathFinding.Data
{
    public class DijkstraGraph
    {
        public List<DijkstraNode> Nodes { get; }

        public DijkstraGraph(List<Planet> planets)
        {
            Nodes = planets.Select(planet => new DijkstraNode(planet)).ToList();

            foreach (var node in Nodes)
            {
                foreach (var neighbour in node.Planet.Neighbours)
                {
                    var neighbourNode = Nodes.First(node1 => node1.Planet == neighbour);

                    node.Neighbours.Add(new(neighbourNode, node.Planet.DistanceTo(neighbour)));
                }
            }
        }
    }
}
