# SpanStringSplitter

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK=6.0.400-preview.22330.6
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


|       Method |     N |       Mean |     Error |    StdDev |     Gen0 |    Gen1 | Allocated |
|------------- |------ |-----------:|----------:|----------:|---------:|--------:|----------:|
| Split_System |   100 |   4.984 us | 0.0128 us | 0.0107 us |   1.9531 |  0.0458 |   25624 B |
|   Split_Span |   100 |   2.470 us | 0.0067 us | 0.0063 us |        - |       - |         - |
| Split_System |  1000 |  50.055 us | 0.1017 us | 0.0951 us |  19.5313 |  3.7231 |  256024 B |
|   Split_Span |  1000 |  24.672 us | 0.0566 us | 0.0529 us |        - |       - |         - |
| Split_System | 10000 | 538.143 us | 1.1088 us | 0.8657 us | 195.3125 | 91.7969 | 2560025 B |
|   Split_Span | 10000 | 244.246 us | 0.5895 us | 0.5514 us |        - |       - |         - |