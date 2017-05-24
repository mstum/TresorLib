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
using System.Collections.ObjectModel;

namespace TresorLib
{
    internal struct TresorGenerationState
    {
        internal string _phrase;
        internal int _length;
        internal int MaxRepeat;
        internal List<char> _allowed;
        internal LinkedList<List<char>> _required;
        internal readonly int Entropy;

        private static int GenerateEntropy(LinkedList<List<char>> required)
        {
            int entropy = 0;

            if (required != null)
            {
                int n = required.Count;
                for (var i = 0; i < n; i++)
                {
                    entropy += (int)Math.Ceiling(Math.Log(i + 1) / Math.Log(2));
                    entropy += (int)Math.Ceiling(Math.Log(required.GetAtIndex(i).Count) / Math.Log(2));
                }
            }
            return entropy;
        }

        private static void Subtract(IList<char> charset, List<char> allowed)
        {
            if (charset == null || charset.Count == 0)
            {
                return;
            }

            allowed.RemoveAll(c => charset.Contains(c));
        }

        private static void Require(IList<char> charset, int n, LinkedList<List<char>> required)
        {
            while (n-- != 0)
            {
                required.AddLast(CopyList(charset));
            }
        }

        private static List<char> CopyList(IList<char> input)
        {
            var result = new List<char>(input.Count);
            result.AddRange(input);
            return result;
        }

        public TresorGenerationState(TresorConfig config, string passphrase)
        {
            _phrase = passphrase ?? string.Empty;
            _length = config.PasswordLength;
            MaxRepeat = config.MaxRepetition;

            var allowed = CopyList(CharacterClasses.All);
            var required = new LinkedList<List<char>>();

            var accessors = new List<Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>>
                {
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.LowercaseLetters, () => CharacterClasses.Lowercase),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.UppercaseLetters, () => CharacterClasses.Uppercase),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.Numbers, () => CharacterClasses.Numbers),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.Space, () => CharacterClasses.Space),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.Dash, () => CharacterClasses.Dashes),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<ReadOnlyCollection<char>>>(() => config.Symbols, () => CharacterClasses.Symbols)
                };

            foreach (var acc in accessors)
            {
                var mode = acc.Item1();
                if (mode == TresorConfig.AllowedMode.Forbidden)
                {
                    Subtract(acc.Item2(), allowed);
                }
                else if (mode == TresorConfig.AllowedMode.Required)
                {
                    Require(acc.Item2(), config.RequiredCount, required);
                }
            }

            var n = config.PasswordLength - required.Count;
            while (--n >= 0)
            {
                required.AddLast(CopyList(allowed));
            }

            _required = required;
            _allowed = allowed;

            Entropy = GenerateEntropy(_required);
        }
    }
}
