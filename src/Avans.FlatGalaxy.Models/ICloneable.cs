using System;

namespace Avans.FlatGalaxy.Models
{
    public interface ICloneable<T> : ICloneable
    {
        new T Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
