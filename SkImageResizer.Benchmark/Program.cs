using System;
using BenchmarkDotNet.Running;

namespace SkImageResizer.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // BenchmarkRunner.Run<Program>();   
            // BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            // BenchmarkRunner.Run(typeof(Program).Assembly);
            BenchmarkRunner.Run<SkImageResizerBenchmark>();
        }
    }
}