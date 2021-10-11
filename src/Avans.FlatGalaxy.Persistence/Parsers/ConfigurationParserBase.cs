using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public abstract class ConfigurationParserBase
    {
        protected readonly ICelestialBodyFactory CelestialBodyFactory;

        protected ConfigurationParserBase(ICelestialBodyFactory celestialBodyFactory)
        {
            CelestialBodyFactory = celestialBodyFactory;
        }

        public abstract Galaxy Parse(string content);

        public abstract bool CanParse(string content);

        protected static void MapNeighbours(Galaxy galaxy, Dictionary<Planet, string[]> planetNeighbours)
        {
            foreach (var (planet, neighbours) in planetNeighbours)
            {
                foreach (var neighbour in neighbours)
                {
                    planet.Neighbours.Add(galaxy.CelestialBodies.OfType<Planet>().First(b => b.Name == neighbour));
                }
            }
        }
    }
}
