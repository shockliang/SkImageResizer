﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SkImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(x =>
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.C)
                {
                    cts.Cancel();
                }
            });
            
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            var destinationPath = Path.Combine(Environment.CurrentDirectory, "output");

            var imageProcess = new SKImageProcess();

            var sw = new Stopwatch();
            imageProcess.Clean(destinationPath);
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();
            Console.WriteLine($"同步花費時間: {sw.ElapsedMilliseconds} ms");
            
            imageProcess.Clean(destinationPath);
            sw.Restart();
            try
            {
                await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0, cts.Token);
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine($"Cancel exception:{oce}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:{e}");
            }
            
            sw.Stop();
            Console.WriteLine($"非同步花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}
