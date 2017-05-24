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
        internal char[] _allowed;
        internal RequiredCharacters _required;
        internal readonly int Entropy;


        private static void Subtract(IList<char> charset, List<char> allowed)
        {
            if (charset == null || charset.Count == 0)
            {
                return;
            }

            allowed.RemoveAll(c => charset.Contains(c));
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
            _required = new RequiredCharacters();

            var accessors = new List<Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>>
                {
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.LowercaseLetters, () => CharacterClasses.Lowercase),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.UppercaseLetters, () => CharacterClasses.Uppercase),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Numbers, () => CharacterClasses.Numbers),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Space, () => CharacterClasses.Space),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Dash, () => CharacterClasses.Dashes),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Symbols, () => CharacterClasses.Symbols)
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
                    for(int i = 0; i < config.RequiredCount; i++)
                    {
                        _required.Add(acc.Item2());
                    }
                }
            }

            _allowed = allowed.ToArray();

            var n = config.PasswordLength - _required.Count;
            while (--n >= 0)
            {
                _required.Add(_allowed);
            }

            Entropy = _required.GetEntropy();
        }
    }
}
