using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Data;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        public const int Width = 800;

        public const int Height = 600;

        Galaxy Galaxy { get; }

        QuadTree QuadTree { get; set; }

        void Resume();

        void Pause();
    }
}
