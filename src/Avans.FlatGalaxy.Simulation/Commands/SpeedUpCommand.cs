using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class SpeedUpCommand : ICommand
    {
        private readonly double _speedDiff;

        public SpeedUpCommand(double speedDiff = ISimulator.SpeedDiff)
        {
            _speedDiff = speedDiff;
        }

        public void Execute(ISimulator simulator)
        {
            simulator.SpeedUp(_speedDiff);
        }
    }
}
