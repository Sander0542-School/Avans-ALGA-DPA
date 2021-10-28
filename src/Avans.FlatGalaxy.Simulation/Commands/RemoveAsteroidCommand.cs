using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class RemoveAsteroidCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.RemoveAsteroid();
        }
    }
}
