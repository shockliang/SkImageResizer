## SkImageResizer ##
* Environment
    * OS: MacOS 10.15.6
    * Cpu: 2.3 GHz 8核心Intel Core i9
    * Ram: 64 GB 2667 MHz DDR4
    
 * Benchmark
 ```markdown
BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT  [AttachedDebugger]
  Job-AUGXKM : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

|      Method | N |    Mean |    Error |   StdDev |
|------------ |-- |--------:|---------:|---------:|
|  ResizeSync | 5 | 8.813 s | 0.0356 s | 0.0333 s |
| ResizeAsync | 5 | 1.254 s | 0.0251 s | 0.0601 s |

```
    
