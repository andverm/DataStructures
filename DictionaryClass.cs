using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class DictionaryClass
    {
        private readonly LinkedList<KeyValue>[] _mainList = new LinkedList<KeyValue>[7];

        public void Add(int key, string value)
        {
            var subList = GetOrCreateSubList(key);
            var item = LookUpItemBasedOnKey(key, subList);

            if (item != null)
            {
                item.UpdateValue(value);
                return;
            }

            var newitem = new KeyValue(key, value);
            subList.AddLast(newitem);
        }

        public string Get(int key)
        {
            var subList = GetOrCreateSubList(key);
            var item = LookUpItemBasedOnKey(key, subList);

            if (item != null)
                return item.Value;

            return "Invalid Key";
        }

        public void Remove(int key)
        {
            var subList = GetOrCreateSubList(key);
            var item = LookUpItemBasedOnKey(key, subList);

            if (item != null)
                subList.Remove(item);
        }

        public void Print()
        {
            foreach (var subList in _mainList)
            {
                if (subList == null)
                {
                    Console.WriteLine("[ , ]");
                    continue;
                }

                foreach (var item in subList)
                {
                    Console.Write($"[{item.Key}, {item.Value}] ");
                }

                Console.WriteLine();
            }
        }

        private int GenerateIndex(int key)
        {
            var index = key % _mainList.Length;
            return index;
        }

        private LinkedList<KeyValue> GetOrCreateSubList(int key)
        {
            var index = GenerateIndex(key);
            var subList = _mainList[index];

            if (subList != null)
                return subList;

            return _mainList[index] = new LinkedList<KeyValue>();
        }

        private KeyValue LookUpItemBasedOnKey(int key, LinkedList<KeyValue> subList)
        {
            if (subList != null)
            {
                foreach (var item in subList)
                {
                    if (item.Key == key)
                        return item;
                }
            }

            return null;
        }
    }
}