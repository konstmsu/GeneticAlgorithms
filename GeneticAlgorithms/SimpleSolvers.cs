using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Knapsack;

namespace GeneticAlgorithms
{
    public static class SimpleSolvers
    {
        public static Solution SmallestSizeFirst(Problem problem) => 
            FillKnapsack(problem, problem.Items.OrderBy(i => i.Size));

        public static Solution LargestValueFirst(Problem problem) => 
            FillKnapsack(problem, problem.Items.OrderByDescending(i => i.Value));

        public static Solution BestRatioFirst(Problem problem) => 
            FillKnapsack(problem, problem.Items.OrderByDescending(i => i.Value / (double) i.Size));

        static Solution FillKnapsack(Problem problem, IEnumerable<Item> orderedItems)
        {
            var items = new List<Item>();
            var totalSize = 0;
            foreach (var item in orderedItems)
                if (totalSize + item.Size <= problem.SizeCapacity)
                {
                    items.Add(item);
                    totalSize += item.Size;
                }
            
            return new Solution(problem, items);
        }
    }
}