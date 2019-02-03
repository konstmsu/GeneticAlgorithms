using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithms
{
    public static class Sugar
    {
        public static IEnumerable<int> Til(int max) =>
            Enumerable.Range(0, max).ToList();

        public static IEnumerable<T> Unbounded<T>(Func<T> generator)
        {
            for (;;)
                yield return generator();
            // ReSharper disable once IteratorNeverReturns
        }
    }
}