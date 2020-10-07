using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {

            var heap = new MinHeap();

            heap.Insert(4, "gem");
            heap.Insert(7, "boat");
            heap.Insert(3, "car");
            heap.Insert(12, "broom");
            heap.Insert(76, "cat");
            heap.Insert(1, "dog");
            heap.Insert(8, "food");
            heap.Insert(8976, "skin");
            heap.Insert(21, "chair");
            heap.Insert(576, "door");

            heap.Print();

        }
    }
}