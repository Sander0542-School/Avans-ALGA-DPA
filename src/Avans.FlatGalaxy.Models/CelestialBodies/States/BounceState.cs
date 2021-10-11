namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class BounceState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.VX = -self.VX;
            self.VY = -self.VY;
        }
    }
}
