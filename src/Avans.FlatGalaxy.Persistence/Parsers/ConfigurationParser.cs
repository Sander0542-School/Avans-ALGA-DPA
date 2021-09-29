using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public abstract class ConfigurationParser
    {
        protected readonly ICelestialBodyFactory CelestialBodyFactory;
        private readonly IFileLoader _fileLoader;

        protected ConfigurationParser(ICelestialBodyFactory celestialBodyFactory, IFileLoader fileLoader)
        {
            CelestialBodyFactory = celestialBodyFactory;
            _fileLoader = fileLoader;
        }

        public Galaxy Load(Uri source)
        {
            return Load(_fileLoader.GetContent(source));
        }

        protected abstract Galaxy Load(string body);
        
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