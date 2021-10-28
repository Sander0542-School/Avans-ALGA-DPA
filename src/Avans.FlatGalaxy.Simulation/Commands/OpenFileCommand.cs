using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class OpenFileCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.OpenFile();
        }
    }
}
