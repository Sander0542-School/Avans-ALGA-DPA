namespace Avans.FlatGalaxy.Simulation.Bookmark.Common
{
    public abstract class Originator<T>
    {
        public Originator(T state)
        {
            State = state;
        }

        public T State { get; private set; }

        public abstract IMemento<T> Save();

        public void Restore(IMemento<T> memento)
        {
            State = memento.GetState();
        }
    }
}
