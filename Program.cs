using System;

namespace Data_Structures
{
    public static class Program
    {
        public static void Main()
        {
            var trie = new TrieUsingDictionary();

            trie.Insert("abc");
            trie.Insert("abde");

            Console.WriteLine();
        }
    }
}