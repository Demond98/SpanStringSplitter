# SpanStringSplitter

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK=6.0.400-preview.22330.6
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


|      Method |    N |       Mean |    Error |   StdDev |   Gen0 |   Gen1 | Allocated |
|------------ |----- |-----------:|---------:|---------:|-------:|-------:|----------:|
| SystemSplit |  100 |   759.5 ns |  7.11 ns |  5.94 ns | 0.3023 | 0.0038 |    3952 B |
|   SpanSplit |  100 |   371.4 ns |  1.81 ns |  1.70 ns |      - |      - |         - |
| SystemSplit | 1000 | 7,698.2 ns | 29.05 ns | 27.17 ns | 3.0518 | 0.4120 |   39952 B |
|   SpanSplit | 1000 | 3,700.3 ns | 15.32 ns | 14.33 ns |      - |      - |         - |