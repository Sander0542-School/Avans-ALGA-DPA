using System.Xml;
using Avans.FlatGalaxy.Persistence.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders.File;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public class XmlConfigurationLoader : ConfigurationLoader
    {
        public XmlConfigurationLoader(ICelestialBodyFactory celestialBodyFactory, IFileLoader fileLoader) : base(celestialBodyFactory, fileLoader)
        {
        }

        protected override Galaxy Load(string content)
        {
            var galaxy = new Galaxy();
            
            var xmlBody = new XmlDocument();
            xmlBody.LoadXml(content);

            foreach (XmlNode xmlNode in xmlBody.ChildNodes)
            {
                if (xmlNode.Name == "planet")
                {
                    var planet = new Planet
                    {
                        
                    };
                }
            }

            return galaxy;
        }
    }
}