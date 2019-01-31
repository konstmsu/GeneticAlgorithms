using System;
using System.Linq;

namespace GeneticAlgorithms.Knapsack
{
    public class ProblemGenerator
    {
        readonly Random _random;

        public ProblemGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public Problem Generate(
            int sizeCapacity, int count, 
            int minSize, int maxSize, 
            int minValue, int maxValue)
        {
            return new Problem(sizeCapacity, Enumerable.Range(0, count).Select(i =>
                new Item(
                    _random.Next(minSize, maxSize), 
                    _random.Next(minValue, maxValue))
            ).ToList().AsReadOnly());    
        }
    }
}