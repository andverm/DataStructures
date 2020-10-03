using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var avlTree = new AvlTree();

            avlTree.Insert(7);
            avlTree.Insert(4);
            avlTree.Insert(9);
            avlTree.Insert(1);
            avlTree.Insert(6);
            avlTree.Insert(8);
            avlTree.Insert(10);

            Console.WriteLine(avlTree.Height());
        }
    }
}