using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class ArrayClass
    {
        private int[] _items;
        private int _numberOfItems;

        public ArrayClass(int length)
        {
            _items = new int[length];
        }

        public void Insert(int item)
        {
            if (_numberOfItems >= _items.Length)
                ExpandSize();

            _items[_numberOfItems] = item;
            _numberOfItems++;
        }

        public void InsertAt(int item, int index)
        {
            if (index < 0)
                return;

            if (_numberOfItems >= _items.Length)
                ExpandSize();

            if (index > _numberOfItems)
                index = _numberOfItems;

            for (int i = _numberOfItems; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            _numberOfItems++;
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _numberOfItems; i++)
            {
                if (_items[i] == item)
                    return i;
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index >= _numberOfItems || index < 0)
                return;

            for (int i = index; i < _items.Length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _numberOfItems--;
        }

        public void Print()
        {
            for (var i = 0; i < _numberOfItems; i++)
            {
                var item = _items[i];
                Console.WriteLine(item);
            }
        }

        public int Max()
        {
            int max = 0;

            for (int i = 0; i < _numberOfItems; i++)
            {
                if (_items[i] > max)
                    max = _items[i];
            }

            return max;
        }

        public int[] Intersect(int[] inputArray)
        {
            var commonNumbers = new List<int>();

            foreach (var t in inputArray)
            {
                foreach (var item in _items)
                {
                    if (t == item)
                    {
                        if (commonNumbers.Contains(t) == false)
                            commonNumbers.Add(t);
                    }
                }
            }

            return commonNumbers.ToArray();
        }

        public void Reverse()
        {
            var reversedItems = new List<int>();

            for (int i = _numberOfItems; i > 0; i--)
            {
                reversedItems.Add(_items[i - 1]);
            }

            _items = reversedItems.ToArray();
        }

        private void ExpandSize(int amount = 1)
        {
            var newArray = new int[_numberOfItems + amount];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
    }
}