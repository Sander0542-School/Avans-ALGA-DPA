using System;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public class CsvConfigurationParser : ConfigurationParser
    {
        public CsvConfigurationParser(ICelestialBodyFactory celestialBodyFactory, IFileLoader fileLoader) : base(celestialBodyFactory, fileLoader)
        {
        }

        protected override Galaxy Load(string content)
        {
            var galaxy = new Galaxy();
            var lines = content.Split(Environment.NewLine).Skip(1).ToArray();

            foreach (var line in lines)
            {
                if (line != "")
                {
                    var attributes = line.Split(';');

                    var name = attributes[0];
                    var type = attributes[1];
                    int.TryParse(attributes[2], out var x);
                    int.TryParse(attributes[3], out var y);
                    double.TryParse(attributes[4], out var vx);
                    double.TryParse(attributes[5], out var vy);
                    var neighbours = attributes[6].Split(',');
                    int.TryParse(attributes[7], out var radius);
                    var color = attributes[8];
                    var onCollision = attributes[9];

                    galaxy.CelestialBodies.Add(CelestialBodyFactory.Create(type, x, y, vx, vy, radius, color, onCollision, name));
                }
            }

            return galaxy;
        }
    }
}