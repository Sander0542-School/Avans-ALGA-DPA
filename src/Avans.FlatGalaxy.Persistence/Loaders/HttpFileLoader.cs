using System;
using System.Net.Http;

namespace Avans.FlatGalaxy.Persistence.Loaders
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
            try
            {
                using var client = new HttpClient();
                return client.GetStringAsync(source).Result;
            }
            catch (Exception e)
            {
                throw new HttpRequestException("The file cannot be loaded form the internet.", e);
            }
        }
    }
}
