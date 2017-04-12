#region LICENSE
/* Copyright (C) 2017 Michael Stum <opensource@stum.de>

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU General Public License as published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.
If not, see http://www.gnu.org/licenses/. */
#endregion
using Xunit;

namespace Tresor.Tests
{
    public class TresorLibErrorTests 
    {
        [Fact]
        public void Required_NotLongEnough()
        {
            var config = TresorConfig.Default;
            config.RequiredCount = 2;
            config.PasswordLength = 3;
            config.LowercaseLetters = TresorConfig.AllowedMode.Required;
            config.Numbers = TresorConfig.AllowedMode.Required;

            var password = Tresor.GeneratePassword("", "", config);
        }

    }
}