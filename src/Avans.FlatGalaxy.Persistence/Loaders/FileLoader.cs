using System;
using System.Collections.Generic;
using System.Linq;

namespace Avans.FlatGalaxy.Persistence.Loaders
{
    public class FileLoader : IFileLoader
    {
        private readonly IDictionary<string, IFileLoader> _fileLoadersDict = new Dictionary<string, IFileLoader>();

        public string[] SupportedSchemas => _fileLoadersDict.Keys.ToArray();

        public FileLoader()
        {
            var fileLoaders = new IFileLoader[]
            {
                new FileSystemFileLoader(),
                new HttpFileLoader()
            };

            foreach (var fileLoader in fileLoaders)
            {
                foreach (var schema in fileLoader.SupportedSchemas)
                {
                    _fileLoadersDict.Add(schema, fileLoader);
                }
            }
        }

        public string GetContent(Uri source)
        {
            if (!SupportedSchemas.Contains(source.Scheme))
            {
                throw new NotImplementedException($"There is no file loader for type {source.Scheme}");
            }

            return _fileLoadersDict[source.Scheme].GetContent(source);
        }
    }
}
