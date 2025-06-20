using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for <see cref="string"/> to simplify common string checks.
/// </summary>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class StringExtensions
{
	#region Checks for Empty

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is not <c>null</c>, empty, or consists only of white-space characters.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string has a value (is not <c>null</c>, empty, or whitespace); otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool HasValue( [NotNullWhen( true )] this string? item )
	{
		return !String.IsNullOrWhiteSpace( item );
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is <c>null</c>, empty, or consists only of white-space characters.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is <c>null</c>, empty, or whitespace; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsEmpty( [NotNullWhen( false )] this string? item )
	{
		return !item.HasValue();
	}

	#endregion

	#region Conversions

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 32-bit signed integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 32-bit signed integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static int ToInt32( this string? value, int defaultValue = 0 )
	{
		return Int32.TryParse( value, out int result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 32-bit signed integer. Returns the specified default value if the conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 32-bit signed integer, or <paramref name="defaultValue"/> if the conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static int? ToNullableInt32( this string? value, int? defaultValue = null )
	{
		return Int32.TryParse( value, out int result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 64-bit signed integer. Returns the specified default value if the conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 64-bit signed integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static long ToInt64( this string? value, long defaultValue = 0 )
	{
		return Int64.TryParse( value, out long result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 64-bit signed integer. Returns the specified default value if the conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 64-bit signed integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static long? ToNullableInt64( this string? value, long? defaultValue = null )
	{
		return Int64.TryParse( value, out long result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a double-precision floating-point number. Returns the specified default value if the 
	/// conversion fails. Uses invariant culture.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param> 
	/// <returns>The converted double, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static double ToDouble( this string? value, double defaultValue = 0, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Double.TryParse( value, culture, out double result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable double-precision floating-point number. Returns the specified default value if the 
	/// conversion fails. Uses invariant culture.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param> 
	/// <returns>The converted nullable double, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static double? ToNullableDouble( this string? value, double? defaultValue = null, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Double.TryParse( value, culture, out double result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a byte. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted byte, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static byte ToByte( this string? value, byte defaultValue = 0 )
	{
		return Byte.TryParse( value, out byte result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable byte. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable byte, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static byte? ToNullableByte( this string? value, byte? defaultValue = null )
	{
		return Byte.TryParse( value, out byte result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a <see cref="Guid"/>. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted <see cref="Guid"/>, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static Guid ToGuid( this string? value, Guid defaultValue )
	{
		return Guid.TryParse( value, out Guid result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable <see cref="Guid"/>. Returns <c>null</c> if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <returns>The converted nullable <see cref="Guid"/>, or <c>null</c> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static Guid? ToNullableGuid( this string? value )
	{
		return Guid.TryParse( value, out Guid result ) ? result : null;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a single-precision floating-point number. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param> 
	/// <returns>The converted float, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static float ToSingle( this string? value, float defaultValue = 0, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Single.TryParse( value, culture, out float result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable single-precision floating-point number. Returns the specified default value if 
	/// conversion fails. Uses invariant culture.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param>
	/// <returns>The converted nullable float, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static float? ToNullableSingle( this string? value, float? defaultValue = null, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Single.TryParse( value, culture, out float result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a decimal number. Returns the specified default value if conversion fails.
	/// Uses invariant culture.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param>
	/// <returns>The converted decimal, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static decimal ToDecimal( this string? value, decimal defaultValue = 0m, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Decimal.TryParse( value, culture, out decimal result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable decimal number. Returns the specified default value if conversion fails.
	/// Uses invariant culture.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <param name="culture">The culture to use for the conversion, by default null (uses invariant culture)</param>
	/// <returns>The converted nullable decimal, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static decimal? ToNullableDecimal( this string? value, decimal? defaultValue = null, CultureInfo? culture = null )
	{
		culture ??= CultureInfo.InvariantCulture;
		return Decimal.TryParse( value, culture, out decimal result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 16-bit signed integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 16-bit signed integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static short ToInt16( this string? value, short defaultValue = 0 )
	{
		return Int16.TryParse( value, out short result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 16-bit signed integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 16-bit signed integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static short? ToNullableInt16( this string? value, short? defaultValue = null )
	{
		return Int16.TryParse( value, out short result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 16-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 16-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static ushort ToUInt16( this string? value, ushort defaultValue = 0 )
	{
		return UInt16.TryParse( value, out ushort result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 16-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 16-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static ushort? ToNullableUInt16( this string? value, ushort? defaultValue = null )
	{
		return UInt16.TryParse( value, out ushort result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 32-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 32-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static uint ToUInt32( this string? value, uint defaultValue = 0 )
	{
		return UInt32.TryParse( value, out uint result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 32-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 32-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static uint? ToNullableUInt32( this string? value, uint? defaultValue = null )
	{
		return UInt32.TryParse( value, out uint result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a 64-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted 64-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static ulong ToUInt64( this string? value, ulong defaultValue = 0 )
	{
		return UInt64.TryParse( value, out ulong result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable 64-bit unsigned integer. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable 64-bit unsigned integer, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static ulong? ToNullableUInt64( this string? value, ulong? defaultValue = null )
	{
		return UInt64.TryParse( value, out ulong result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a signed byte. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted signed byte, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static sbyte ToSByte( this string? value, sbyte defaultValue = 0 )
	{
		return SByte.TryParse( value, out sbyte result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a nullable signed byte. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="value">The string to convert.</param>
	/// <param name="defaultValue">The value to return if conversion fails.</param>
	/// <returns>The converted nullable signed byte, or <paramref name="defaultValue"/> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static sbyte? ToNullableSByte( this string? value, sbyte? defaultValue = null )
	{
		return SByte.TryParse( value, out sbyte result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts a string into a boolean. If the conversion fails, the value of the parameter 
	/// <paramref name="defaultValue"/> is returned. The default return value is <c>false</c>.
	/// </summary>
	/// <param name="item">the string to convert into a boolean</param>
	/// <param name="defaultValue">The default value (<c>false</c> by default)</param>
	/// <returns>The boolean according to the provided string or the default value</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool ToBoolean( this string? item, bool defaultValue = false )
	{
		return Boolean.TryParse( item, out bool result ) ? result : defaultValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a <see cref="CultureInfo"/>. Returns <c>null</c> if conversion fails.
	/// </summary>
	/// <param name="item">The string to convert.</param>
	/// <returns>The converted <see cref="CultureInfo"/>, or <c>null</c> if conversion fails.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static CultureInfo? ToCultureInfo( this string? item )
	{
		CultureInfo? result = null;
		if ( item.HasValue() )
		{
			try
			{
				result = CultureInfo.GetCultureInfo( item, true );
			}
			catch ( CultureNotFoundException )
			{
				result = null;
			}
		}
		return result;
	}


	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Converts the string to a <see cref="CultureInfo"/>. Returns the specified default value if conversion fails.
	/// </summary>
	/// <param name="item">The string to convert.</param>
	/// <param name="defaultValue">The <see cref="CultureInfo"/> to return if conversion fails.</param>
	/// <returns>
	/// The converted <see cref="CultureInfo"/>, or <paramref name="defaultValue"/> if conversion fails.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	private static CultureInfo ToCultureInfo( this string? item, CultureInfo defaultValue )
	{
		return item.ToCultureInfo() ?? defaultValue;
	}

	#endregion

	#region Case Checks

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is entirely upper-case.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is not null, not empty, and all characters are upper-case; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsUpper( this string? item )
	{
		return !string.IsNullOrEmpty( item ) && item.All( c => !char.IsLetter( c ) || char.IsUpper( c ) );
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is entirely lower-case.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is not null, not empty, and all characters are lower-case; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsLower( this string? item )
	{
		return !string.IsNullOrEmpty( item ) && item.All( c => !char.IsLetter( c ) || char.IsLower( c ) );
	}

	#endregion

	#region Null Handling

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Returns the original string if it is not null; otherwise, returns the specified fallback value.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <param name="fallback">The fallback value to return if <paramref name="item"/> is null.</param>
	/// <returns>
	/// The original string if not null; otherwise, the fallback value.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static string ValueOrDefault( this string? item, string fallback )
	{
		return item ?? fallback;
	}

	#endregion

	#region Type checks

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is a valid <see cref="Guid"/> format.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is a valid <see cref="Guid"/>; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsGuid( string? item )
	{
		bool result = item != null && Guid.TryParse( item, out _ );

		return result;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is a valid <see cref="DateTime"/> format.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is a valid <see cref="DateTime"/>; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsDateTime( this string? item )
	{
		bool result = item.HasValue() && DateTime.TryParse( item, out _ );

		return result;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified string is a valid culture.
	/// </summary>
	/// <param name="item">The string to check.</param>
	/// <returns>
	/// <c>true</c> if the string is a valid culture name; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsCulture( this string? item )
	{
		if ( item.IsEmpty() )
		{
			return false;
		}

		try
		{
			_ = CultureInfo.GetCultureInfo( item, true );
			return true;
		}
		catch ( CultureNotFoundException )
		{
			return false;
		}
	}

	#endregion
}