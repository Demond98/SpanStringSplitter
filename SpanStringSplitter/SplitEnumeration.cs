using System;
using System.Reflection;

namespace SpanStringSplitter;

public ref struct SplitEnumeration
{
	private readonly ReadOnlySpan<char> _str;
	private readonly char _separator;
	
	private int _prevIndex;
	private int _nextIndex;

	public SplitEnumeration(string str, char separator)
	{
		_str = str;
		_separator = separator;

		_prevIndex = 0;
		_nextIndex = -1;
	}

	public SplitEnumeration GetEnumerator() => this;
	public ReadOnlySpan<char> Current => _str[_prevIndex.._nextIndex];

	public bool MoveNext()
	{
		_prevIndex = _nextIndex + 1;
		
		if (_prevIndex >= _str.Length)
			return false;

		_nextIndex = _str[_prevIndex..].IndexOf(_separator);

		if (_nextIndex == -1)
			_nextIndex = _str.Length;
		else
			_nextIndex += _prevIndex;

		return true;
	}
}