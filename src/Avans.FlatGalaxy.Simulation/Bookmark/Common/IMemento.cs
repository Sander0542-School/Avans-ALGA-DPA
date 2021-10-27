namespace Avans.FlatGalaxy.Simulation.Bookmark.Common
{
    public interface IMemento<T>
    {
        T GetState();
    }
}
