namespace Data_Structures
{
    public class BinaryTree
    {
        private TreeNode _root;

        public void Insert(int value)
        {
            var node = new TreeNode(value);

            if (_root == null)
            {
                _root = node;
                return;
            }

            var currentNode = _root;

            while (true)
            {
                if (value < currentNode.Value)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = node;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = node;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var currentNode = _root;

            while (currentNode != null)
            {
                if (value < currentNode.Value)
                    currentNode = currentNode.LeftChild;
                else if (value > currentNode.Value)
                    currentNode = currentNode.RightChild;
                else
                    return true;
            }

            return false;
        }
    }
}