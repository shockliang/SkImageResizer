using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SkImageResizerAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            var destinationPath = Path.Combine(Environment.CurrentDirectory, "output");

            var imageProcess = new SKImageProcess();

            imageProcess.Clean(destinationPath);

            var sw = new Stopwatch();
            sw.Start();
            await imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
            
        }
    }
}