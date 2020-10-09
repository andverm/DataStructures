using System.Collections.Generic;

namespace Data_Structures
{
    public class TrieNodeDictionary
    {
        public char Value { get; }
        public Dictionary<char, TrieNodeDictionary> Children { get; }
        public bool IsEndOfWord { get; set; }

        public TrieNodeDictionary(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNodeDictionary>();
        }
    }
}