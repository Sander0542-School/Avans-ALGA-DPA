using System.Collections.Generic;
using System.Linq;
using Avans.FlatGalaxy.Models;
using Avans.FlatGalaxy.Models.CelestialBodies;
using Avans.FlatGalaxy.Persistence.Factories.Common;

namespace Avans.FlatGalaxy.Persistence.Parsers
{
    public abstract class ConfigurationParserBase
    {
        protected readonly ICelestialBodyFactory CelestialBodyFactory;

        protected ConfigurationParserBase(ICelestialBodyFactory celestialBodyFactory)
        {
            CelestialBodyFactory = celestialBodyFactory;
        }

        public abstract Galaxy Parse(string content);

        public abstract bool CanParse(string content);
    }
}
