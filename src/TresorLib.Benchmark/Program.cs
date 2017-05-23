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
        [Benchmark]
        public string GetValue()
        {
            var service = "twitter";
            var phrase = "I'm the best 17-year old ever.";
            var config = TresorConfig.Default;
            config.PasswordLength = 14;
            config.Space = TresorConfig.AllowedMode.Forbidden;
            config.Symbols = TresorConfig.AllowedMode.Forbidden;
            config.MaxRepetition = 1;

            var password = Tresor.GeneratePassword(service, phrase, config);

            return password;
        }
    }
}
