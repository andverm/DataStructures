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
                return -1;

            if (IsLeafNode(node))
                return 0;

            var depthLeft = Depth(node.LeftChild);
            var depthRight = Depth(node.RightChild);
            return 1 + Math.Max(depthLeft, depthRight);
        }

        public int MinValue()
        {
            // return MinValue(_root);

            var current = _root;

            if (current == null)
                return -1;

            while (current.LeftChild != null)
                current = current.LeftChild;

            return current.Value;
        }

        private int MinValue(TreeNode node)
        {
            if (node == null)
                return -1;

            if (IsLeafNode(node))
                return node.Value;

            var minLeft = MinValue(node.LeftChild);
            var minRight = MinValue(node.RightChild);

            int minChild;

            if (minLeft == -1)
                minChild = minRight;
            else if (minRight == -1)
                minChild = minLeft;
            else
                minChild = Math.Min(minLeft, minRight);
            return Math.Min(minChild, node.Value);
        }

        public bool Equals(BinaryTree tree)
        {
            if (tree == null)
                return false;

            return Equals(_root, tree._root);
        }

        private bool Equals(TreeNode first, TreeNode second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.Value == second.Value
                       && Equals(first.LeftChild, second.LeftChild)
                       && Equals(first.RightChild, second.RightChild);

            return false;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsBinarySearchTree(TreeNode node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Value < min || node.Value > max)
                return false;

            return IsBinarySearchTree(node.LeftChild, min, node.Value - 1)
                   && IsBinarySearchTree(node.RightChild, node.Value + 1, max);
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

        private bool IsLeafNode(TreeNode node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }
    }
}