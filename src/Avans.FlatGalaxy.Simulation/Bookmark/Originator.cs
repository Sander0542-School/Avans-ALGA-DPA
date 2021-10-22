using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class Originator
    {
        private Galaxy _state;

        public Originator(Galaxy state)
        {
            _state = state;
        }

        public Galaxy State => _state;

        public GalaxyMemento Save()
        {
            return new GalaxyMemento(_state);
        }

        public void Restore(GalaxyMemento memento)
        {
            _state = memento.GetState();
        }
    }
}
