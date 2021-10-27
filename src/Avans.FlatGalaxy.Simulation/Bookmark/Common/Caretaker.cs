using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;

namespace Avans.FlatGalaxy.Simulation.Bookmark.Common
{
    public abstract class Caretaker<T> : ICaretaker
    {
        private readonly Stack<IMemento<T>> _mementos;

        protected Caretaker()
        {
            _mementos = new Stack<IMemento<T>>();
        }

        protected abstract IMemento<T> Create();

        protected abstract void Restore(T model);

        public void Save()
        {
            _mementos.Push(Create());
        }

        public void Undo()
        {
            if (!_mementos.Any()) return;

            var memento = _mementos.Pop();

            Restore(memento.GetState());
        }
    }
}
