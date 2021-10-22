using System;
using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public class ConfigurationParser : ConfigurationParserBase
    {
        private readonly IList<ConfigurationParserBase> _configurationParsers;

        public ConfigurationParser(ICelestialBodyFactory celestialBodyFactory) : base(celestialBodyFactory)
        {
            _configurationParsers = new List<ConfigurationParserBase>
            {
                new XmlConfigurationParser(celestialBodyFactory),
                new CsvConfigurationParser(celestialBodyFactory),
            };
        }

        public override bool CanParse(string content)
        {
            return _configurationParsers.Any(configurationParser => configurationParser.CanParse(content));
        }

        public override Galaxy Parse(string content)
        {
            foreach (var configurationParser in _configurationParsers)
            {
                if (configurationParser.CanParse(content))
                {
                    return configurationParser.Parse(content);
                }
            }
            throw new NotImplementedException("There is no parser for this file");
        }
    }
}
