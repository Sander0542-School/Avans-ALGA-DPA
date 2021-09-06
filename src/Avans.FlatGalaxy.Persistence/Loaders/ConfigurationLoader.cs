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
            IFileLoader fileLoader;
            switch (source.Scheme)
            {
                case "file":
                    fileLoader = new FilesystemFileLoader();
                    break;
                case "http":
                case "https":
                    fileLoader = new WebFileLoader();
                    break;
                default:
                    throw new InvalidOperationException("The specified source is not a valid source");
            }

            return Load(fileLoader.GetContent(source));
        }

        protected abstract Galaxy Load(string body);
    }
}