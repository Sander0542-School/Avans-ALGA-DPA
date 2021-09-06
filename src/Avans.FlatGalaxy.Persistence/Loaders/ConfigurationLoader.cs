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

        public abstract CelestialBody[] Load(Uri source);
    }
}