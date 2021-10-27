namespace Avans.FlatGalaxy.Models.CelestialBodies.States
{
    public interface ICollisionState : ICloneable<ICollisionState>
    {
        public void Collide(CelestialBody self, CelestialBody other);
    }
}