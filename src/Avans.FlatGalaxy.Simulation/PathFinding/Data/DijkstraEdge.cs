namespace Avans.FlatGalaxy.Simulation.PathFinding.Data
{
    public class DijkstraEdge
    {
        public DijkstraNode Node { get; set; }

        public double Weight { get; set; }

        public DijkstraEdge(DijkstraNode node, double weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
