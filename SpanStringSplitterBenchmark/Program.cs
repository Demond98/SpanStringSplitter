using BenchmarkDotNet.Attributes;
using SpanStringSplitter;

BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

[MemoryDiagnoser]
public class Test
{
	private string Data = null!;

	[Params(100, 1000)]
	public int N;

	[GlobalSetup]
	public void Setup()
	{
		var lines = Enumerable.Range(1, N);
		Data = string.Join('\n', lines);
	}

	[Benchmark]
	public bool SystemSplit()
	{
		var result = false;

		foreach (var line in Data.Split('\n'))
			if (line[0] != 'L')
				result = false;

		return result;
	}

	[Benchmark]
	public bool SpanSplit()
	{
		var result = false;

		foreach (var line in Data.SpanSplit('\n'))
			if (line[0] != 'L')
				result = false;

		return result;
	}
}