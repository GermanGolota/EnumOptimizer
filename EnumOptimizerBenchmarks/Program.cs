using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnumOptimizer;
using System;

namespace EnumOptimizerBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }

    public enum MediaType
    {
        Video, Image, Album, LiveStream
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private MediaType Type = MediaType.Video;
        [Benchmark]
        public string NativeToString()
        {
            return Type.ToString();
        }

        [Benchmark]
        public string FastToString()
        {
            return Type.FastToString();
        }
    }
}
