using System;

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

        public void Depth()
        {
            Console.WriteLine(Depth(_root));
        }

        private int Depth(TreeNode node)
        {
            if (node == null)
                return 0;

            var depthLeft = Depth(node.LeftChild);
            var depthRight = Depth(node.RightChild);
            return 1 + Math.Max(depthLeft, depthRight);
        }

        public int Height()
        {
            return Height(_root);
        }

        private int Height(TreeNode node)
        {
            if (node == null)
                return 0;

            if (node.LeftChild == null && node.RightChild == null)
                return 0;

            var depthLeft = Depth(node.LeftChild);
            var depthRight = Depth(node.RightChild);
            return 1 + Math.Max(depthLeft, depthRight);
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        private void TraversePreOrder(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);

            TraversePreOrder(node.LeftChild);
            TraversePreOrder(node.RightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }

        private void TraverseInOrder(TreeNode node)
        {
            if (node == null)
                return;

            TraverseInOrder(node.LeftChild);
            Console.WriteLine(node.Value);
            TraverseInOrder(node.RightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }

        private void TraversePostOrder(TreeNode node)
        {
            if (node == null)
                return;

            TraversePostOrder(node.LeftChild);
            TraversePostOrder(node.RightChild);
            Console.WriteLine(node.Value);
        }
    }
}