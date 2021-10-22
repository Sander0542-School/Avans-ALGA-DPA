using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public class CsvConfigurationParser : ConfigurationParserBase
    {
        public CsvConfigurationParser(ICelestialBodyFactory celestialBodyFactory) : base(celestialBodyFactory)
        {
        }

        public override bool CanParse(string content)
        {
            return content.Split(Environment.NewLine).Skip(1).All(line => line.Split(',').Length == 10);
        }

        public override Galaxy Parse(string content)
        {
            var galaxy = new Galaxy();
            var lines = content.Split(Environment.NewLine).Skip(1).ToArray();

            var planetNeighbours = new Dictionary<Planet, string[]>();

            foreach (var line in lines)
            {
                if (line != "")
                {
                    var attributes = line.Split(';');

                    var name = attributes[0];
                    var type = attributes[1];

                    var x = double.Parse(attributes[2], CultureInfo.InvariantCulture);
                    var y = double.Parse(attributes[3], CultureInfo.InvariantCulture);
                    var vx = double.Parse(attributes[4], CultureInfo.InvariantCulture);
                    var vy = double.Parse(attributes[5], CultureInfo.InvariantCulture);
                    var radius = int.Parse(attributes[7], CultureInfo.InvariantCulture);

                    var neighbours = attributes[6].Split(',');
                    var color = attributes[8];
                    var onCollision = attributes[9];

                    var body = CelestialBodyFactory.Create(type, x, y, vx, vy, radius, color, onCollision, name);
                    galaxy.Add(body);
                    if (body is Planet planet) planetNeighbours.Add(planet, neighbours);
                }
            }

            MapNeighbours(galaxy, planetNeighbours);
            return galaxy;
        }
    }
}
