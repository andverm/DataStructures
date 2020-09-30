namespace Data_Structures
{
    public class ListNode
    {
        public int Value { get; }
        public ListNode Next { get; private set; }

        public ListNode(int value)
        {
            Value = value;
        }

        public void SetNext(ListNode node)
        {
            Next = node;
        }

        public void DeleteNext()
        {
            Next = null;
        }
    }
}