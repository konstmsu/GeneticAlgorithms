using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithms.Knapsack;
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

        public static Func<Problem, ConvergeStatistics<Solution>> Random(int seed, int noImprovementStreak) =>
            problem =>
            {
                var random = new Random(seed);

                var items = problem.Items.ToArray();
                var solutions = Unbounded(() =>
                {
                    random.Shuffle(items);
                    return FillKnapsack(problem, items);
                });

                return ConvergingSequence.Converge(solutions, s => s.TotalValue, noImprovementStreak);
            };

        public class ConvergeStatistics<T>
        {
            public readonly T BestItem;
            readonly int _iterationCount;

            public ConvergeStatistics(T bestItem, int iterationCount)
            {
                BestItem = bestItem;
                _iterationCount = iterationCount;
            }

            public string Description => $"After {_iterationCount:0,0} iterations";
        }

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