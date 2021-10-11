namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class GrowState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            if (self.Radius++ >= 20)
            {
                self.CollisionState = new ExplodeState();
            }
        }
    }
}
