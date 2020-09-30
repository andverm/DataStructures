using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class CharFinder
    {
        private readonly Dictionary<char, int> _dictionary = new Dictionary<char, int>();
        private readonly HashSet<char> _hashSet = new HashSet<char>();

        public char FindFirstUniqueChar(string input)
        {
            _dictionary.Clear();

            foreach (var letter in input)
            {
                if (_dictionary.ContainsKey(letter))
                    _dictionary[letter]++;
                else
                    _dictionary.Add(letter, 1);
            }

            var firstUnique = _dictionary
                .FirstOrDefault(t => t.Value == 1).Key;

            return firstUnique;
        }

        public char FindFirstRepeatedChar(string input)
        {
            _hashSet.Clear();

            foreach (var letter in input)
            {
                if (_hashSet.Contains(letter))
                    return letter;

                _hashSet.Add(letter);
            }

            return Char.MinValue;
        }

        public KeyValuePair<char, int> FindMostRepeatedChar(string input)
        {
            _dictionary.Clear();
            char whiteSpace = ' ';

            foreach (var letter in input)
            {
                if (letter == whiteSpace)
                    continue;

                if (_dictionary.ContainsKey(letter))
                {
                    _dictionary[letter]++;
                    continue;
                }

                _dictionary.Add(letter, 1);
            }

            var mostRepeated = _dictionary
                .OrderByDescending(t => t.Value)
                .FirstOrDefault();

            return mostRepeated;
        }
    }
}