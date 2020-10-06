using System;

namespace Data_Structures
{
    public class Heap
    {
        private int[] _items = new int[7];
        private int _size;

        public void Insert(int value)
        {
            if (IsFull())
                return;

            _items[_size] = value;
            _size++;

            BubbleUp();
        }

        public void Remove()
        {
            _size--;
            _items[0] = _items[_size];

            BubbleDown();
        }

        private void BubbleUp()
        {
            var index = _size - 1;

            while (index > 0 && _items[index] > _items[GetParentIndex(index)])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;

            while (_items[index] < GetLeftChild(index) ||
                   _items[index] < GetRightChild(index))
            {
                var validParent = GetValidParent(index);
                var parentIndex = Array.IndexOf(_items, validParent);

                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private int GetValidParent(int index)
        {
            return Math.Max(GetLeftChild(index), GetRightChild(index));
        }

        private int GetLeftChild(int index)
        {
            return _items[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return _items[GetRightChildIndex(index)];
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetParentIndex(int index)
        {
            var substractionValue = index % 2;

            if (substractionValue == 0)
                substractionValue += 2;

            return (index - substractionValue) / 2;
        }

        public bool IsFull()
        {
            return _size >= _items.Length;
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = _items[index];
            _items[index] = _items[parentIndex];
            _items[parentIndex] = temp;
        }

        public void Print()
        {
            for (var index = 0; index < _size; index++)
            {
                var item = _items[index];
                Console.WriteLine(item);
            }
        }
    }
}