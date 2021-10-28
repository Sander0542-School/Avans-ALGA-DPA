using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class SpeedUpCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.SpeedUp(ISimulator.SpeedDiff);
        }
    }
}
