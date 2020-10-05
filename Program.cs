using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var avlTree = new AvlTree();

            avlTree.Insert(10);
            avlTree.Insert(30);
            avlTree.Insert(20);
            avlTree.Insert(40);
        }
    }
}