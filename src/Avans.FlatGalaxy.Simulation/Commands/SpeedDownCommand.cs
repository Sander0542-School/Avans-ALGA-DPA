using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class SpeedDownCommand : ICommand
    {
        private readonly double _speedDiff;

        public SpeedDownCommand(double speedDiff = ISimulator.SpeedDiff)
        {
            _speedDiff = speedDiff;
        }

        public void Execute(ISimulator simulator)
        {
            simulator.SpeedDown(_speedDiff);
        }
    }
}
