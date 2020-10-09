namespace Data_Structures
{
    public class TrieUsingDictionary
    {
        private readonly TrieNodeDictionary _root = new TrieNodeDictionary(' ');

        public void Insert(string word)
        {
            var currentRoot = _root;

            foreach (var character in word)
            {
                if (!currentRoot.Children.ContainsKey(character))
                    currentRoot.Children.Add(character, new TrieNodeDictionary(character));

                currentRoot = currentRoot.Children[character];
            }

            currentRoot.IsEndOfWord = true;
        }
    }
}