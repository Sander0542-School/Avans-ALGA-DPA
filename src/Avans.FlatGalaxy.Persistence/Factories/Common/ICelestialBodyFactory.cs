using Avans.FlatGalaxy.Models.CelestialBodies;

namespace Avans.FlatGalaxy.Persistence.Factories.Common
{
    public interface ICelestialBodyFactory
    {
        CelestialBody Create(string type, double x, double y, double vx, double vy, int radius, string color, string collision, string name = null);
    }
}