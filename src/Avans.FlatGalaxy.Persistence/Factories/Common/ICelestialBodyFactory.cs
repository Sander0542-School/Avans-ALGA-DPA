using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Persistence.Factories.Common
{
    public interface ICelestialBodyFactory
    {
        CelestialBody Create(string type, int x, int y, int vx, int vy, int radius, string color, string collision);
    }
}