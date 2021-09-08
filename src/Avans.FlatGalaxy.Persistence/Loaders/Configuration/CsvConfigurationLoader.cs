using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders.File;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public class CsvConfigurationLoader : ConfigurationLoader
    {
        public CsvConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFileLoader fileLoader) : base(celestialBodyFactory, fileLoader)
        {
        }

        protected override Galaxy Load(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}