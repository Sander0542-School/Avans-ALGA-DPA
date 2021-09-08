using System;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders.File;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public abstract class ConfigurationLoader
    {
        protected ICelestialBodyFactory CelestialBodyFactory;

        protected ConfigurationLoader(ICelestialBodyFactory celestialBodyFactory)
        {
            CelestialBodyFactory = celestialBodyFactory;
        }

        public Galaxy Load(Uri source)
        {
            return Load(_fileLoader.GetContent(source));
        }

        protected abstract Galaxy Load(string body);
    }
}
