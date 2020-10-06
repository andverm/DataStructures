namespace Data_Structures
{
    public class PriorityQueueUsingHeap
    {
        private Heap _heap = new Heap();

        public void Add(int value)
        {
            _heap.Insert(value);
        }

        public int Remove()
        {
            return _heap.Remove();
        }
        
        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }
    }
}