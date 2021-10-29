using System;
using System.IO;
using System.Net.Http;
using Avans.FlatGalaxy.Persistence.Loaders;
using Xunit;

namespace Avans.FlatGalaxy.Persistence.Tests
{
    public class FileLoaderTests
    {
        [Theory]
        [InlineData("http")]
        [InlineData("https")]
        public void Test_FileLoader_Http_Supported(string schema)
        {
            var loader = new HttpFileLoader();

            Assert.Contains(schema, loader.SupportedSchemas);
        }

        [Theory]
        [InlineData("file")]
        public void Test_FileLoader_FileSystem_Supported(string schema)
        {
            var loader = new FileSystemFileLoader();

            Assert.Contains(schema, loader.SupportedSchemas);
        }

        [Theory]
        [InlineData("file")]
        [InlineData("http")]
        [InlineData("https")]
        public void Test_FileLoader_Supported(string schema)
        {
            var loader = new FileLoader();

            Assert.Contains(schema, loader.SupportedSchemas);
        }

        [Theory]
        [InlineData("https://google.com")]
        [InlineData("https://www.avans.nl")]
        public void Test_FileLoader_Http_GetContent_Success(string uri)
        {
            var loader = new HttpFileLoader();
            var content = loader.GetContent(new(uri));

            Assert.False(string.IsNullOrWhiteSpace(content));
        }

        [Theory]
        [InlineData("https://httpstat.us/404")]
        [InlineData("https://httpstat.us/500")]
        public void Test_FileLoader_Http_GetContent_Exception(string uri)
        {
            var loader = new HttpFileLoader();

            Assert.Throws<HttpRequestException>(() => loader.GetContent(new(uri)));
        }

        [Theory]
        [InlineData("file://planetsExtended.xml")]
        [InlineData("file://planetsExtended.csv")]
        public void Test_FileLoader_FileSystem_GetContent_Success(string uri)
        {
            var loader = new FileSystemFileLoader();
            var content = loader.GetContent(new(uri));

            Assert.False(string.IsNullOrWhiteSpace(content));
        }

        [Theory]
        [InlineData("file://planetsExtended.xml2")]
        [InlineData("file://planetsExtended.csv2")]
        public void Test_FileLoader_FileSystem_GetContent_Exception(string uri)
        {
            var loader = new FileSystemFileLoader();
            
            Assert.Throws<FileNotFoundException>(() => loader.GetContent(new(uri)));
        }
    }
}
