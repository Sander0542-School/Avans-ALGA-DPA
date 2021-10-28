using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class SpeedDownCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.SpeedDown(ISimulator.SpeedDiff);
        }
    }
}
