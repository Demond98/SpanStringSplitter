namespace SpanStringSplitter;

public static class StringExtension
{
	public static SplitEnumeration SpanSplit(this ReadOnlySpan<char> stringToSplit, char separator)
		=> new SplitEnumeration(stringToSplit, separator);
}