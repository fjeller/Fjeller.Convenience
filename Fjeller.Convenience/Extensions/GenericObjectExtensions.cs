using System.Diagnostics.CodeAnalysis;

namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for reference types to simplify common null checks.
/// </summary>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class GenericObjectExtensions
{
	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified object is not <c>null</c>.
	/// </summary>
	/// <typeparam name="T">The reference type of the object.</typeparam>
	/// <param name="item">The object to check.</param>
	/// <returns>
	/// <c>true</c> if the object is not <c>null</c>; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsNotNull<T>( [NotNullWhen( true )] this T? item ) where T : class
	{
		return item is not null;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Determines whether the specified object is <c>null</c>.
	/// </summary>
	/// <typeparam name="T">The reference type of the object.</typeparam>
	/// <param name="item">The object to check.</param>
	/// <returns>
	/// <c>true</c> if the object is <c>null</c>; otherwise, <c>false</c>.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static bool IsNull<T>( [NotNullWhen( false )] this T? item ) where T : class
	{
		return item is null;
	}
}
