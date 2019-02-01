using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithms
{
    public static class Sugar
    {
        public static IReadOnlyList<int> Til(int max) =>
            Enumerable.Range(0, max).ToList();
    }
}