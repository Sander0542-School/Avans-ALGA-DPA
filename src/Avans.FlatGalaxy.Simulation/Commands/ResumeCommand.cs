using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class ResumeCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.Resume();
        }
    }
}
