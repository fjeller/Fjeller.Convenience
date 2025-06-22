using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fjeller.Convenience.SyncAsync;

/// ---------------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Provides helper methods to run asynchronous code synchronously.
/// </summary>
/// ---------------------------------------------------------------------------------------------------------------------------
public static class AsyncHelper
{
	private static readonly TaskFactory _myTaskFactory = new( CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default );

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Executes an asynchronous function synchronously and returns its result.
	/// </summary>
	/// <typeparam name="TResult">The type of the result returned by the asynchronous function.</typeparam>
	/// <param name="func">The asynchronous function to execute.</param>
	/// <returns>The result of the asynchronous function.</returns>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static TResult RunSync<TResult>( Func<Task<TResult>> func )
	{
		return _myTaskFactory
			.StartNew( func )
			.Unwrap()
			.GetAwaiter()
			.GetResult();
	}

	/// ---------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Executes an asynchronous function synchronously.
	/// </summary>
	/// <param name="func">The asynchronous function to execute.</param>
	/// ---------------------------------------------------------------------------------------------------------------------------
	public static void RunSync( Func<Task> func )
	{
		_myTaskFactory
			.StartNew( func )
			.Unwrap()
			.GetAwaiter()
			.GetResult();
	}
}