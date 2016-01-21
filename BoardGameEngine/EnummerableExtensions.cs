﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameEngine
{
    public static class EnummerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];

                elements[swapIndex] = elements[i];
            }
        }
    }
}
