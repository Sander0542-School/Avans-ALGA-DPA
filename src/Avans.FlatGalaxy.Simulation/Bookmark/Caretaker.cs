using System.Collections.Generic;
using System.Linq;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class Caretaker
    {
        private readonly Stack<GalaxyMemento> _mementos;
        private readonly Originator _originator;

        public Caretaker(Originator originator)
        {
            _originator = originator;
            _mementos = new Stack<GalaxyMemento>();
        }

        public void Backup()
        {
            _mementos.Push(_originator.Save());
        }

        public void Undo()
        {
            if (!_mementos.Any()) return;

            var memento = _mementos.Pop();
            
            _originator.Restore(memento);
        }
    }
}
