using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SpanStringSplitter;

public ref struct SplitEnumeration
{
	//Enumeration<char>
	public SplitEnumeration GetEnumerator() => this;

	//Enumerator<char>
	public ReadOnlySpan<char> Current => _current;
	public bool MoveNext() => CalculateNext();

	private readonly ReadOnlySpan<char> _str;
	private readonly char _separator;	
	private int _prevIndex;
	private int _nextIndex;
	private ReadOnlySpan<char> _current;

	public SplitEnumeration(ReadOnlySpan<char> str, char separator)
	{
		_str = str;
		_separator = separator;
		_prevIndex = 0;
		_nextIndex = -1;
		_current = null;
	}

	private bool CalculateNext()
	{
		_prevIndex = _nextIndex + 1;

		if (_prevIndex > _str.Length)
		{
			if (_str.Length != 0 && _nextIndex == _str.Length - 1)
			{
				_prevIndex = _nextIndex = _str.Length - 1;
				return true;
			}

			return false;
		}

		_nextIndex = _str[_prevIndex..].IndexOf(_separator);

		if (_nextIndex == -1)
			_nextIndex = _str.Length;
		else
			_nextIndex += _prevIndex;

		_current = _str[_prevIndex.._nextIndex];

		return true;
	}
}