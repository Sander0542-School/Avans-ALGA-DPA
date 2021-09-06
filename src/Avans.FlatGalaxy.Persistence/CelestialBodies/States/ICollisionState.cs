namespace Avans.FlatGalaxy.Persistence.CelestialBodies.States
{
    public interface ICollisionState
    {
        public void Collide(CelestialBody celestialBody);
    }
}