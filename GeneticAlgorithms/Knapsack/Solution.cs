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

        public string Description => $"Size: {Items.Sum(i => i.Size)}, Value: {Items.Sum(i => i.Value)}";

        void Validate()
        {
            if (Items.Sum(i => i.Size) > Problem.SizeCapacity)
                throw new Exception();
        }
    }
}