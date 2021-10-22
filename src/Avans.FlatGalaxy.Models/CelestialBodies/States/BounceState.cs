namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class BounceState : ICollisionState
    {
        private int _collisions;

        public BounceState() {}

        private BounceState(int collisions)
        {
            _collisions = collisions;
        }

        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.VX = -self.VX;
            self.VY = -self.VY;

            if (++_collisions == 5)
            {
                self.TriggerStateEvent();
            }
        }

        public ICollisionState Clone()
        {
            return new BounceState(_collisions);
        }
    }
}
