using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class FormatChecker
    {
        private readonly Stack<char> _unbalancedChars = new Stack<char>();
        private readonly char[] _openingChars = new char[] { '(', '[', '<', '{' };
        private readonly char[] _closingChars = new char[] { ')', ']', '>', '}' };

        public bool IsBalanced(string input)
        {
            _unbalancedChars.Clear();

            foreach (var character in input)
            {
                if (CharacterIsOpening(character))
                    _unbalancedChars.Push(character);

                if (CharacterIsClosing(character))
                {
                    if (_unbalancedChars.Count == 0)
                        return false;

                    var top = _unbalancedChars.Pop();

                    if (!CharacterMatchesLastOpening(top, character))
                        return false;
                }
            }

            return _unbalancedChars.Count == 0;
        }

        private bool CharacterMatchesLastOpening(char opening, char closing)
        {
            int openingIndex = Array.IndexOf(_openingChars, opening);
            int closingIndex = Array.IndexOf(_closingChars, closing); 

            return openingIndex == closingIndex;
        }

        private bool CharacterIsOpening(char character) => _openingChars.Contains(character);

        private bool CharacterIsClosing(char character) => _closingChars.Contains(character);
    }
}