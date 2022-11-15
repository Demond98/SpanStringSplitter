# SpanStringSplitter

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK=6.0.400-preview.22330.6
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


|       Method |     N |        Mean |     Error |    StdDev |    Gen0 |    Gen1 | Allocated |
|------------- |------ |------------:|----------:|----------:|--------:|--------:|----------:|
| Split_System |   100 |    798.6 ns |  15.99 ns |  27.58 ns |  0.3023 |  0.0038 |    3952 B |
|   Split_Span |   100 |    390.2 ns |   5.97 ns |   5.58 ns |       - |       - |         - |
| Split_System |  1000 |  7,785.8 ns |  15.85 ns |  14.82 ns |  3.0518 |  0.4120 |   39952 B |
|   Split_Span |  1000 |  3,674.1 ns |  14.54 ns |  13.61 ns |       - |       - |         - |
| Split_System | 10000 | 79,944.1 ns | 229.87 ns | 191.95 ns | 30.5176 | 15.1367 |  399952 B |
|   Split_Span | 10000 | 38,271.9 ns | 247.89 ns | 231.87 ns |       - |       - |         - |