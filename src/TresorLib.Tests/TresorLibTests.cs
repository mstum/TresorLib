using Xunit;

namespace Tresor.Tests
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
    }
}
