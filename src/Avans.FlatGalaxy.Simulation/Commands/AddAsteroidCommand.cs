using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class AddAsteroidCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.AddAsteroid();
        }
    }
}
