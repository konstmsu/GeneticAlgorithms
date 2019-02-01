using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using static GeneticAlgorithms.Sugar;

namespace GeneticAlgorithms
{
    public static class Extensions
    {
        public static IReadOnlyList<int> Permutation(this Random random, int max)
        {
            var items = Enumerable.Range(0, max).ToList();
            
            for (var i = items.Count - 1; i > 0; i--)
            {
                var j = random.Next(0, i);
                (items[i], items[j]) = (items[j], items[i]); 
            }

            return items;
        }

        public static IReadOnlyList<T> Shuffled<T>(this Random random, IReadOnlyList<T> items) => 
            random.Permutation(items.Count).Select(i => items[i]).ToList();
    }
}