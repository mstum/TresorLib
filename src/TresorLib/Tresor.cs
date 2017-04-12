namespace Tresor
{
    public static class Tresor
    {
        internal static readonly string UUID = "e87eb0f4-34cb-46b9-93ad-766c5ab063e7";

        public static string GeneratePassword(string serviceName, string passphrase, TresorConfig config)
        {
            var tresor = new TresorImpl(config, passphrase);
            return tresor.Generate(serviceName);
        }
    }
}
