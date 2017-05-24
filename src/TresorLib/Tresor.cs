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
namespace TresorLib
{
    public static class Tresor
    {
        public static string GeneratePassword(string serviceName, string passphrase, TresorConfig config)
        {
            var state = new TresorGenerationState(config, serviceName, passphrase);

            var result = new CharBuilder(state.PasswordLength);

            while (result.Length < state.PasswordLength)
            {
                // Get candidate pool for current character
                // the same index can be generated multiple times
                var index = state.IndexStream.Generate(state.Required.Count);
                var charset = state.Required.Pop(index).CheapClone();

                if (result.HasReachedMaxRepeatLimit(state.MaxRepeat))
                {
                    charset.Remove(result.LastAppendedChar.Value);
                }

                var charIndex = state.IndexStream.Generate(charset.Length);
                var c = charset[charIndex];

                result.Add(c);
            }

            return result.ToString();
        }
    }
}
