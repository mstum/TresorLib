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
        internal static readonly string UUID = "e87eb0f4-34cb-46b9-93ad-766c5ab063e7";

        public static string GeneratePassword(string serviceName, string passphrase, TresorConfig config)
        {
            return TresorImpl.Generate(config, passphrase, serviceName);
        }
    }
}
