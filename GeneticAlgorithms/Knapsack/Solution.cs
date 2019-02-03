using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithms.Knapsack
{
    public class Solution
    {
        readonly Problem _problem;
        readonly IReadOnlyCollection<Item> _items;

        public Solution(Problem problem, IReadOnlyCollection<Item> items)
        {
            _problem = problem;
            _items = items;

            Validate();
        }

        public string Description => $"Size: {TotalSize}, Value: {TotalValue}";
        public int TotalValue => _items.Sum(i => i.Value);
        int TotalSize => _items.Sum(i => i.Size);

        void Validate()
        {
            if (_items.Sum(i => i.Size) > _problem.SizeCapacity)
                throw new Exception();
        }
    }
}