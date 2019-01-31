using System;
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
}