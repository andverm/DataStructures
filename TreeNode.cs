namespace Data_Structures
{
    public class TreeNode
    {
        public int Value { get; }
        public int Height { get; private set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        public void SetHeight(int height)
        {
            Height = height;
        }
    }
}