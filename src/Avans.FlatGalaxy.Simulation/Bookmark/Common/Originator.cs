namespace Avans.FlatGalaxy.Simulation.Bookmark.Common
{
    public abstract class Originator<T>
    {
        private T _state;

        public Originator(T state)
        {
            _state = state;
        }

        public T State => _state;

        public abstract IMemento<T> Save();

        public void Restore(IMemento<T> memento)
        {
            _state = memento.GetState();
        }
    }
}
