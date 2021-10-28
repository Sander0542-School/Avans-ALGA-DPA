using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class PathSwitchCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.SwitchPathAlgo();
        }
    }
}
