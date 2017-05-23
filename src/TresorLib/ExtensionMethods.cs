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
using System.Linq;
using System.Text;

namespace TresorLib
{
    internal static class ExtensionMethods
    {
        internal static List<char> CopyList(this IEnumerable<char> input)
        {
            return input.Select(c => c).ToList();
        }

        internal static string ToHexString(this IEnumerable<byte> ba)
        {
            StringBuilder hex = new StringBuilder(64);
            foreach (byte b in ba ?? Enumerable.Empty<byte>())
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <summary>
        /// (Partial) port of JavaScript's Array.prototype.splice(), just enough to support what I need here
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="deleteCount"></param>
        /// <returns></returns>
        internal static IList<T> Splice<T>(this IList<T> input, int start, int? deleteCount = null)
        {
            if (start < 0)
            {
                // JS's array.splice supports negative index:
                // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/splice
                // Index at which to start changing the array (with origin 0). If greater than the length of the array,
                // actual starting index will be set to the length of the array. If negative, will begin that many elements
                // from the end of the array (with origin 1).

                throw new ArgumentOutOfRangeException(nameof(start), nameof(start) + " must be positive.");
            }

            if (deleteCount.HasValue && deleteCount.Value < 0)
            {
                deleteCount = null;
            }

            var result = new List<T>();
            if (input == null || start > (input.Count - 1))
            {
                return result;
            }

            int countTowards = deleteCount ?? (start + 1);
            for (int i = 0; i < countTowards; i++)
            {
                result.Add(input[start]);
                input.RemoveAt(start);
            }

            return result;
        }
    }
}
