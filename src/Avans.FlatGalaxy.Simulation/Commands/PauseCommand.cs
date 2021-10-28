using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class PauseCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.Pause();
        }
    }
}
