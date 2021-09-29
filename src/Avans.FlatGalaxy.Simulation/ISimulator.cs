using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation
{
    public interface ISimulator
    {
        Galaxy Galaxy { get; set; }

        void Resume();

        void Pause();
    }
}
