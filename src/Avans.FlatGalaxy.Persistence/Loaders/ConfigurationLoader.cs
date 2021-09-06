using System;
using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders.File;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public abstract class ConfigurationLoader
    {
        private ICelestialBodyFactory _celestialBodyFactory;
        private IFoldFactory _foldFactory;

        protected ConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFoldFactory foldFactory)
        {
            _celestialBodyFactory = celestialBodyFactory;
            _foldFactory = foldFactory;
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