using Fjeller.Convenience.Extensions;

namespace Tests.Fjeller.Convenience.Extensions;

public class NullableExtensionsTests
{
	[Fact]
	public void HasNoValue_Should_ReturnTrue_When_NullableIsNull()
	{
		int? value = null;
		Assert.True(value.HasNoValue());
	}

	[Fact]
	public void HasNoValue_Should_ReturnFalse_When_NullableHasValue()
	{
		int? value = 5;
		Assert.False(value.HasNoValue());
	}

	[Fact]
	public void HasNoValueOrDefault_Should_ReturnTrue_When_NullableIsNull()
	{
		int? value = null;
		Assert.True(value.HasNoValueOrDefault(0));
	}

	[Fact]
	public void HasNoValueOrDefault_Should_ReturnTrue_When_NullableEqualsDefault()
	{
		int? value = 0;
		Assert.True(value.HasNoValueOrDefault(0));
	}

	[Fact]
	public void HasNoValueOrDefault_Should_ReturnFalse_When_NullableNotDefault()
	{
		int? value = 5;
		Assert.False(value.HasNoValueOrDefault(0));
	}
}