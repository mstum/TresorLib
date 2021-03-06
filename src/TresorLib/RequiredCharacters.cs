﻿#region LICENSE
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
using System;
using System.Collections.Generic;

namespace TresorLib
{
    internal class RequiredCharacters
    {
        private List<CharacterArray> _characters;

        internal int Count { get { return _characters.Count; } }

        internal RequiredCharacters(int length)
        {
            _characters = new List<CharacterArray>(length);
        }

        internal void Add(CharacterArray requiredCharacters)
        {
            _characters.Add(requiredCharacters);
        }

        internal CharacterArray Pop(int index)
        {
            var result = _characters[index];
            _characters.RemoveAt(index);
            return result;
        }

        internal int GetEntropy()
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