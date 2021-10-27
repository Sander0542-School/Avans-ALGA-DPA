namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class ExplodeState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.TriggerStateEvent();
        }

        public ICollisionState Clone()
        {
            return new ExplodeState();
        }
    }
}
