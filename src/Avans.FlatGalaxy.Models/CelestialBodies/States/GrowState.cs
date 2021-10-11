namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class GrowState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.Radius += 1;

            if (self.Radius > 20)
            {
                self.CollisionState = new ExplodeState();
            }
        }
    }
}
