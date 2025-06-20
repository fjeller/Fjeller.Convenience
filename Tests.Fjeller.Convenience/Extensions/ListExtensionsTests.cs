using Fjeller.Convenience.Extensions;

namespace Tests.Fjeller.Convenience.Extensions;

public class ListExtensionsTests
{
	[Fact]
	public void AddIfNotNull_Should_AddItem_When_ItemIsNotNull()
	{
		var list = new List<string>();
		list.AddIfNotNull("test");
		Assert.Single(list);
		Assert.Equal("test", list[0]);
	}

	[Fact]
	public void AddIfNotNull_Should_NotAddItem_When_ItemIsNull()
	{
		var list = new List<string>();
		list.AddIfNotNull(null);
		Assert.Empty(list);
	}
}