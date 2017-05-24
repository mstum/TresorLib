#region LICENSE
/* Copyright (C) 2017 Michael Stum <opensource@stum.de>

Adapted from Vault, copyright (C) 2012-2014 James Coglan - https://github.com/jcoglan/vault

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU General Public License as published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.
If not, see http://www.gnu.org/licenses/. */
#endregion
using System.Collections;
using System.Collections.Generic;

namespace TresorLib
{
    internal class CharacterArray
    {
        private readonly char[] _characters;
        private readonly BitArray _removed;

        internal CharacterArray(char[] characters)
        {
            _characters = characters;
            Length = characters.Length;
            _removed = new BitArray(characters.Length);
        }

        private CharacterArray(char[] characters, BitArray removed, int length)
        {
            _characters = characters;
            Length = length;
            _removed = new BitArray(removed);
        }

        internal int Length { get; private set; }

        internal void Remove(char c)
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                if(_characters[i] == c && !_removed[i])
                {
                    _removed.Set(i, true);
                    Length--;
                }
            }
        }

        internal void Remove(IEnumerable<char> chars)
        {
            var hs = new HashSet<char>(chars);
            for (int i = 0; i < _characters.Length; i++)
            {
                if (!_removed[i] && hs.Contains(_characters[i]))
                {
                    _removed.Set(i, true);
                    Length--;
                }
            }
        }

        internal void Remove(CharacterArray ca)
        {
            Remove(ca.Enumerate());
        }

        internal char this[int index]
        {
            get
            {
                var ix = index;

                for (int i = 0; i <= index; i++)
                {
                    if (_removed[i])
                    {
                        ix++;
                    }
                }

                return _characters[ix];
            }
        }

        internal CharacterArray CheapClone()
        {
            return new CharacterArray(_characters, _removed, Length);
        }

        internal IEnumerable<char> Enumerate()
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                if(!_removed[i])
                {
                    yield return _characters[i];
                }
            }
        }
    }
}
