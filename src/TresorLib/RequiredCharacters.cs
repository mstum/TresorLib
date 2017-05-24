using System;
using System.Linq;

namespace TresorLib
{
    internal class RequiredCharacters
    {
        private TresorLinkedList<char[]> _characters;

        public int Count {  get { return _characters.Count; } }

        public RequiredCharacters()
        {
            _characters = new TresorLinkedList<char[]>();
        }

        public void Add(char[] requiredCharacters)
        {
            _characters.Add(requiredCharacters);
        }

        public char[] Pop(int index)
        {
            var result = _characters[index, true];
            return result;
        }

        public int GetEntropy()
        {
            int entropy = 0;

            int n = _characters.Count;
            for (var i = 0; i < n; i++)
            {
                entropy += (int)Math.Ceiling(Math.Log(i + 1) / Math.Log(2));
                entropy += (int)Math.Ceiling(Math.Log(_characters[i].Length) / Math.Log(2));
            }

            return entropy;
        }
    }
}
