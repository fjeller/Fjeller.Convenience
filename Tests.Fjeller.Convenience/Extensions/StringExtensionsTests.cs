using Fjeller.Convenience.Extensions;

namespace Tests.Fjeller.Convenience.Extensions;

public class StringExtensionsTests
{
	[Theory]
	[InlineData(null, false)]
	[InlineData("", false)]
	[InlineData("   ", false)]
	[InlineData("abc", true)]
	public void HasValue_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.HasValue());
	}

	[Theory]
	[InlineData(null, true)]
	[InlineData("", true)]
	[InlineData("   ", true)]
	[InlineData("abc", false)]
	public void IsEmpty_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.IsEmpty());
	}

	[Theory]
	[InlineData("123", 123)]
	[InlineData("abc", 0)]
	[InlineData(null, 0)]
	public void ToInt32_Should_ReturnExpected_When_InputIsVarious(string? input, int expected)
	{
		Assert.Equal(expected, input.ToInt32());
	}

	[Theory]
	[InlineData("123", 123L)]
	[InlineData("abc", 0L)]
	[InlineData(null, 0L)]
	public void ToInt64_Should_ReturnExpected_When_InputIsVarious(string? input, long expected)
	{
		Assert.Equal(expected, input.ToInt64());
	}

	[Theory]
	[InlineData("true", true)]
	[InlineData("false", false)]
	[InlineData("notabool", false)]
	[InlineData(null, false)]
	public void ToBoolean_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.ToBoolean());
	}

	[Theory]
	[InlineData("en-US", true)]
	[InlineData("not-a-culture", false)]
	[InlineData(null, false)]
	public void IsCulture_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.IsCulture());
	}

	[Theory]
	[InlineData("A", true)]
	[InlineData("a", false)]
	[InlineData("A1", true)]
	[InlineData("a1", false)]
	[InlineData("", false)]
	[InlineData(null, false)]
	public void IsUpper_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.IsUpper());
	}

	[Theory]
	[InlineData("a", true)]
	[InlineData("A", false)]
	[InlineData("a1", true)]
	[InlineData("A1", false)]
	[InlineData("", false)]
	[InlineData(null, false)]
	public void IsLower_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.IsLower());
	}

	[Fact]
	public void ValueOrDefault_Should_ReturnFallback_When_InputIsNull()
	{
		string? input = null;
		Assert.Equal("fallback", input.ValueOrDefault("fallback"));
	}

	[Fact]
	public void ValueOrDefault_Should_ReturnValue_When_InputIsNotNull()
	{
		Assert.Equal("value", "value".ValueOrDefault("fallback"));
	}

	[Theory]
	[InlineData("d2719c2e-6c7e-4e2e-8e2e-2e2e2e2e2e2e", true)]
	[InlineData("not-a-guid", false)]
	[InlineData(null, false)]
	public void IsGuid_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, StringExtensions.IsGuid(input));
	}

	[Theory]
	[InlineData("2020-01-01", true)]
	[InlineData("not-a-date", false)]
	[InlineData(null, false)]
	public void IsDateTime_Should_ReturnExpected_When_InputIsVarious(string? input, bool expected)
	{
		Assert.Equal(expected, input.IsDateTime());
	}

	[Fact]
	public void ToCultureInfo_Should_ReturnCultureInfo_When_ValidCulture()
	{
		Assert.Equal("en-US", "en-US".ToCultureInfo()?.Name);
	}

	[Fact]
	public void ToCultureInfo_Should_ReturnNull_When_InvalidCulture()
	{
		Assert.Null("not-a-culture".ToCultureInfo());
	}

	[Fact]
	public void ToCultureInfo_Should_ReturnNull_When_InputIsNull()
	{
		Assert.Null(((string?)null).ToCultureInfo());
	}

	[Theory]
	[InlineData("123.45", 123.45)]
	[InlineData("notadouble", 0)]
	[InlineData(null, 0)]
	public void ToDouble_Should_ReturnExpected_When_InputIsVarious(string? input, double expected)
	{
		Assert.Equal(expected, input.ToDouble());
	}

	[Theory]
	[InlineData("123.45", 123.45f)]
	[InlineData("notafloat", 0f)]
	[InlineData(null, 0f)]
	public void ToSingle_Should_ReturnExpected_When_InputIsVarious(string? input, float expected)
	{
		Assert.Equal(expected, input.ToSingle());
	}

	[Theory]
	[InlineData("123.45", 123.45)]
	[InlineData("notadecimal", 0)]
	[InlineData(null, 0)]
	public void ToDecimal_Should_ReturnExpected_When_InputIsVarious(string? input, decimal expected)
	{
		Assert.Equal(expected, input.ToDecimal());
	}

	[Theory]
	[InlineData("123", (short)123)]
	[InlineData("notashort", (short)0)]
	[InlineData(null, (short)0)]
	public void ToInt16_Should_ReturnExpected_When_InputIsVarious(string? input, short expected)
	{
		Assert.Equal(expected, input.ToInt16());
	}

	[Theory]
	[InlineData("123", (ushort)123)]
	[InlineData("notanushort", (ushort)0)]
	[InlineData(null, (ushort)0)]
	public void ToUInt16_Should_ReturnExpected_When_InputIsVarious(string? input, ushort expected)
	{
		Assert.Equal(expected, input.ToUInt16());
	}

	[Theory]
	[InlineData("123", (uint)123)]
	[InlineData("notanuint", (uint)0)]
	[InlineData(null, (uint)0)]
	public void ToUInt32_Should_ReturnExpected_When_InputIsVarious(string? input, uint expected)
	{
		Assert.Equal(expected, input.ToUInt32());
	}

	[Theory]
	[InlineData("123", (ulong)123)]
	[InlineData("notanulong", (ulong)0)]
	[InlineData(null, (ulong)0)]
	public void ToUInt64_Should_ReturnExpected_When_InputIsVarious(string? input, ulong expected)
	{
		Assert.Equal(expected, input.ToUInt64());
	}

	[Theory]
	[InlineData("123", (byte)123)]
	[InlineData("notabyte", (byte)0)]
	[InlineData(null, (byte)0)]
	public void ToByte_Should_ReturnExpected_When_InputIsVarious(string? input, byte expected)
	{
		Assert.Equal(expected, input.ToByte());
	}

	[Theory]
	[InlineData("123", (sbyte)123)]
	[InlineData("notasbyte", (sbyte)0)]
	[InlineData(null, (sbyte)0)]
	public void ToSByte_Should_ReturnExpected_When_InputIsVarious(string? input, sbyte expected)
	{
		Assert.Equal(expected, input.ToSByte());
	}

	[Fact]
	public void ToGuid_Should_ReturnGuid_When_ValidGuid()
	{
		var guid = Guid.NewGuid();
		Assert.Equal(guid, guid.ToString().ToGuid(Guid.Empty));
	}

	[Fact]
	public void ToGuid_Should_ReturnDefault_When_InvalidGuid()
	{
		Assert.Equal(Guid.Empty, "not-a-guid".ToGuid(Guid.Empty));
	}

	[Fact]
	public void ToNullableGuid_Should_ReturnGuid_When_ValidGuid()
	{
		var guid = Guid.NewGuid();
		Assert.Equal(guid, guid.ToString().ToNullableGuid());
	}

	[Fact]
	public void ToNullableGuid_Should_ReturnNull_When_InvalidGuid()
	{
		Assert.Null("not-a-guid".ToNullableGuid());
	}

	[Theory]
	[InlineData("123", 123)]
	[InlineData("abc", null)]
	[InlineData(null, null)]
	public void ToNullableInt32_Should_ReturnExpected_When_InputIsVarious(string? input, int? expected)
	{
		Assert.Equal(expected, input.ToNullableInt32());
	}

	[Theory]
	[InlineData("123", 123L)]
	[InlineData("abc", null)]
	[InlineData(null, null)]
	public void ToNullableInt64_Should_ReturnExpected_When_InputIsVarious(string? input, long? expected)
	{
		Assert.Equal(expected, input.ToNullableInt64());
	}

	[Theory]
	[InlineData("123.45", 123.45)]
	[InlineData("notadouble", null)]
	[InlineData(null, null)]
	public void ToNullableDouble_Should_ReturnExpected_When_InputIsVarious(string? input, double? expected)
	{
		Assert.Equal(expected, input.ToNullableDouble());
	}

	[Theory]
	[InlineData("123", (byte)123)]
	[InlineData("notabyte", null)]
	[InlineData(null, null)]
	public void ToNullableByte_Should_ReturnExpected_When_InputIsVarious(string? input, byte? expected)
	{
		Assert.Equal(expected, input.ToNullableByte());
	}

	[Theory]
	[InlineData("123.45", 123.45f)]
	[InlineData("notafloat", null)]
	[InlineData(null, null)]
	public void ToNullableSingle_Should_ReturnExpected_When_InputIsVarious(string? input, float? expected)
	{
		Assert.Equal(expected, input.ToNullableSingle());
	}

	[Theory]
	[InlineData("notadecimal", null)]
	[InlineData(null, null)]
	public void ToNullableDecimal_Should_ReturnExpected_When_InputIsVarious(string? input, decimal? expected)
	{
		Assert.Equal(expected, input.ToNullableDecimal());
	}

	[Theory]
	[InlineData("123", (short)123)]
	[InlineData("notashort", null)]
	[InlineData(null, null)]
	public void ToNullableInt16_Should_ReturnExpected_When_InputIsVarious(string? input, short? expected)
	{
		Assert.Equal(expected, input.ToNullableInt16());
	}

	[Theory]
	[InlineData("123", (ushort)123)]
	[InlineData("notanushort", null)]
	[InlineData(null, null)]
	public void ToNullableUInt16_Should_ReturnExpected_When_InputIsVarious(string? input, ushort? expected)
	{
		Assert.Equal(expected, input.ToNullableUInt16());
	}

	[Theory]
	[InlineData("123", (uint)123)]
	[InlineData("notanuint", null)]
	[InlineData(null, null)]
	public void ToNullableUInt32_Should_ReturnExpected_When_InputIsVarious(string? input, uint? expected)
	{
		Assert.Equal(expected, input.ToNullableUInt32());
	}

	[Theory]
	[InlineData("123", (ulong)123)]
	[InlineData("notanulong", null)]
	[InlineData(null, null)]
	public void ToNullableUInt64_Should_ReturnExpected_When_InputIsVarious(string? input, ulong? expected)
	{
		Assert.Equal(expected, input.ToNullableUInt64());
	}

	[Theory]
	[InlineData("123", (sbyte)123)]
	[InlineData("notasbyte", null)]
	[InlineData(null, null)]
	public void ToNullableSByte_Should_ReturnExpected_When_InputIsVarious(string? input, sbyte? expected)
	{
		Assert.Equal(expected, input.ToNullableSByte());
	}
}