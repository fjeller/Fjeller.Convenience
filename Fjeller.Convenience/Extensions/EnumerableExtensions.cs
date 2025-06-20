namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for working with <see cref="IEnumerable{T}"/> sequences.
/// </summary>
/// <remarks>
/// This static class contains utility methods that extend the functionality of enumerable sequences,
/// such as filtering out null elements from a sequence of reference types.
/// </remarks>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class EnumerableExtensions
{
	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Filters a sequence of reference type elements, returning only the non-null elements.
	/// </summary>
	/// <typeparam name="T">The reference type of the elements in the source sequence.</typeparam>
	/// <param name="source">The sequence to filter.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> that contains only the non-null elements from the input sequence.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null.</exception>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static IEnumerable<T> WhereNotNull<T>( this IEnumerable<T?> source ) where T : class
	{
		ArgumentNullException.ThrowIfNull( source );

		IEnumerable<T> result = source.Where( item => item is not null ).Select( item => item! );

		return result;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Executes the specified action on each element of the <see cref="IEnumerable{T}"/> sequence.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
	/// <param name="source">The sequence whose elements the action will be performed on.</param>
	/// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the sequence.</param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="source"/> or <paramref name="action"/> is <c>null</c>.
	/// </exception>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static void ForEach<T>( this IEnumerable<T> source, Action<T> action )
	{
		ArgumentNullException.ThrowIfNull( source );
		ArgumentNullException.ThrowIfNull( action );

		source.ToList().ForEach( action );

	}
}