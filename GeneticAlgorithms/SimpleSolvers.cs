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

                return Converge(solutions, s => s.TotalValue, noImprovementStreak);
            };

        public class ConvergeStatistics<T>
        {
            public readonly T BestItem;
            public readonly int BestValue;
            public readonly int IterationCount;

            public ConvergeStatistics(T bestItem, int bestValue, int iterationCount)
            {
                BestItem = bestItem;
                BestValue = bestValue;
                IterationCount = iterationCount;
            }

            public string Description => $"After {IterationCount:0,0} iterations";
        }

        public static ConvergeStatistics<T> Converge<T>(IEnumerable<T> items, Func<T, int> valueFunc,
            int noImprovementsStreak)
        {
            using (var enumerator = items.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new Exception();

                var totalCandidateCount = 0;
                var bestIndex = 0;
                var bestItem = enumerator.Current;
                var bestValue = valueFunc(bestItem);

                for (;; totalCandidateCount++)
                {
                    if (!enumerator.MoveNext())
                        break;

                    var item = enumerator.Current;
                    var value = valueFunc(item);

                    if (value >= bestValue)
                    {
                        bestValue = value;
                        bestItem = item;
                        bestIndex = totalCandidateCount;
                    }

                    if (totalCandidateCount - bestIndex >= noImprovementsStreak)
                        break;
                }

                return new ConvergeStatistics<T>(bestItem, bestValue, totalCandidateCount);
            }
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