using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class GalaxyMemento : IMemento<Galaxy>
    {
        private readonly IList<CelestialBody> _celestialBodies;

        public GalaxyMemento(Galaxy galaxy)
        {
            _celestialBodies = galaxy.CelestialBodies.Select(body => body.Clone()).ToList();
        }

        public Galaxy GetState()
        {
            return new Galaxy(_celestialBodies);
        }
    }
}
