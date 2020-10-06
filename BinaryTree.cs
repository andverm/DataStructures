using System;
using System.Collections.Generic;

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

        public void Depth(TreeNode root, int value)
        {
            Depth(_root, _root.Value, 0);
        }

        private int Depth(TreeNode root, int value, int depth)
        {
            if (root == null)
                return depth;

            depth++;

            if (root.Value == value)
                return depth;

            var depthLeft = Depth(root.LeftChild, value, depth);
            var depthRight = Depth(root.RightChild, value, depth);
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

            var depthLeft = Height(node.LeftChild);
            var depthRight = Height(node.RightChild);
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

        public int MaxValue()
        {
            return MaxValue(_root, Int32.MinValue);
        }

        private int MaxValue(TreeNode root, int maxValue)
        {
            if (root == null)
                return Int32.MinValue;

            if (root.Value > maxValue)
                maxValue = root.Value;

            var maxChildren = Math.Max(
                MaxValue(root.LeftChild, maxValue),
                MaxValue(root.RightChild, maxValue));

            return Math.Max(maxValue, maxChildren);
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

        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(_root, distance, list);

            return list;
        }

        private void GetNodesAtDistance(TreeNode root, int distance, List<int> list)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                list.Add(root.Value);
                return;
            }

            GetNodesAtDistance(root.LeftChild, distance - 1, list);
            GetNodesAtDistance(root.RightChild, distance - 1, list);
        }

        public int Size()
        {
            return Size(_root, 0);
        }

        private int Size(TreeNode root, int size)
        {
            if (root == null)
                return size;

            size++;

            size = Size(root.LeftChild, size);
            size = Size(root.RightChild, size);

            return size;
        }

        public int CountLeaves()
        {
            return CountLeaves(_root);
        }

        private int CountLeaves(TreeNode root)
        {
            if (root == null)
                return 0;

            if (IsLeafNode(root))
                return 1;

            var left = CountLeaves(root.LeftChild);
            var right = CountLeaves(root.RightChild);

            return left + right;
        }

        public List<int> TraverseLevelOrder()
        {
            var list = new List<int>();

            for (int i = 0; i < Height(); i++)
            {
                foreach (var item in GetNodesAtDistance(i))
                {
                    list.Add(item);
                }
            }

            return list;
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