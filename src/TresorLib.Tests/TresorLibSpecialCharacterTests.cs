using Xunit;

namespace Tresor.Tests
{
    public class TresorLibSpecialCharacterTests
    {
        private static readonly string CenterCannotHold = "ZA̡͊͠͝LGΌ ISͮ̂҉̯͈͕̹̘̱ TO͇̹̺ͅƝ̴ȳ̳ TH̘Ë͖́̉ ͠P̯͍̭O̚​N̐Y̡ H̸̡̪̯ͨ͊̽̅̾̎Ȩ̬̩̾͛ͪ̈́̀́͘ ̶̧̨̱̹̭̯ͧ̾ͬC̷̙̲̝͖ͭ̏ͥͮ͟Oͮ͏̮̪̝͍M̲̖͊̒ͪͩͬ̚̚͜Ȇ̴̟̟͙̞ͩ͌͝S̨̥̫͎̭ͯ̿̔̀ͅ";

        [Fact]
        public void SpecialCharacters_ServiceName()
        {
            var phrase = "I'm the best 17-year old ever.";
            var password = Tresor.GeneratePassword(CenterCannotHold, phrase, TresorConfig.Default);

            Assert.Equal("~!IbVDD/Z&u*Q|<VkPMi", password);
        }

        [Fact]
        public void SpecialCharacters_PhraseName()
        {
            var service = "twitter";
            var password = Tresor.GeneratePassword(service, CenterCannotHold, TresorConfig.Default);

            Assert.Equal("c\\4W^DMukB2w@>w;Re7W", password);
        }
    }
}
