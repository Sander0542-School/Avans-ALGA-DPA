﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Avans.FlatGalaxy.Simulation.Extensions
{
    public static class ListExtensions
    {
        public static T Random<T>(this IEnumerable<T> source)
        {
            return source.Random(1).Single();
        }

        public static IEnumerable<T> Random<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
