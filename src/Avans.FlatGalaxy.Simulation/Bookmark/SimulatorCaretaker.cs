using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class SimulatorCaretaker : Caretaker<Galaxy>
    {
        private readonly ISimulator _simulator;

        public SimulatorCaretaker(ISimulator simulator)
        {
            _simulator = simulator;
        }

        protected override IMemento<Galaxy> Create()
        {
            return new GalaxyMemento(_simulator.Galaxy);
        }

        protected override void Restore(Galaxy galaxy)
        {
            _simulator.Galaxy = galaxy;
        }
    }
}
