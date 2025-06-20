using Fjeller.Convenience.Extensions;

namespace Tests.Fjeller.Convenience.Extensions;

public class DictionaryExtensionsTests
{
	[Fact]
	public void AddIfNotNull_Should_Add_When_ValueIsNotNull()
	{
		var dict = new Dictionary<string, string>();
		dict.AddIfNotNull("key", "value");
		Assert.Single(dict);
		Assert.Equal("value", dict["key"]);
	}

	[Fact]
	public void AddIfNotNull_Should_NotAdd_When_ValueIsNull()
	{
		var dict = new Dictionary<string, string>();
		dict.AddIfNotNull("key", null);
		Assert.Empty(dict);
	}
}