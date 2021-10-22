namespace Avans.FlatGalaxy.Simulation.Collision
{
    public interface ICollisionDetector
    {
        void Collide(ISimulator simulator, CollisionHandler handler);
    }
}
