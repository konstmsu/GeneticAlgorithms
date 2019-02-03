using System;
using GeneticAlgorithms.Knapsack;

namespace GeneticAlgorithms
{
    static class Program
    {
        static void Main()
        {
            var generator = new ProblemGenerator(42);
            var problem = generator.Generate(1000, 100, 1, 1000, 1, 1000);

            var solvers = new (string name, Func<Problem, Solution> solve)[]
            {
                ("Largest value first", SimpleSolvers.LargestValueFirst),
                ("Smallest size first", SimpleSolvers.SmallestSizeFirst),
                ("Largest value/size first", SimpleSolvers.BestRatioFirst),
                ("Random", p => SimpleSolvers.Random(42, 600_000)(p).BestItem),
            };

            foreach (var solver in solvers)
            {
                var solution = solver.solve(problem);
                Console.WriteLine($"{solver.name} result: {solution.Description}");
            }
        }
    }
}