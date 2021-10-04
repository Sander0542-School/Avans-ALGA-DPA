namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class NullCollisionState : ICollisionState
    {
        public void Collide(CelestialBody celestialBody)
        {
            // do nothing
        }
    }
}
