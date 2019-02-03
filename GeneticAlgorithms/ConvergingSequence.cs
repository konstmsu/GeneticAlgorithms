using System;
using System.Collections.Generic;

namespace GeneticAlgorithms
{
    static class ConvergingSequence
    {
        public static SimpleSolvers.ConvergeStatistics<T> Converge<T>(IEnumerable<T> items, Func<T, int> valueFunc,
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

                return new SimpleSolvers.ConvergeStatistics<T>(bestItem, totalCandidateCount);
            }
        }
    }
}