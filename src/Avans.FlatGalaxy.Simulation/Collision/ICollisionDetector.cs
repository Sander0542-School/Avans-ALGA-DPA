namespace Avans.FlatGalaxy.Simulation.Collision
{
    public interface ICollisionDetector
    {
        void Detect(ISimulator simulator, CollisionHandler handler);
    }
}
