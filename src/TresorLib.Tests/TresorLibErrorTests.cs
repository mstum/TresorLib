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