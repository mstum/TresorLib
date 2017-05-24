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
using System.Linq;

namespace TresorLib
{
    public static class Tresor
    {
        public static string GeneratePassword(string serviceName, string passphrase, TresorConfig config)
        {
            var state = new TresorGenerationState(config, passphrase);

            if (state._required.Count > state._length)
            {
                throw new InvalidOperationException("Length too small to fit all required characters");
            }
            if (state._allowed.Length == 0)
            {
                throw new InvalidOperationException("No characters available to create a password");
            }

            var required = state._required;
            var stream = new TresorStream(state._phrase, serviceName, state.Entropy);
            var result = new char[state._length];
            var resultIx = 0;

            char? previous = null;

            while (resultIx < state._length)
            {
                // Get candidate pool for current character
                // the same index can be generated multiple times
                var index = stream.Generate(required.Count);
                var charset = required.Pop(index).ToList();

                var i = state.MaxRepeat - 1;
                var same = previous.HasValue && i >= 0;

                // Check if we've hit the limit?
                while (same && (i-- != 0))
                {
                    var sbIndex = resultIx + i - state.MaxRepeat;
                    same = same && (result[sbIndex] == previous);
                }

                // If we've hit the limit, remove character from charset
                if (same)
                {
                    if (previous.HasValue)
                    {
                        while (charset.Contains(previous.Value))
                        {
                            charset.Remove(previous.Value);
                        }
                    }
                }

                var charIndex = stream.Generate(charset.Count);

                result[resultIx] = charset[charIndex];
                previous = charset[charIndex];
                resultIx++;
            }

            return new string(result);
        }
    }
}
