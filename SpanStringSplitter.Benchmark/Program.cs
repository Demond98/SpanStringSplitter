using BenchmarkDotNet.Attributes;
using SpanStringSplitter;

BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

[MemoryDiagnoser]
public class Test
{
	private const char Separator = '\n';
	private string Data = null!;

	[Params(100, 1000, 10000)]
	public int N;

	[GlobalSetup]
	public void Setup()
	{
		var lines = Enumerable.Range(1, N);
		Data = string.Join(Separator, lines);
	}

	[Benchmark]
	public bool Split_System()
	{
		var result = false;

		foreach (var line in Data.Split(Separator))
			if (line[0] != 'L')
				result = true;

		return result;
	}

	[Benchmark]
	public bool Split_Span()
	{
		var result = false;

		foreach (var line in Data.SpanSplit(Separator))
			if (line[0] != 'L')
				result = true;

		return result;
	}
}