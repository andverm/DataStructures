using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class QueueClassUsingStack
    {
        private readonly Stack<int> _stackOne = new Stack<int>();
        private readonly Stack<int> _stackTwo = new Stack<int>();

        public void Enqueue(int value)
        {
            _stackOne.Push(value);
        }

        public int? Dequeue()
        {
            if (IsEmpty())
                return null;

            if (_stackTwo.Count == 0)
                MoveStackOneToStackTwo();

            var value = _stackTwo.Pop();
            return value;
        }

        public int? Peek()
        {
            if (IsEmpty())
                return null;

            if (_stackTwo.Count == 0)
                MoveStackOneToStackTwo();

            var value = _stackTwo.Peek();
            return value;
        }

        public bool IsEmpty()
        {
            var count = _stackOne.Count + _stackTwo.Count;
            return count == 0;
        }

        public void Print()
        {
            foreach (var item in _stackTwo)
                Console.WriteLine(item);

            Console.WriteLine();

            foreach (var item in _stackOne)
                Console.WriteLine(item);
        }

        private void MoveStackOneToStackTwo()
        {
            while (_stackOne.Count > 0)
                _stackTwo.Push(_stackOne.Pop());
        }
    }
}