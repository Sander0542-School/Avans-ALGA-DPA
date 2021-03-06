using Avans.FlatGalaxy.Simulation.Commands.Common;

namespace Avans.FlatGalaxy.Simulation.Commands
{
    public class CollisionSwitchCommand : ICommand
    {
        public void Execute(ISimulator simulator)
        {
            simulator.SwitchCollisionAlgo();
        }
    }
}
