using System;
using System.IO;

namespace Avans.FlatGalaxy.Persistence.Loaders.File
{
    class FileSystemFileLoader : IFileLoader
    {
        public string[] SupportedSchemas => new[]
        {
            "file"
        };

        public string GetContent(Uri source)
        {
            var path = source.AbsolutePath;

            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException("The configuration file does not exist", path);
            }

            return System.IO.File.ReadAllText(path);
        }
    }
}
