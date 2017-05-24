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
using Xunit;

namespace TresorLib.Tests
{
    public class TresorLibTests
    {
        [Fact]
        public void DefaultConfig_Twitter_17YearOld()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var password = Tresor.GeneratePassword(service, phrase, TresorConfig.Default);

            Assert.Equal("c;q- q}+&,KTbPVn9]mh", password);

        }

        [Fact]
        public void DefaultConfig_Empty()
        {
            var password = Tresor.GeneratePassword("", "", TresorConfig.Default);
            Assert.Equal("29\"R|]$!F\\|-ocq?CB7/", password);
        }

        [Fact]
        public void ForbiddenSpaceSymbols_14Length()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 14;
            config.Space = TresorConfig.AllowedMode.Forbidden;
            config.Symbols = TresorConfig.AllowedMode.Forbidden;

            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("aTVLcCpgntjidL", password);
        }

        [Fact]
        public void ForbiddenSpaceSymbols_14Length_MaxRep1()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 14;
            config.Space = TresorConfig.AllowedMode.Forbidden;
            config.Symbols = TresorConfig.AllowedMode.Forbidden;
            config.MaxRepetition = 1;

            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("aUWLcDpgoujidM", password);
        }

        [Fact]
        public void ForbiddenSpaceSymbols_14Length_RequireLowerAndNum()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 14;
            config.Space = TresorConfig.AllowedMode.Forbidden;
            config.Symbols = TresorConfig.AllowedMode.Forbidden;
            config.LowercaseLetters = TresorConfig.AllowedMode.Required;
            config.Numbers = TresorConfig.AllowedMode.Required;
            config.MaxRepetition = 1;
            config.RequiredCount = 2;

            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("ax6im0bu3tih5o", password);
        }

        [Fact]
        public void Require_LowerNumSymbolsDash()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 21;
            config.RequiredCount = 4;
            config.Dash = TresorConfig.AllowedMode.Required;
            config.LowercaseLetters = TresorConfig.AllowedMode.Required;
            config.Numbers = TresorConfig.AllowedMode.Required;
            config.Symbols = TresorConfig.AllowedMode.Required;


            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("a]C--7n6@=bui_-_0i*5 ", password);
        }

        [Fact]
        public void Require_Lower_Num_Symbols_Dash_ForbiddenSpace()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 21;
            config.RequiredCount = 4;
            config.Dash = TresorConfig.AllowedMode.Required;
            config.LowercaseLetters = TresorConfig.AllowedMode.Required;
            config.Numbers = TresorConfig.AllowedMode.Required;
            config.Symbols = TresorConfig.AllowedMode.Required;
            config.Space = TresorConfig.AllowedMode.Forbidden;


            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("a]C-_7n6@=bui_-_0i*5!", password);
        }

        [Fact]
        public void RepetitionTest()
        {
            var service = "repetitionTest";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.MaxRepetition = 2;

            var password = Tresor.GeneratePassword(service, phrase, config);

            Assert.Equal("cww/~K-2V^vO]+>P>hp*", password);

            config.MaxRepetition = 1;
            password = Tresor.GeneratePassword(service, phrase, config);
            Assert.Equal("c~}VGq!B9_k]<Ky,i9&+", password);
        }

        [Fact]
        public void RepetitionTest_TripleRepeat()
        {
            var service = "g";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 30;
            config.UppercaseLetters = TresorConfig.AllowedMode.Forbidden;
            config.Numbers = TresorConfig.AllowedMode.Forbidden;
            config.Dash = TresorConfig.AllowedMode.Forbidden;
            config.Space = TresorConfig.AllowedMode.Forbidden;
            config.Symbols = TresorConfig.AllowedMode.Forbidden;

            var password = Tresor.GeneratePassword(service, phrase, config);
            Assert.Equal("mmmanfespddubqugvmswpoirmfpjxk", password);

            config.MaxRepetition = 2;
            password = Tresor.GeneratePassword(service, phrase, config);
            Assert.Equal("mmnanfvjsaubqasbitnvkywolslvno", password);

            config.MaxRepetition = 1;
            password = Tresor.GeneratePassword(service, phrase, config);
            Assert.Equal("mnmaofntpdmvbrvgwmtxvcitolptow", password);
        }
    }
}
