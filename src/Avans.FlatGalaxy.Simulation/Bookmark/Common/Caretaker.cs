using System.Collections.Generic;
using System.Linq;

namespace Avans.FlatGalaxy.Simulation.Bookmark.Common
{
    public class Caretaker<T>
    {
        private readonly Stack<IMemento<T>> _mementos;
        private readonly Originator<T> _originator;

        public Caretaker(Originator<T> originator)
        {
            _originator = originator;
            _mementos = new Stack<IMemento<T>>();
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
