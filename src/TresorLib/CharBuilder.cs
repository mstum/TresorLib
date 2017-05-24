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
using System;

namespace TresorLib
{
    internal class CharBuilder
    {
        private readonly char[] _chars;
        internal int Length { get; private set; }
        internal char? LastAppendedChar { get; private set; }
        private int _repetitionCount;

        internal CharBuilder(int length)
        {
            _chars = new char[length];
            Length = 0;
            LastAppendedChar = null;
        }

        internal void Add(char c)
        {
            _chars[Length] = c;

            if (c == LastAppendedChar)
            {
                _repetitionCount++;
            }
            else
            {
                _repetitionCount = 1;
            }

            LastAppendedChar = c;
            Length++;
        }

        internal char this[int index]
        {
            get
            {
                if (index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return _chars[index];
            }
        }

        /// <summary>
        /// Check if we have appended the same character maxRepeat times already
        /// </summary>
        /// <param name="maxRepeat"></param>
        /// <returns></returns>
        internal bool HasReachedMaxRepeatLimit(int maxRepeat)
        {
            return maxRepeat > 0 && _repetitionCount >= maxRepeat;
        }

        public override string ToString()
        {
            return new string(_chars);
        }
    }
}
