using System.Collections.Generic;

namespace Avans.FlatGalaxy.Simulation.Common
{
    public class ImplementationSwapper<T>
    {
        private readonly List<T> _items;

        private int _cIndex;

        public ImplementationSwapper()
        {
            _items = new();
        }

        protected void Add(T item)
        {
            _items.Add(item);
        }

        public void Next()
        {
            if (++_cIndex >= _items.Count)
            {
                _cIndex = 0;
            }
        }

        public T Current => _items[_cIndex];
    }
}
