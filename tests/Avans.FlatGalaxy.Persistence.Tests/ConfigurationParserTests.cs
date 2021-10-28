using System;
using Avans.FlatGalaxy.Persistence.Factories;
using Avans.FlatGalaxy.Persistence.Loaders;
using Avans.FlatGalaxy.Persistence.Parsers;
using Xunit;

namespace Avans.FlatGalaxy.Persistence.Tests
{
    public class ConfigurationParserTests
    {
        private readonly CelestialBodyFactory _bodyFactory;
        private readonly IFileLoader _fileLoader;

        public ConfigurationParserTests()
        {
            _bodyFactory = new CelestialBodyFactory();
            _fileLoader = new FileLoader();
        }

        [Theory]
        [InlineData("https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media")]
        [InlineData("file://planetsExtended.xml")]
        public void Test_ConfigurationParser_Xml(string uri)
        {
            var content = _fileLoader.GetContent(new Uri(uri));

            var parser = new XmlConfigurationParser(_bodyFactory);

            Assert.True(parser.CanParse(content));

            var galaxy = parser.Parse(content);

            Assert.NotEmpty(galaxy.CelestialBodies);
        }

        [Theory]
        [InlineData("https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media")]
        [InlineData("file://planetsExtended.csv")]
        public void Test_ConfigurationParser_Csv(string uri)
        {
            var content = _fileLoader.GetContent(new Uri(uri));

            var parser = new CsvConfigurationParser(_bodyFactory);

            Assert.True(parser.CanParse(content));

            var galaxy = parser.Parse(content);

            Assert.NotEmpty(galaxy.CelestialBodies);
        }

        [Theory]
        [InlineData("https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media")]
        [InlineData("file://planetsExtended.xml")]
        [InlineData("https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media")]
        [InlineData("file://planetsExtended.csv")]
        public void Test_ConfigurationParser(string uri)
        {
            var content = _fileLoader.GetContent(new Uri(uri));

            var parser = new ConfigurationParser(_bodyFactory);

            Assert.True(parser.CanParse(content));

            var galaxy = parser.Parse(content);

            Assert.NotEmpty(galaxy.CelestialBodies);
        }
    }
}
