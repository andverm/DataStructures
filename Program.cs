using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var binaryTree = new BinaryTree();

            binaryTree.Insert(7);
            binaryTree.Insert(4);
            binaryTree.Insert(9);
            binaryTree.Insert(1);
            binaryTree.Insert(6);
            binaryTree.Insert(8);
            binaryTree.Insert(10);
            
            var binaryTreeTwo = new BinaryTree();

            binaryTreeTwo.Insert(7);
            binaryTreeTwo.Insert(4);
            binaryTreeTwo.Insert(9);
            binaryTreeTwo.Insert(1);
            binaryTreeTwo.Insert(6);
            binaryTreeTwo.Insert(8);
            binaryTreeTwo.Insert(10);

            Console.WriteLine(binaryTree.Equals(binaryTreeTwo));
            Console.WriteLine(binaryTree.IsBinarySearchTree());
        }
    }
}