using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders.File;

namespace Avans.FlatGalaxy.Persistence.Loaders.Configuration
{
    public class CsvConfigurationLoader : ConfigurationLoader
    {
        public CsvConfigurationLoader(ICelestialBodyFactory celestialBodyFactory) : base(celestialBodyFactory)
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
                    int.TryParse(attributes[4], out var vx);
                    int.TryParse(attributes[5], out var vy);
                    var neighbours = attributes[6].Split(',');
                    int.TryParse(attributes[7], out var radius);
                    var color = attributes[8];
                    var onCollision = attributes[9];

                    galaxy.CelestialBodies.Add(CelestialBodyFactory.Create(name, type, x, y, vx, vy, radius, color, onCollision));
                }
            }

            return galaxy;
        }
    }
}