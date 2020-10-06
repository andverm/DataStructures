using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class PriorityQueue
    {
        private int[] _items = new int[5];
        private int _queueLength;

        public void Insert(int item)
        {
            if (IsFull())
                ExpandSize();

            SortAndInsert(item);
        }

        public int Remove()
        {
            int item = _items[0];

            for (int i = 0; i < _queueLength - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_queueLength - 1] = 0;
            _queueLength--;
            return item;
        }

        public void Reverse(int length)
        {
            var reverser = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                reverser.Push(_items[i]);
            }

            int reverserCount = reverser.Count;

            for (int i = 0; i < reverserCount; i++)
            {
                _items[i] = reverser.Pop();
            }
        }

        public void Print()
        {
            Console.Write("[");

            for (var i = 0; i < _items.Length; i++)
            {
                if (i == _items.Length - 1)
                {
                    Console.Write($"{_items[i]}]");
                    break;
                }

                Console.Write($"{_items[i]}, ");
            }
        }

        private void SortAndInsert(int item)
        {
            int i = ShiftItemsAndReturnItemIndex(item);

            _items[i] = item;
            _queueLength++;
        }

        private int ShiftItemsAndReturnItemIndex(int item)
        {
            int i;

            for (i = _queueLength - 1; i >= 0; i--)
            {
                if (_items[i] > item)
                    _items[i + 1] = _items[i];
                else
                    break;
            }

            return i + 1;
        }

        private bool IsFull()
        {
            return _queueLength >= _items.Length;
        }

        private void ExpandSize()
        {
            var newArray = new int[_queueLength + 5];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
    }
}