using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public class CsvConfigurationLoader : ConfigurationLoader
    {
        public CsvConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFoldFactory foldFactory) : base(celestialBodyFactory, foldFactory)
        {
        }

        protected override Galaxy Load(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}