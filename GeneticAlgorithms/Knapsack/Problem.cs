using System.Collections.Generic;

namespace GeneticAlgorithms.Knapsack
{
    public class Problem
    {
        public readonly int SizeCapacity;
        public readonly IReadOnlyList<Item> Items;

        public Problem(int sizeCapacity, IReadOnlyList<Item> items)
        {
            SizeCapacity = sizeCapacity;
            Items = items;
        }
    }
}