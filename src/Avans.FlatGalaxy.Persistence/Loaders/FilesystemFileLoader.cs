using System;
using System.IO;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public class FileSystemFileLoader : IFileLoader
    {
        public string[] SupportedSchemas => new[]
        {
            "file"
        };

        public string GetContent(Uri source)
        {
            var path = source.AbsolutePath;

            if (!File.Exists(path))
            {
                var localPath = Path.Combine(Environment.CurrentDirectory, source.Host);
                if (File.Exists(localPath))
                {
                    path = localPath;
                }
                else throw new FileNotFoundException("The file does not exist.", path);
            }

            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be loaded.", e);
            }
        }
    }
}
