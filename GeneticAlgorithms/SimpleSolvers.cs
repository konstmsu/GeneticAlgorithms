using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Knapsack;
using MoreLinq;
using static GeneticAlgorithms.Sugar;

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

        public static Func<Problem, Solution> Random(int seed, int population) =>
            problem =>
            {
                var random = new Random(seed);
                var solutions = Til(population).Select(i => FillKnapsack(problem, random.Shuffled(problem.Items)));
                return solutions.MaxBy(s => s.TotalValue).First();
            };

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