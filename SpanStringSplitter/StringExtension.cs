namespace SpanStringSplitter;

public static class StringExtension
{
	public static SplitEnumeration SpanSplit(this string stringToSplit, char separator)
		=> new(stringToSplit, separator);
}