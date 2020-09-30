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
            
            var findTest = binaryTree.Find(2);

            Console.WriteLine(findTest);
        }
    }
}