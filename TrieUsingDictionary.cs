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
                if (!currentRoot.HasChild(character))
                    currentRoot.CreateChild(character);

                currentRoot = currentRoot.GetChild(character);
            }

            currentRoot.SetAsEndOfWord();
        }
    }
}