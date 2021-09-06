using System.Xml;
using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public class XmlConfigurationLoader : ConfigurationLoader
    {
        public XmlConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFoldFactory foldFactory) : base(celestialBodyFactory, foldFactory)
        {
        }

        protected override Galaxy Load(string content)
        {
            var galaxy = new Galaxy();
            
            var xmlBody = new XmlDocument();
            xmlBody.LoadXml(content);

            return galaxy;
        }
    }
}