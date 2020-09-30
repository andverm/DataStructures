using System;

namespace Data_Structures
{
    public class LinkedListClass
    {
        public ListNode First { get; private set; }
        public ListNode Last { get; private set; }

        private int _count;

        public void AddFirst(int item)
        {
            var node = new ListNode(item);

            if (ListIsEmpty())
                Last = node;

            if (First != null)
                node.SetNext(First);

            First = node;
            _count++;
        }

        public void AddLast(int item)
        {
            var node = new ListNode(item);

            if (ListIsEmpty())
                First = node;

            Last?.SetNext(node);
            Last = node;
            _count++;
        }

        public void DeleteFirst()
        {
            if (ListIsEmpty())
                return;

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var second = First.Next;
                First.DeleteNext();
                First = second;
            }

            _count--;
        }

        public void DeleteLast()
        {
            if (ListIsEmpty())
                return;

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var newLast = FindNewLast();
                Last = newLast;
                Last.DeleteNext();
            }

            _count--;
        }

        private ListNode FindNewLast()
        {
            var currentNode = First;

            while (currentNode != null)
            {
                if (currentNode.Next == Last)
                    return currentNode;

                currentNode = currentNode.Next;
            }

            return null;
        }

        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(int value)
        {
            var currentNode = First;
            int index = 0;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return index;
                }
                else
                {
                    currentNode = currentNode.Next;
                    index++;
                }
            }

            return -1;
        }

        public int Length()
        {
            return _count;
        }

        public int[] ToArray()
        {
            int[] array = new int[_count];

            var currentNode = First;
            int index = 0;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }

            return array;
        }

        public void Reverse()
        {
            if (ListIsEmpty())
                return;

            var previous = First;
            var current = First.Next;

            while (current != null)
            {
                var next = current.Next;
                current.SetNext(previous);

                previous = current;
                current = next;
            }

            Last = First;
            First = previous;
            Last.DeleteNext();
        }

        public int GetKthFromTheEnd(int k)
        {
            if (ListIsEmpty())
                return -1;

            var a = First;
            var b = First;

            for (int i = 0; i < k - 1; i++)
            {
                if (b == Last)
                    break;

                b = b.Next;
            }

            while (b != Last)
            {
                a = a.Next;
                b = b.Next;
            }

            return a.Value;
        }

        public void Print()
        {
            var currentNode = First;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        private bool ListIsEmpty()
        {
            return First == null;
        }
    }
}