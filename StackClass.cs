using System;

namespace Data_Structures
{
    public class StackClass
    {
        private int[] _stack = new int[10];
        private int _stackLength;

        public void Push(int value)
        {
            if (_stackLength >= _stack.Length)
                IncreaseStackSize();

            _stack[_stackLength] = value;
            _stackLength++;
        }

        public int? Pop()
        {
            if (_stackLength == 0)
                return null;

            var value = Peek();
            _stackLength--;
            return value;
        }

        public int? Peek()
        {
            if (_stackLength == 0)
                return null;

            int value = _stack[_stackLength - 1];
            return value;
        }

        public int? Min()
        {
            if (_stackLength == 0)
                return null;

            int smallestValue = Int32.MaxValue;

            for (int i = 0; i < _stackLength; i++)
            {
                if (_stack[i] < smallestValue)
                    smallestValue = _stack[i];
            }

            return smallestValue;
        }

        public bool IsEmpty()
        {
            return _stackLength == 0;
        }

        public void Clear()
        {
            _stack = new int[10];
            _stackLength = 0;
        }

        public void Print()
        {
            for (var i = _stackLength - 1; i >= 0; i--)
            {
                var item = _stack[i];
                Console.WriteLine(item);
            }
        }

        private void IncreaseStackSize()
        {
            int[] newStack = new int[_stackLength + 10];
            Array.Copy(_stack, newStack, _stack.Length);
            _stack = newStack;
        }
    }
}