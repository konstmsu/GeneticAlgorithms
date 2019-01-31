using System;
using FluentAssertions;
using GeneticAlgorithms.Knapsack;
using Xunit;

namespace GeneticAlgorithms.Tests
{
    public class SimpleSolversTests
    {
        [Fact]
        public void Regression()
        {
            var generator = new ProblemGenerator(42);
            var problem = generator.Generate(1000, 100, 1, 1000, 1, 1000);

            SimpleSolvers.LargestValueFirst(problem).Description.Should().Be("Size: 983, Value: 4717");
            SimpleSolvers.SmallestSizeFirst(problem).Description.Should().Be("Size: 954, Value: 8188");
            SimpleSolvers.BestRatioFirst(problem).Description.Should().Be("Size: 947, Value: 9334");
        }
    }
}