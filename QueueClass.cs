using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class QueueClass
    {
        private int[] _queue = new int[10];
        private int _rear;
        private int _front;
        private int _count;

        public void Enqueue(int value)
        {
            if (_count >= _queue.Length)
            {
                IncreaseQueueSize();
            }

            _queue[_rear] = value;
            _rear = (_rear + 1) % _queue.Length;
            _count++;
        }

        public int Dequeue()
        {
            if (_front >= _rear)
                throw new InvalidOperationException();

            int value = Peek();
            _queue[_front] = 0;
            _front = (_front + 1) % _queue.Length;
            _count--;

            return value;
        }

        public int Peek()
        {
            return _queue[_front];
        }

        public bool IsEmpty()
        {
            return _rear == 0;
        }

        public void IsFull()
        {
        }

        public void Reverse()
        {
            if (_rear == 0)
                return;

            var stack = new Stack<int>();

            for (var i = _front; i < _rear; i++)
            {
                stack.Push(_queue[i]);
            }

            Clear();
            int stackCount = stack.Count;
            _rear = stackCount;

            for (int i = 0; i < stackCount; i++)
            {
                _queue[i] = stack.Pop();
            }
        }

        public void Clear()
        {
            _queue = new int[10];
            _rear = 0;
            _front = 0;
        }

        public void Print()
        {
            foreach (var item in _queue)
            {
                Console.WriteLine(item);
            }
        }

        private void IncreaseQueueSize()
        {
            int[] newQueue = new int[_queue.Length + 10];
            Array.Copy(_queue, newQueue, _queue.Length);
            _queue = newQueue;
        }
    }
}