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
using System.Collections.Generic;

namespace TresorLib
{
    /// <summary>
    /// A bit similar to <see cref="CharacterArray"/>, this is a wrapper around a list from which "slices" can be extracted from.
    /// Calling Shift creates a new IntStream that looks at the same underlying list, while the original IntStream shifts forward and no longer
    /// has access to the beginning of the list.
    /// 
    /// The list that is passed in must not be accessed by anyone else anymore, since that will break the state of the IntStream.
    /// 
    /// The whole point is to avoid allocations since Shifting happens a lot in <see cref="TresorStream"/>.
    /// </summary>
    internal class IntStream
    {
        private readonly bool _isReadOnly;
        private IList<int> _masterList;
        private int _start;
        internal int Count { get; private set; }

        internal IntStream(IList<int> masterList = null)
        {
            _masterList = masterList ?? new List<int>();
            _start = 0;
            Count = _masterList.Count;
            _isReadOnly = false;
        }

        private IntStream(IList<int> masterList, int start, int count)
        {
            _masterList = masterList;
            _start = start;
            Count = count;
            _isReadOnly = true;
        }

        internal void Add(int value)
        {
            if(_isReadOnly)
            {
                throw new InvalidOperationException("This is a read-only chunk!");
            }

            _masterList.Add(value);
            Count++;
        } 

        internal IntStream Shift(int k)
        {
            var result = new IntStream(_masterList, _start, k);
            _start += k;
            Count -= k;
            return result;
        }

        internal int this[int index]
        {
            get
            {
                var ix = _start + index;
                var limit = _start + Count;
                if (ix >= limit)
                {
                    throw new IndexOutOfRangeException();
                }

                return _masterList[ix];
            }
        }
    }
}
