using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        public const int Width = 800;

        public const int Height = 600;

        Galaxy Galaxy { get; set; }

        void Resume();

        void Pause();
    }
}
