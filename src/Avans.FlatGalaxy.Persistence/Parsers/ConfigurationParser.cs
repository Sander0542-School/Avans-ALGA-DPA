using System;
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
    }
}