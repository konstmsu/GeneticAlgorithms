using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GeneticAlgorithms.Knapsack;

namespace GeneticAlgorithms
{
    static class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProblemGenerator(42);
            var problem = generator.Generate(1000, 100, 1, 1000, 1, 1000);

            var solvers = new (string name, Func<Problem, Solution> solve)[]
            {
                ("Largest value first", SimpleSolvers.LargestValueFirst),
                ("Smallest size first", SimpleSolvers.SmallestSizeFirst),
                ("Largest value/size first", SimpleSolvers.BestRatioFirst),
            };

            foreach (var solver in solvers)
            {
                var solution = solver.solve(problem);
                Console.WriteLine($"{solver.name} result: {solution.Description}");
            }
        }
    }

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