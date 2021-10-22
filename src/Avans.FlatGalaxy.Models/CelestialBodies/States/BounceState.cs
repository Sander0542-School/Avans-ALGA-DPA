namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class BounceState : ICollisionState
    {
        private int _collisions;
        
        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.VX = -self.VX;
            self.VY = -self.VY;

            if (++_collisions == 5)
            {
                self.CollisionState = new BlinkState();
            }
        }
    }
}
