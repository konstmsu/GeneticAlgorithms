using FluentAssertions;
using GeneticAlgorithms.Knapsack;
using Xunit;
using static GeneticAlgorithms.Extensions;

namespace GeneticAlgorithms.Tests
{
    public class SimpleSolversTests
    {
        [Fact]
        public void SimpleBaseline()
        {
            SimpleSolvers.LargestValueFirst(Problem).Description.Should().Be("Size: 983, Value: 4717");
            SimpleSolvers.SmallestSizeFirst(Problem).Description.Should().Be("Size: 954, Value: 8188");
            SimpleSolvers.BestRatioFirst(Problem).Description.Should().Be("Size: 947, Value: 9334");
        }

        static readonly Problem Problem = new ProblemGenerator(42)
            .Generate(1000, 100, 1, 1000, 1, 1000);

        [Fact]
        public void RandomBaseline()
        {
            SimpleSolvers.Random(seed: 42, population: 100_000)(Problem).Description.Should()
                .Be("Size: 998, Value: 7901");
        }
    }
}