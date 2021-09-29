using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        int Width { get; }

        int Height { get; }

        Galaxy Galaxy { get; set; }

        void Resume();

        void Pause();
    }
}
