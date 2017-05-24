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
    /// <summary>
    /// This CharacterArray wraps an array that can be shared and "virtualizes" Remove-operations.
    /// This causes Indexer performance to not be O(1), but it avoids constantly copying some char arrays
    /// </summary>
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
                if (_characters[i] == c && !_removed[i])
                {
                    _removed.Set(i, true);
                    Length--;
                }
            }
        }

        internal void Remove(HashSet<char> chars)
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                if (!_removed[i] && chars.Contains(_characters[i]))
                {
                    _removed.Set(i, true);
                    Length--;
                }
            }
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

        internal void EnumerateIntoHashSet(HashSet<char> set)
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                if (!_removed[i])
                {
                    set.Add(_characters[i]);
                }
            }
        }
    }
}