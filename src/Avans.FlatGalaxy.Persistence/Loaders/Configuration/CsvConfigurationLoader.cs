﻿using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public class CsvConfigurationLoader : ConfigurationLoader
    {
        public CsvConfigurationLoader(ICelestialBodyFactory celestialBodyFactory) : base(celestialBodyFactory)
        {
        }

        protected override Galaxy Load(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}