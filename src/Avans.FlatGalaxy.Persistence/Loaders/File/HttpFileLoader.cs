using System;
using System.Net.Http;

namespace Avans.FlatGalaxy.Persistence.Loaders.File
{
    class HttpFileLoader : IFileLoader
    {
        public string[] SupportedSchemas => new[]
        {
            "http",
            "https"
        };

        public string GetContent(Uri source)
        {
            using var client = new HttpClient();
            return client.GetStringAsync(source).Result;
        }
    }
}
