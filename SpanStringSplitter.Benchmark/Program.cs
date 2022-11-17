using BenchmarkDotNet.Attributes;
using SpanStringSplitter;

BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

[MemoryDiagnoser]
public class Test
{
	private string Text = null!;

	[Params(100, 1000, 10000)]
	public int N;

	[GlobalSetup]
	public void Setup()
	{
		var rand = new Random(0);
		var randStr = () => new string(Enumerable.Range(0, 4)
			.Select(a => (char)rand.Next('a', 'z'))
			.ToArray());

		var lines = Enumerable.Range(1, N)
			.Select(a => $"{randStr()}.{randStr()}.{randStr()}.{randStr()}");

		Text = string.Join('\n', lines);
	}

	private static bool VeryBigFunc(ReadOnlySpan<char> word, bool result) => word.Length == 4 && result;

	// string Text = @"
	// buoj.wepo.fjdf.gnji
	// sghd.sjih.fbgh.paei
	// gjpa.igfh.jnvd.ofui
	// ...x 10000
	// ";

	[Benchmark]
	public bool Split_System()
	{
		//heap:
		// string[] x 10001
		// string x 50000
		// Array Enumerator x 10001

		var result = false;

		foreach (string line in Text.Split('\n'))
			foreach (string word in line.Split('.'))
				result = VeryBigFunc(word, result);

		return result;
	}

	[Benchmark]
	public bool Split_Span()
	{
		ReadOnlySpan<char> text = Text.AsSpan();
		var result = false;

		foreach (ReadOnlySpan<char> line in text.SpanSplit('\n')) // text.SpanSplit('\n') == new SplitEnumeration(text, '\n')
			foreach (ReadOnlySpan<char> word in line.SpanSplit('.'))
				result = VeryBigFunc(word, result);

		return result;
	}
}