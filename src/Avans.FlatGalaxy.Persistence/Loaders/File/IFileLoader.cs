using System;

namespace Avans.FlatGalaxy.Persistence.Loaders.File
{
    public interface IFileLoader
    {
        string[] SupportedSchemas { get; }
        
        string GetContent(Uri source);
    }
}