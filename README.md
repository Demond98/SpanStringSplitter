# SpanStringSplitter

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK=6.0.400-preview.22330.6
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


|      Method |     N |        Mean |     Error |    StdDev |    Gen0 |    Gen1 | Allocated |
|------------ |------ |------------:|----------:|----------:|--------:|--------:|----------:|
| SystemSplit |   100 |    754.5 ns |   2.58 ns |   2.42 ns |  0.3023 |  0.0038 |    3952 B |
|   SpanSplit |   100 |    369.9 ns |   1.08 ns |   1.01 ns |       - |       - |         - |
| SystemSplit |  1000 |  7,703.1 ns |  16.67 ns |  14.78 ns |  3.0518 |  0.4120 |   39952 B |
|   SpanSplit |  1000 |  3,668.3 ns |  12.85 ns |  10.73 ns |       - |       - |         - |
| SystemSplit | 10000 | 78,471.9 ns | 207.78 ns | 184.19 ns | 30.5176 | 15.1367 |  399952 B |
|   SpanSplit | 10000 | 37,488.0 ns | 240.45 ns | 224.91 ns |       - |       - |         - |