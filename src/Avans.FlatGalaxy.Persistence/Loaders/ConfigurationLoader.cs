using System;
using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

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

        protected abstract Galaxy Load(string body);
    }
}