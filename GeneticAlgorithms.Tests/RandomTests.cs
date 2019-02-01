using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GeneticAlgorithms.Tests
{
    public class RandomTests
    {
        [Fact]
        public void PermutationTests()
        {
            var random = new Random();
            var count = 10;
            var permutation = random.Permutation(count);
            var sequence = Enumerable.Range(0, count).ToList();
            permutation.Should().BeEquivalentTo(sequence);
            permutation.Should().NotEqual(sequence);
        }
        
        [Fact]
        public void ShuffledTests()
        {
            var random = new Random();
            var sequence = Sugar.Til(10);
            var permutation = random.Shuffled(sequence);
            permutation.Should().BeEquivalentTo(sequence);
            permutation.Should().NotEqual(sequence);
        }
    }
}