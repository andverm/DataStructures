namespace Data_Structures
{
    public class Trie
    {
        private readonly TrieNode _root = new TrieNode(' ');

        public void InsertAlternate(string word)
        {
            var currentRoot = _root;

            foreach (var character in word)
            {
                var index = GenerateIndex(character);

                if (currentRoot.Children[index] == null)
                    currentRoot.Children[index] = new TrieNode(character);

                currentRoot = currentRoot.Children[index];
            }

            currentRoot.IsEndOfWord = true;
        }

        public void Insert(string word)
        {
            var currentRoot = _root;

            foreach (var character in word)
            {
                var childNode = GetOrCreateChild(currentRoot, character);
                currentRoot = childNode;
            }

            currentRoot.IsEndOfWord = true;
        }

        private TrieNode GetOrCreateChild(TrieNode root, char character)
        {
            var index = GenerateIndex(character);

            if (root.Children[index] != null)
                return root.Children[index];

            return root.Children[index] = new TrieNode(character);
        }

        private int GenerateIndex(char character)
        {
            return character - 'a';
        }
    }
}