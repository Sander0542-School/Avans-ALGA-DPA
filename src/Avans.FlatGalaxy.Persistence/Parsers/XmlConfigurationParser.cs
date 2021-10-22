using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public class XmlConfigurationParser : ConfigurationParserBase
    {
        public XmlConfigurationParser(ICelestialBodyFactory celestialBodyFactory) : base(celestialBodyFactory)
        {
        }

        public override bool CanParse(string content)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(content);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override Galaxy Parse(string content)
        {
            var galaxy = new Galaxy();

            var xmlBody = new XmlDocument();
            xmlBody.LoadXml(content);

            var xmlNode = xmlBody.ChildNodes[1];
            if (xmlNode == null) return galaxy;

            var planetNeighbours = new Dictionary<Planet, string[]>();

            foreach (XmlNode celestialBody in xmlNode.ChildNodes)
            {
                if (celestialBody.NodeType != XmlNodeType.Element) continue;

                var name = ((XmlText)celestialBody["name"]?.ChildNodes[0])?.Data;
                var type = celestialBody.Name;
                var color = ((XmlText)celestialBody["color"]?.ChildNodes[0])?.Data;
                var onCollision = ((XmlText)celestialBody["oncollision"]?.ChildNodes[0])?.Data;

                var positionNode = (XmlNode)celestialBody["position"];
                var posX = 0.0;
                var posY = 0.0;
                var radius = 0;
                if (positionNode != null)
                {
                    posX = double.Parse(((XmlText)positionNode["x"]?.ChildNodes[0])?.Data ?? "0", CultureInfo.InvariantCulture);
                    posY = double.Parse(((XmlText)positionNode["y"]?.ChildNodes[0])?.Data ?? "0", CultureInfo.InvariantCulture);
                    radius = int.Parse(((XmlText)positionNode["radius"]?.ChildNodes[0])?.Data ?? "0");
                }

                var speedNode = (XmlNode)celestialBody["speed"];
                var speedX = 0.0;
                var speedY = 0.0;
                if (speedNode != null)
                {
                    speedX = double.Parse(((XmlText)speedNode["x"]?.ChildNodes[0])?.Data ?? "0", CultureInfo.InvariantCulture);
                    speedY = double.Parse(((XmlText)speedNode["y"]?.ChildNodes[0])?.Data ?? "0", CultureInfo.InvariantCulture);
                }

                var neighbours = new List<string>();
                var neighboursNode = (XmlNode)celestialBody["neighbours"];
                if (neighboursNode != null)
                {
                    foreach (XmlNode neighbourNode in neighboursNode.ChildNodes)
                    {
                        var neighbour = ((XmlText)neighbourNode?.ChildNodes[0]).Data;
                        if (!string.IsNullOrEmpty(neighbour)) neighbours.Add(neighbour);
                    }
                }

                var body = CelestialBodyFactory.Create(type, posX, posY, speedX, speedY, radius, color, onCollision, name);
                galaxy.Add(body);

                if (body is Planet planet) planetNeighbours.Add(planet, neighbours.ToArray());
            }

            MapNeighbours(galaxy, planetNeighbours);
            return galaxy;
        }
    }
}
