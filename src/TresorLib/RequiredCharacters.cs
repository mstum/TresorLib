using System;
using System.Collections.Generic;

namespace TresorLib
{
    internal class RequiredCharacters
    {
        private List<CharacterArray> _characters;

        public int Count {  get { return _characters.Count; } }

        public RequiredCharacters(int length)
        {
            _characters = new List<CharacterArray>(length);
        }

        public void Add(CharacterArray requiredCharacters)
        {
            _characters.Add(requiredCharacters);
        }

        public CharacterArray Pop(int index)
        {
            var result = _characters[index];
            _characters.RemoveAt(index);
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
