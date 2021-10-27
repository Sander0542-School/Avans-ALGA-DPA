namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public class GrowState : ICollisionState
    {
        public void Collide(CelestialBody self, CelestialBody other)
        {
            if (self.Radius++ >= 20)
            {
                self.TriggerStateEvent();
            }
        }
        
        public ICollisionState Clone()
        {
            return new GrowState();
        }
    }
}
