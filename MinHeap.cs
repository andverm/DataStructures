using System;

namespace Data_Structures
{
    public class MinHeap
    {
        private KeyValue[] _items = new KeyValue[10];
        private int _size;

        public void Insert(int key, string value)
        {
            if (IsFull())
                return;

            var keyValue = new KeyValue(key, value);

            _items[_size] = keyValue;
            _size++;

            Heapify();
        }

        private void Heapify()
        {
            var lastParentIndex = _size / 2 - 1;

            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        private void Heapify(int index)
        {
            var largerIndex = index;

            var leftChildIndex = index * 2 + 1;
            if (leftChildIndex < _size && _items[leftChildIndex].Key < _items[largerIndex].Key)
                largerIndex = leftChildIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < _size && _items[rightIndex].Key < _items[largerIndex].Key)
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(index, largerIndex);
            Heapify(largerIndex);
        }

        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }

        private bool IsFull()
        {
            return _size >= _items.Length;
        }

        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"[{_items[i].Key}, {_items[i].Value}]");
            }
        }
    }
}