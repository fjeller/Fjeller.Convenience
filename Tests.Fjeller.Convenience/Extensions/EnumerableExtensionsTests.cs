using Fjeller.Convenience.Extensions;

namespace Tests.Fjeller.Convenience.Extensions;

public class EnumerableExtensionsTests
{
	[Fact]
	public void WhereNotNull_Should_ReturnOnlyNonNullItems_When_SourceHasNulls()
	{
		var source = new string?[] { "a", null, "b" };
		var result = source.WhereNotNull().ToList();
		Assert.Equal(2, result.Count);
		Assert.Contains("a", result);
		Assert.Contains("b", result);
	}

	[Fact]
	public void WhereNotNull_Should_ThrowArgumentNullException_When_SourceIsNull()
	{
		string[]? source = null;
		// ReSharper disable once InvokeAsExtensionMethod
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.WhereNotNull(source));
#pragma warning restore CS8604 // Possible null reference argument.
	}

	[Fact]
	public void ForEach_Should_InvokeAction_ForEachElement()
	{
		var list = new List<int> { 1, 2, 3 };
		int sum = 0;
		list.ForEach(x => sum += x);
		Assert.Equal(6, sum);
	}

	[Fact]
	public void ForEach_Should_ThrowArgumentNullException_When_SourceIsNull()
	{
		List<int>? list = null;
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ForEach(list, x => { }));
#pragma warning restore CS8604 // Possible null reference argument.
	}

	[Fact]
	public void ForEach_Should_ThrowArgumentNullException_When_ActionIsNull()
	{
		var list = new List<int> { 1 };
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentNullException>(() => list.ForEach(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}