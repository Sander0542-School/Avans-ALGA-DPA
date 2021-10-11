namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class DisappearState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            self.TriggerStateEvent();
        }
    }
}
