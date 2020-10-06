using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class AvlTree
    {
        private TreeNode _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        private TreeNode Insert(TreeNode root, int value)
        {
            if (root == null)
                return new TreeNode(value);

            if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);
            else
                root.RightChild = Insert(root.RightChild, value);

            root.SetHeight(Height(root));

            return Balance(root);
        }

        private TreeNode Balance(TreeNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.LeftChild) < 0)
                    root.LeftChild = RotateLeft(root.LeftChild);

                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.RightChild) > 0)
                    root.RightChild = RotateRight(root.RightChild);

                return RotateLeft(root);
            }

            return root;
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

            var heightLeft = Height(node.LeftChild);
            var heightRight = Height(node.RightChild);
            return 1 + Math.Max(heightLeft, heightRight);
        }

        private bool IsLeafNode(TreeNode node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        private bool IsLeftHeavy(TreeNode node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(TreeNode node)
        {
            return BalanceFactor(node) < -1;
        }

        private int BalanceFactor(TreeNode node)
        {
            if (node == null)
                return 0;

            return Height(node.LeftChild) - Height(node.RightChild);
        }

        public int Size()
        {
            return Size(_root);
        }

        private int Size(TreeNode root)
        {
            if (root == null)
                return 0;

            var sizeLeft = Size(root.LeftChild);
            var sizeRight = Size(root.RightChild);

            return 1 + sizeLeft + sizeRight;
        }

        public List<TreeNode> GetLeaves()
        {
            var leaves = new List<TreeNode>();
            GetLeaves(_root, leaves);
            return leaves;
        }

        private void GetLeaves(TreeNode root, List<TreeNode> leaves)
        {
            if (root == null)
                return;

            if (IsLeafNode(root))
            {
                leaves.Add(root);
                return;
            }

            GetLeaves(root.LeftChild, leaves);
            GetLeaves(root.RightChild, leaves);
        }

        private int DepthOfNode(TreeNode node)
        {
            return DepthOfNode(_root, node.Value, 0);
        }

        private int DepthOfNode(TreeNode root, int value, int depth)
        {
            if (root == null)
                return depth;

            if (root.Value == value)
                return depth;

            depth++;

            var depthLeft = DepthOfNode(root.LeftChild, value, depth);
            var depthRight = DepthOfNode(root.RightChild, value, depth);
            return Math.Min(depthLeft, depthRight);
        }

        public bool IsPerfect()
        {
            var leaves = GetLeaves();

            foreach (var leaf in leaves)
            {
                Console.WriteLine(leaf.Value);
            }

            var size = Size();
            var maxCount = GetMaxCountAtCurrentHeight();

            Console.WriteLine($"count: {size}");
            Console.WriteLine($"capacity: {maxCount}");

            return maxCount == size;
        }

        private int GetMaxCountAtCurrentHeight()
        {
            if (_root == null)
                return 0;

            var height = _root.Height;
            var maxCount = 2;

            while (height > 0)
            {
                maxCount *= 2;
                height--;
            }

            return maxCount - 1;
        }

        private TreeNode RotateLeft(TreeNode root)
        {
            var newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            root.SetHeight(Height(root));
            newRoot.SetHeight(Height(newRoot));

            return newRoot;
        }

        private TreeNode RotateRight(TreeNode root)
        {
            var newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            root.SetHeight(Height(root));
            newRoot.SetHeight(Height(newRoot));

            return newRoot;
        }
    }
}