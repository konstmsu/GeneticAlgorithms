namespace GeneticAlgorithms.Knapsack
{
    public class Item
    {
        public readonly int Size;
        public readonly int Value;

        public Item(int size, int value)
        {
            Size = size;
            Value = value;
        }
    }
}