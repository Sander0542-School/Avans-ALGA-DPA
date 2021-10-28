using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Simulation.Bookmark.Common;

namespace Avans.FlatGalaxy.Simulation.Bookmark
{
    public class GalaxyMemento : IMemento<Galaxy>
    {
        private readonly IDictionary<CelestialBody, string[]> _celestialBodies;

        public GalaxyMemento(Galaxy galaxy)
        {
            _celestialBodies = galaxy.CelestialBodies.ToDictionary(body => body.Clone(), body => body is Planet planet ? planet.Neighbours.Select(planet1 => planet1.Name).ToArray() : Array.Empty<string>());
        }

        public Galaxy GetState()
        {
            var galaxy = new Galaxy(_celestialBodies.Keys);
            galaxy.MapNeighbours(_celestialBodies.Where(pair => pair.Key is Planet).ToDictionary(pair => pair.Key as Planet, pair => pair.Value));

            return galaxy;
        }
    }
}
