namespace Data_Structures
{
    public class Heapifier
    {
        public static void Heapify(int[] array)
        {
            var lastParentIndex = array.Length / 2 - 1;

            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(array, i);
            }
        }

        private static void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftChildIndex = index * 2 + 1;
            if (leftChildIndex < array.Length && array[leftChildIndex] > array[largerIndex])
                largerIndex = leftChildIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public static int? GetKthLargestNumber(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                return null;

            var heap = new Heap();
            foreach (var number in array)
            {
                heap.Insert(number);
            }

            while (k > 1)
            {
                heap.Remove();
                k--;
            }

            return heap.Remove();
        }
    }
}