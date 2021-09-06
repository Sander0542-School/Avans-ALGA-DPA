using System;
using System.Net.Http;

namespace Avans.FlatGalaxy.Persistence.Loaders.File
{
    public class WebFileLoader : IFileLoader
    {
        public string GetContent(Uri source)
        {
            using var client = new HttpClient();
            return client.GetStringAsync(source).Result;
        }
    }
}