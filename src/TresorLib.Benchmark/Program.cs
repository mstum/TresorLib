using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;

namespace TresorLib.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TresorLibBenchmark>();

            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    [RyuJitX64Job]
    [LegacyJitX86Job]
    public class TresorLibBenchmark
    {
        private readonly static TresorConfig Config;

        static TresorLibBenchmark()
        {
            Config = TresorConfig.Default;
            Config.PasswordLength = 14;
            Config.Space = TresorConfig.AllowedMode.Forbidden;
            Config.Symbols = TresorConfig.AllowedMode.Forbidden;
            Config.MaxRepetition = 1;
        }

        [Benchmark]
        public string GetValue()
        {
            const string service = "twitter";
            const string phrase = "I'm the best 17-year old ever.";

            var password = Tresor.GeneratePassword(service, phrase, Config);

            return password;
        }
    }
}