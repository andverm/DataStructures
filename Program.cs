using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            int[] numbers = new[] { 5, 3, 8, 4, 1, 2, 9};

            Heapifier.Heapify(numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}