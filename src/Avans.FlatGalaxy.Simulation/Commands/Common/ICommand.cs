namespace Avans.FlatGalaxy.Simulation.Commands.Common
{
    public interface ICommand
    {
        void Execute(ISimulator simulator);
    }
}
