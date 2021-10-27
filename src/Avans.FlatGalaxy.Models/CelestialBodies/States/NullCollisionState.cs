namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class NullCollisionState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            // do nothing
        }
        
        public ICollisionState Clone()
        {
            return new NullCollisionState();
        }
    }
}
