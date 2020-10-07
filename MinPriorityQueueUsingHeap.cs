namespace Data_Structures
{
    public class MinPriorityQueueUsingHeap
    {
        private readonly MinHeap _minHeap = new MinHeap();

        public void Add(string value, int priority)
        {
            _minHeap.Insert(priority, value);
        }

        public string Remove()
        {
            return _minHeap.Remove();
        }
    }
}