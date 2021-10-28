using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Path.Data;

namespace Avans.FlatGalaxy.Simulation.Path
{
    public class DijkstraPathAlgorithm : IPathAlgorithm
    {
        public List<Planet> Find(Planet start, Planet end, List<Planet> planets)
        {
            var graph = new DijkstraGraph(planets);
            var startNode = graph.Nodes.First(node => node.Planet == start);
            startNode.Weight = new(null, 0);
            var unvisited = new List<DijkstraNode> { startNode };

            while (unvisited.Any())
            {
                var node = unvisited.OrderBy(node1 => node1.Weight.Value).First();

                foreach (var neighbour in node.Neighbours)
                {
                    if (neighbour.Weight + node.Weight.Value < neighbour.Node.Weight.Value)
                    {
                        neighbour.Node.Weight = new(node.Planet, neighbour.Weight + node.Weight.Value);

                        if (!unvisited.Contains(neighbour.Node) && !neighbour.Node.Visited)
                        {
                            unvisited.Add(neighbour.Node);
                        }
                    }
                }
                node.Visited = true;
                unvisited.Remove(node);
            }

            var endNode = graph.Nodes.First(node => node.Planet == end);
            var path = new List<DijkstraNode> { endNode };
            while (endNode.Weight.Key != null)
            {
                endNode = endNode.Neighbours.OrderBy(edge => edge.Node.Weight.Value).FirstOrDefault()?.Node;
                if (endNode == null) return null;
                path.Add(endNode);
            }

            return path.Select(node => node.Planet).ToList();
        }
    }
}
