using System;

namespace GeneticAlgorithms
{
    public static class Extensions
    {
        public static void Shuffle<T>(this Random random, T[] items)
        {
            // Accepts array instead of IList for performance reasons
            for (var i = items.Length - 1; i > 0; i--)
            {
                var j = random.Next(0, i);
                (items[i], items[j]) = (items[j], items[i]);
            }
        }
    }
}