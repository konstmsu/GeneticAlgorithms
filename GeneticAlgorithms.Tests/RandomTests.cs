using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GeneticAlgorithms.Tests
{
    public class RandomTests
    {
        [Fact]
        public void ShuffledTests()
        {
            var random = new Random();
            var sequence = Sugar.Til(10).ToList();
            var permutation = sequence.ToArray();
            random.Shuffle(permutation);
            permutation.Should().BeEquivalentTo(sequence);
            permutation.Should().NotEqual(sequence);
        }
    }
}