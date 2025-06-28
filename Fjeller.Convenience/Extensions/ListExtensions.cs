namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for working with <see cref="List{T}"/> collections.
/// </summary>
/// <remarks>
/// This static class contains utility methods that extend the functionality of generic lists,
/// such as conditionally adding elements based on null checks and other criteria.
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
	/// <returns>The list itself, for chaining.</returns>
	/// <remarks>
	/// This method checks if the provided <paramref name="item"/> is not <c>null</c> before adding it to the 
	/// <paramref name="list"/>.
	/// </remarks>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static IList<T> AddIfNotNull<T>( this IList<T> list, T? item ) where T : class
	{
		if ( item is not null )
		{
			list.Add( item );
		}

		return list;
	}

	/// -----------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Inserts the specified item at the given index if the item is not <c>null</c>.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list. Must be a reference type.</typeparam>
	/// <param name="list">The list to which the item will be inserted.</param>
	/// <param name="index">The zero-based index at which the item should be inserted.</param>
	/// <param name="item">The item to insert if it is not <c>null</c>.</param>
	/// <returns>The list itself, for chaining.</returns>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static IList<T> InsertIfNotNull<T>( this IList<T> list, int index, T? item ) where T : class
	{
		if ( item is not null )
		{
			list.Insert( index, item );
		}

		return list;
	}

	/// -----------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Adds the specified item to the list if the given condition is <c>true</c> for the item.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list to which the item will be added.</param>
	/// <param name="item">The item to add if the condition is <c>true</c>.</param>
	/// <param name="condition">A function that determines whether the item should be added.</param>
	/// <returns>The list itself, for chaining.</returns>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static IList<T> AddIf<T>( this IList<T> list, T item, Func<T, bool> condition )
	{
		if ( condition( item ) )
		{
			list.Add( item );
		}

		return list;
	}

	/// -----------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Inserts the specified item at the given index if the given condition is <c>true</c> for the item.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list to which the item will be inserted.</param>
	/// <param name="index">The zero-based index at which the item should be inserted.</param>
	/// <param name="item">The item to insert if the condition is <c>true</c>.</param>
	/// <param name="condition">A function that determines whether the item should be inserted.</param>
	/// <returns>The list itself, for chaining.</returns>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static IList<T> InsertIf<T>( this IList<T> list, int index, T item, Func<T, bool> condition )
	{
		if ( condition( item ) )
		{
			list.Insert( index, item );
		}

		return list;
	}

	/// -----------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Removes all specified items from the list.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list from which the items will be removed.</param>
	/// <param name="items">The items to remove from the list.</param>
	/// <returns>The list itself, for chaining.</returns>
	/// -----------------------------------------------------------------------------------------------------------------------
	public static IList<T> RemoveAll<T>( this IList<T> list, params T[] items )
	{
		foreach ( T item in items )
		{
			list.Remove( item );
		}

		return list;
	}
}