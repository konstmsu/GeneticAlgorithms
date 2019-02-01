using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithms.Knapsack
{
    public class Solution
    {
        public readonly Problem Problem;
        public readonly IReadOnlyCollection<Item> Items;

        public Solution(Problem problem, IReadOnlyCollection<Item> items)
        {
            Problem = problem;
            Items = items;

            Validate();
        }

        public string Description => $"Size: {TotalSize}, Value: {TotalValue}";
        public int TotalValue => Items.Sum(i => i.Value);
        public int TotalSize => Items.Sum(i => i.Size);

        void Validate()
        {
            if (Items.Sum(i => i.Size) > Problem.SizeCapacity)
                throw new Exception();
        }
    }
}