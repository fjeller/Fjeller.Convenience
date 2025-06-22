using System.Net.Http.Headers;

namespace Fjeller.Convenience.Extensions;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides extension methods for <see cref="Dictionary{TKey, TValue}"/>.
/// </summary>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class DictionaryExtensions
{
	#region Add If Not Null

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Adds the specified key and value to the dictionary if the value is not <c>null</c>.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary. Must be a reference type.</typeparam>
	/// <param name="dictionary">The dictionary to add the key and value to.</param>
	/// <param name="key">The key of the element to add.</param>
	/// <param name="value">The value of the element to add. If <c>null</c>, the key-value pair is not added.</param>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static void AddIfNotNull<TKey, TValue>( this IDictionary<TKey, TValue> dictionary, TKey key, TValue? value )
		where TKey : notnull
		where TValue : class
	{
		if ( value != null )
		{
			dictionary.Add( key, value );
		}
	}

	#endregion

	#region Get With Default

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Tries to get the value associated with the specified key. If the key does not exist or the key is null, returns the 
	/// provided default value.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
	/// <param name="dictionary">The dictionary to retrieve the value from (never null).</param>
	/// <param name="key">The key whose value to get. If null, returns the default value.</param>
	/// <param name="defaultValue">The value to return if the key is not found or key is null.</param>
	/// <returns>
	/// The value associated with the specified key, or <paramref name="defaultValue"/> if the key is not found or key is null.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static TValue? Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey? key, TValue? defaultValue)
	{
		if ( key is null )
		{
			return defaultValue;
		}

		TValue? result = dictionary.TryGetValue(key, out TValue? value) ? value : defaultValue;

		return result;
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Tries to get the value associated with the specified key. If the key does not exist or the key is null, returns the 
	/// default value for the value type.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
	/// <param name="dictionary">The dictionary to retrieve the value from (never null).</param>
	/// <param name="key">The key whose value to get. If null, returns the default value for the value type.</param>
	/// <returns>
	/// The value associated with the specified key, or the default value for the value type if the key is not found or key is 
	/// null.
	/// </returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static TValue? Get<TKey, TValue>( this IDictionary<TKey, TValue> dictionary, TKey? key )
	{
		return dictionary.Get( key, default );
	}

	#endregion

}