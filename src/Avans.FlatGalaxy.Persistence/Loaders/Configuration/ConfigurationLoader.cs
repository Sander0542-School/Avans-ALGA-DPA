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
            IFileLoader fileLoader = source.Scheme switch
            {
                "file" => new FileSystemFileLoader(),
                "http" => new HttpFileLoader(),
                "https" => new HttpFileLoader(),
                _ => throw new InvalidOperationException($"There is not file loader for the source type {source.Scheme}")
            };

            return Load(fileLoader.GetContent(source));
        }

        protected abstract Galaxy Load(string body);
    }
}