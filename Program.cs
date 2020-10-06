using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var heap = new Heap();

            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(17);
            heap.Insert(4);
            heap.Insert(22);

            Console.WriteLine();
            heap.Print();

            heap.Remove();

            Console.WriteLine();
            heap.Print();
        }
    }
}