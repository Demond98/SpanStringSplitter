namespace SpanStringSplitter.Tests
{
	public class SpanStringSplitterTests
	{
		private const char Separator = '\n';

		private static List<string> SpanSplit(string str, char separator)
		{
			var result = new List<string>();

			foreach (var item in str.AsSpan().SpanSplit(separator))
				result.Add(item.ToString());

			return result;
		}

		[Theory]
		[InlineData("")]
		[InlineData("\n")]
		[InlineData("\n\n")]
		[InlineData("\n\n\n")]
		[InlineData("\n\n\n\n")]
		[InlineData("1")]
		[InlineData("12")]
		[InlineData("123")]
		[InlineData("\n1")]
		[InlineData("1\n")]
		[InlineData("\n1\n")]
		[InlineData("\n123")]
		[InlineData("\n123\n")]
		[InlineData("\n\n123\n\n")]
		[InlineData("1\n2\n3")]
		[InlineData("\n1\n2\n3\n")]
		[InlineData("123 \n 123 \n 123 \n")]
		[InlineData("\n 123 \n 123 \n 123")]
		public void SpanSplit_True(string str)
		{
			Assert.Equal(str.Split(Separator), SpanSplit(str, Separator));
		}
	}
}