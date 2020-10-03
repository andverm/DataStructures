using System;

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

            if (IsLeftHeavy(root))
            {
                Console.WriteLine("left");
            }
            else if (IsRightHeavy(root))
            {
                Console.WriteLine("right");
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
    }
}