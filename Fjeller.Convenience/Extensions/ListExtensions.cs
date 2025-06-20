namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for working with <see cref="List{T}"/> collections.
/// </summary>
/// <remarks>
/// This static class contains utility methods that extend the functionality of generic lists,
/// such as conditionally adding elements based on null checks.
/// </remarks>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class ListExtensions
{
	/// -----------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Adds the specified item to the list if the item is not <c>null</c>.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list. Must be a reference type.</typeparam>
	/// <param name="list">The list to which the item will be added.</param>
	/// <param name="item">The item to add if it is not <c>null</c>.</param>
	/// <remarks>
	/// This method checks if the provided <paramref name="item"/> is not <c>null</c> before adding it to the 
	/// <paramref name="list"/>.
	/// </remarks>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static void AddIfNotNull<T>( this IList<T> list, T? item ) where T : class
	{
		if ( item is not null )
		{
			list.Add( item );
		}
	}
}