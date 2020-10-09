namespace Data_Structures
{
    public class TrieNode
    {
        public static int _alphabetSize = 26;
        public char Value { get; }
        public TrieNode[] Children { get; }
        public bool IsEndOfWord { get; set; }

        public TrieNode(char value)
        {
            Value = value;
            Children = new TrieNode[_alphabetSize];
        }
    }
}