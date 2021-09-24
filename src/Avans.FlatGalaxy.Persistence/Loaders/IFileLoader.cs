using System;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public interface IFileLoader
    {
        string[] SupportedSchemas { get; }
        
        string GetContent(Uri source);
    }
}