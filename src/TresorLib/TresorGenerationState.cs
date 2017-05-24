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
    internal class TresorGenerationState
    {
        internal readonly int PasswordLength;
        internal readonly int MaxRepeat;
        internal readonly RequiredCharacters Required;
        internal readonly TresorStream IndexStream;

        // The order in which we are accessing these matters
        private static List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>> CharacterClassAccessors = new List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>>
        {
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.LowercaseLetters, CharacterClasses.Lowercase),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.UppercaseLetters, CharacterClasses.Uppercase),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.Numbers, CharacterClasses.Numbers),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.Space, CharacterClasses.Space),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.Dash, CharacterClasses.Dashes),
            new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, CharacterArray>(config => config.Symbols, CharacterClasses.Symbols),
        };

        internal TresorGenerationState(TresorConfig config, string serviceName, string passphrase)
        {
            passphrase = passphrase ?? string.Empty;
            PasswordLength = config.PasswordLength;
            MaxRepeat = config.MaxRepetition;

            CharacterArray allowed;
            GetAllowedAndRequired(config, out Required, out allowed);

            if (allowed.Length == 0)
            {
                throw new InvalidOperationException("No characters available to create a password");
            }
            
            if (Required.Count > PasswordLength)
            {
                throw new InvalidOperationException("Length too small to fit all required characters");
            }

            while (Required.Count < PasswordLength)
            {
                Required.Add(allowed);
            }

            var entropy = Required.GetEntropy();
            
            IndexStream = new TresorStream(passphrase, serviceName, entropy);
        }

        private static void GetAllowedAndRequired(TresorConfig config, out RequiredCharacters required, out CharacterArray allowed)
        {
            required = new RequiredCharacters(config.PasswordLength);
            var forbidden = new HashSet<char>();
            foreach (var acc in CharacterClassAccessors)
            {
                var mode = acc.Item1(config);
                if (mode == TresorConfig.AllowedMode.Forbidden)
                {
                    acc.Item2.EnumerateIntoHashSet(forbidden);
                }
                else if (mode == TresorConfig.AllowedMode.Required)
                {
                    var req = acc.Item2;
                    for (int i = 0; i < config.RequiredCount; i++)
                    {
                        required.Add(req);
                    }
                }
            }

            allowed = CharacterClasses.All.CheapClone();
            allowed.Remove(forbidden);
        }
    }
}
