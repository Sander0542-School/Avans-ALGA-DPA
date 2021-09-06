using System;

namespace Avans.FlatGalaxy.Persistence.Loaders.File
{
    public interface IFileLoader
    {
        string GetContent(Uri source);
    }
}