using System.Xml;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public class XmlConfigurationParser : ConfigurationParser
    {
        public XmlConfigurationParser(ICelestialBodyFactory celestialBodyFactory, IFileLoader fileLoader) : base(celestialBodyFactory, fileLoader)
        {
        }

        protected override Galaxy Load(string content)
        {
            var galaxy = new Galaxy();

            var xmlBody = new XmlDocument();
            xmlBody.LoadXml(content);

            var xmlNode = xmlBody.ChildNodes[1];
            if (xmlNode == null) return galaxy;

            foreach (XmlNode celestialBody in xmlNode.ChildNodes)
            {
                if (celestialBody.NodeType == XmlNodeType.Element)
                {
                    var name = ((XmlText) celestialBody["name"]?.ChildNodes[0])?.Data;
                    var type = celestialBody.Name;
                    var color = ((XmlText) celestialBody["color"]?.ChildNodes[0])?.Data;
                    var onCollision = ((XmlText) celestialBody["oncollision"]?.ChildNodes[0])?.Data;

                    var positionNode = (XmlNode) celestialBody["position"];
                    var posX = 0;
                    var posY = 0;
                    var radius = 0;
                    if (positionNode != null)
                    {
                        posX = int.Parse(((XmlText) positionNode["x"]?.ChildNodes[0])?.Data ?? "0");
                        posY = int.Parse(((XmlText) positionNode["y"]?.ChildNodes[0])?.Data ?? "0");
                        radius = int.Parse(((XmlText) positionNode["radius"]?.ChildNodes[0])?.Data ?? "0");
                    }

                    var speedNode = (XmlNode) celestialBody["speed"];
                    var speedX = 0.0;
                    var speedY = 0.0;
                    if (speedNode != null)
                    {
                        speedX = double.Parse(((XmlText) speedNode["x"]?.ChildNodes[0])?.Data ?? "0");
                        speedY = double.Parse(((XmlText) speedNode["y"]?.ChildNodes[0])?.Data ?? "0");
                    }

                    galaxy.CelestialBodies.Add(CelestialBodyFactory.Create(type, posX, posY, speedX, speedY, radius, color, onCollision, name));
                }
            }

            return galaxy;
        }
    }
}