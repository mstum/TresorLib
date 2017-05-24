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
    internal struct TresorGenerationState
    {
        internal string _phrase;
        internal int _length;
        internal int MaxRepeat;
        internal CharacterArray _allowed;
        internal RequiredCharacters _required;
        internal readonly int Entropy;

        private static List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>> CharacterClassAccessors = new List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>>
        {
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.LowercaseLetters, () => CharacterClasses.Lowercase),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.UppercaseLetters, () => CharacterClasses.Uppercase),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.Numbers, () => CharacterClasses.Numbers),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.Space, () => CharacterClasses.Space),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.Dash, () => CharacterClasses.Dashes),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<CharacterArray>>(config => config.Symbols, () => CharacterClasses.Symbols),
        };

        public TresorGenerationState(TresorConfig config, string passphrase)
        {
            _phrase = passphrase ?? string.Empty;
            _length = config.PasswordLength;
            MaxRepeat = config.MaxRepetition;

            _allowed = GetAllowed(config);
            _required = GetRequired(config);

            while(_required.Count < _length)
            {
                _required.Add(_allowed);
            }

            Entropy = _required.GetEntropy();
        }

        private static RequiredCharacters GetRequired(TresorConfig config)
        {
            var required = new RequiredCharacters(config.PasswordLength);
            foreach (var acc in CharacterClassAccessors)
            {
                var mode = acc.Item1(config);
                if (mode == TresorConfig.AllowedMode.Required)
                {
                    var req = acc.Item2();
                    for (int i = 0; i < config.RequiredCount; i++)
                    {
                        required.Add(req);
                    }
                }
            }
            return required;
        }

        private static CharacterArray GetAllowed(TresorConfig config)
        {
            var forbidden = new HashSet<char>();
            foreach (var acc in CharacterClassAccessors)
            {
                if(acc.Item1(config) == TresorConfig.AllowedMode.Forbidden)
                {
                    foreach(var c in acc.Item2().Enumerate())
                    {
                        forbidden.Add(c);
                    }
                }
            }

            var allowed = CharacterClasses.All.CheapClone();
            foreach(var c in forbidden)
            {
                allowed.Remove(c);
            }
            return allowed;
        }
    }
}
