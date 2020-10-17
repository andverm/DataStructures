using System.Collections.Generic;

namespace Data_Structures
{
    public class TrieNodeDictionary
    {
        public char Value { get; }
        public Dictionary<char, TrieNodeDictionary> Children { get; }
        public bool IsEndOfWord { get; private set; }

        public TrieNodeDictionary(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNodeDictionary>();
        }

        public bool HasChild(char character)
        {
            return Children.ContainsKey(character);
        }

        public void CreateChild(char character)
        {
            Children.Add(character, new TrieNodeDictionary(character));
        }

        public void SetAsEndOfWord()
        {
            IsEndOfWord = true;
        }

        public TrieNodeDictionary GetChild(char character)
        {
            if (!HasChild(character))
                return null;

            return Children[character];
        }
    }
}