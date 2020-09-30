using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class StringReverser
    {
        private readonly Stack<char> _characters = new Stack<char>();
        readonly StringBuilder _reversedInput = new StringBuilder();

        public string Reverse(string input)
        {
            if (input == null)
                throw new ArgumentException();

            _reversedInput.Clear();

            foreach (var character in input)
            {
                _characters.Push(character);
            }

            while (_characters.Count > 0)
            {
                _reversedInput.Append(_characters.Pop());
            }

            return _reversedInput.ToString();
        }
    }
}