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
    internal static class TresorImpl
    {
        internal static void Subtract(IList<char> charset, List<char> allowed, List<char> defaultAllowed)
        {
            if(charset == null || charset.Count == 0)
            {
                return;
            }
            if(allowed == null)
            {
                allowed = defaultAllowed;
            }

            for(int i = 0, n = charset.Count; i < n; i++)
            {
                var index = allowed.IndexOf(charset[i]);
                if(index >= 0)
                {
                    allowed.Splice(index, 1);
                }
            }
        }

        internal static void Require(IList<char> charset, int n, List<List<char>> required)
        {
            while (n-- != 0)
            {
                required.Add(charset.CopyList());
            }
        }
        
        internal static string Generate(TresorConfig config, string passphrase, string service)
        {
            var state = new TresorGenerationState(config, passphrase);

            if(state._required.Count > state._length)
            {
                throw new InvalidOperationException("Length too small to fit all required characters");
            }
            if(state._allowed.Count == 0)
            {
                throw new InvalidOperationException("No characters available to create a password");
            }

            var required = CopyRequired(state._required);
            var stream = new TresorStream(state._phrase, service, state.Entropy);
            var result = new StringBuilder(state._length);

            List<char> charset;
            char? previous;
            int index;
            int i;
            bool same;

            while(result.Length < state._length)
            {
                index = stream.Generate(required.Count);
                charset = required.Splice(index, 1)[0];
                previous = result.Length > 0 ? result[result.Length - 1] : (char?)null;
                i = state._repeat - 1;
                same = previous.HasValue && i >= 0;

                while (same && (i-- != 0))
                {
                    var sbIndex = result.Length + i - state._repeat;
                    same = same && (result[sbIndex] == previous);
                }
                if (same)
                {
                    charset = charset.CopyList();
                    if (previous.HasValue) { charset.RemoveAll(ac => ac == previous); }
                }

                index = stream.Generate(charset.Count);

                result.Append(charset[index]);
            }

            return result.ToString();
        }

        private static List<List<char>> CopyRequired(List<List<char>> required)
        {
            return required.Select(r => r.Select(rq => rq).ToList()).ToList();
        }


    }
}
