using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class CollisionVisibilityCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.ToggleCollisionVisibility();
        }
    }
}
