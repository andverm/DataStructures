namespace Data_Structures
{
    public class TreeNode
    {
        public int Value { get; private set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        public void IncreaseValue(int value = 1)
        {
            Value += value;
        }
    }
}