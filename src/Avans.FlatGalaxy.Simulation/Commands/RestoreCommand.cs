using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class RestoreCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.Restore();
        }
    }
}
