using System.Diagnostics.CodeAnalysis;

namespace Fjeller.Convenience.Extensions;

public static class NullableExtensions
{
	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the nullable value type does not have a value.
	/// </summary>
	/// <typeparam name="T">The underlying value type.</typeparam>
	/// <param name="nullable">The nullable value to check.</param>
	/// <returns>True if the nullable does not have a value; otherwise, false.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool HasNoValue<T>( [NotNullWhen( false )] this T? nullable ) where T : struct
	{
		return !nullable.HasValue;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the nullable value type does not have a value or equals the specified default value.
	/// </summary>
	/// <typeparam name="T">The underlying value type.</typeparam>
	/// <param name="nullable">The nullable value to check.</param>
	/// <param name="defaultValue">The default value to compare against.</param>
	/// <returns>
	/// True if the nullable does not have a value or its value equals the default value; otherwise, false.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool HasNoValueOrDefault<T>( [NotNullWhen( false )] this T? nullable, T defaultValue ) where T : struct
	{
		return !nullable.HasValue || nullable.Value.Equals( defaultValue );
	}
}