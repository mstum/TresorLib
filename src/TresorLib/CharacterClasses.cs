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
using System.Linq;

namespace TresorLib
{
    internal static class CharacterClasses
    {
        internal static readonly char[] Lowercase;
        internal static readonly char[] Uppercase;
        internal static readonly char[] Numbers;
        internal static readonly char[] Space;
        internal static readonly char[] Dashes;
        internal static readonly char[] Symbols;
        internal static readonly char[] All;

        static CharacterClasses()
        {
            Lowercase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Uppercase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Space = new char[] { ' ' };
            Dashes = new char[] { '-', '_' };
            Symbols = new char[] { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '{', '|', '}', '~', '-', '_' };

            All = Lowercase.Concat(Uppercase).Concat(Numbers).Concat(Space).Concat(Symbols).ToArray();
        }
    }
}
