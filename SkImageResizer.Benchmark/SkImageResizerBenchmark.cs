using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace SkImageResizer.Benchmark
{
    public class SkImageResizerBenchmark
    {
        [Params(5)] 
        public int N;
        
        private string sourcePath = "";
        private string destinationPath = "";
        private SKImageProcess imageProcess;
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); 
            imageProcess = new SKImageProcess();
        }
        
        [IterationSetup]
        public void IterationSetup()
        {
            imageProcess.Clean(destinationPath);
        }
        
        [Benchmark]
        public void ResizeSync()
        {
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
        }
        
        [Benchmark]
        public void ResizeAsync()
        {
            imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0).GetAwaiter().GetResult();
        }
    }
}