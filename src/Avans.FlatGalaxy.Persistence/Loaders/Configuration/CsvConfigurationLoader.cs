using System;
using System.IO;
using System.Linq;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using CsvHelper;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public class CsvConfigurationLoader : ConfigurationLoader
    {
        public CsvConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFoldFactory foldFactory) : base(celestialBodyFactory, foldFactory)
        {
        }

        protected override Galaxy Load(string content)
        {
            var galaxy = new Galaxy();
            var lines = content.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var attributes = line.Split(';');
            }

            return galaxy;
        }
    }
}