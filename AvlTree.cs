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
            if (_root == null)
                return 0;

            return Size(_root, 1);
        }

        private int Size(TreeNode root, int size)
        {
            if (root == null)
                return size;

            size++;

            var sizeLeft = Size(root.LeftChild, size);
            var sizeRight = Size(root.RightChild, size);

            return Math.Max(sizeLeft, sizeRight);
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