﻿# AsyncHelper Reference

**📘 Reference Documentation**

---

## Overview

The `AsyncHelper` class provides utility methods to execute asynchronous code synchronously. This is useful in scenarios where async/await cannot be used (e.g., synchronous methods, constructors, property getters) but you need to call async APIs.

**Namespace:** `Fjeller.Convenience.SyncAsync`

⚠️ **Warning:** Running async code synchronously can lead to deadlocks in certain contexts (e.g., UI threads, ASP.NET Core request contexts). Use with caution and prefer async/await whenever possible.

---

## Methods

### RunSync\<TResult\>

Executes an asynchronous function synchronously and returns its result.

```csharp
public static TResult RunSync<TResult>(Func<Task<TResult>> func)
```

#### Type Parameters

- **TResult**: The type of the result returned by the asynchronous function.

#### Parameters

- **func** (`Func<Task<TResult>>`): The asynchronous function to execute.

#### Returns

`TResult`: The result of the asynchronous function.

#### Examples

```csharp
using Fjeller.Convenience.SyncAsync;

public class DataService
{
    private readonly HttpClient _client;

    public string GetDataSync()
    {
        // Execute async method synchronously
        return AsyncHelper.RunSync(async () =>
        {
            var response = await _client.GetAsync("https://api.example.com/data");
            return await response.Content.ReadAsStringAsync();
        });
    }
}
```

```csharp
public class Configuration
{
    public string ApiKey { get; }

    public Configuration()
    {
        // Load config from async source in constructor
        ApiKey = AsyncHelper.RunSync(async () =>
        {
            return await LoadApiKeyFromSecureStore();
        });
    }

    private async Task<string> LoadApiKeyFromSecureStore()
    {
        // Async implementation
        await Task.Delay(100);
        return "secret-key";
    }
}
```

---

### RunSync

Executes an asynchronous function synchronously without returning a result.

```csharp
public static void RunSync(Func<Task> func)
```

#### Parameters

- **func** (`Func<Task>`): The asynchronous function to execute.

#### Examples

```csharp
using Fjeller.Convenience.SyncAsync;

public class Logger
{
    public void LogSync(string message)
    {
        AsyncHelper.RunSync(async () =>
        {
            await WriteToLogFileAsync(message);
        });
    }

    private async Task WriteToLogFileAsync(string message)
    {
        // Async logging implementation
        await File.AppendAllTextAsync("log.txt", message + Environment.NewLine);
    }
}
```

```csharp
public class CacheInitializer
{
    public void Initialize()
    {
        AsyncHelper.RunSync(async () =>
        {
            await PopulateCacheAsync();
            await WarmUpConnectionsAsync();
        });
    }

    private async Task PopulateCacheAsync()
    {
        // Async cache population
        await Task.Delay(500);
    }

    private async Task WarmUpConnectionsAsync()
    {
        // Async connection warming
        await Task.Delay(200);
    }
}
```

---

## Usage Patterns

### Property Getters (Use with Extreme Caution)

```csharp
public class LazyConfiguration
{
    private string? _cachedValue;

    public string ExpensiveProperty
    {
        get
        {
            if (_cachedValue is null)
            {
                _cachedValue = AsyncHelper.RunSync(async () =>
                {
                    return await FetchFromRemoteSourceAsync();
                });
            }
            return _cachedValue;
        }
    }

    private async Task<string> FetchFromRemoteSourceAsync()
    {
        await Task.Delay(1000);
        return "remote-value";
    }
}
```

**⚠️ Warning:** Avoid this pattern if possible. Consider making the property async or using lazy initialization differently.

---

### Synchronous API Wrappers

```csharp
public class DatabaseRepository
{
    private readonly IAsyncRepository _asyncRepo;

    public DatabaseRepository(IAsyncRepository asyncRepo)
    {
        _asyncRepo = asyncRepo;
    }

    // Provide sync wrapper for legacy code
    public User GetUserSync(int id)
    {
        return AsyncHelper.RunSync(() => _asyncRepo.GetUserAsync(id));
    }

    // Provide sync wrapper for bulk operation
    public void SaveChangesSync()
    {
        AsyncHelper.RunSync(() => _asyncRepo.SaveChangesAsync());
    }
}
```

---

### Constructor Initialization

```csharp
public class ServiceWithAsyncSetup
{
    private readonly string _connectionString;

    public ServiceWithAsyncSetup()
    {
        _connectionString = AsyncHelper.RunSync(async () =>
        {
            return await LoadConnectionStringAsync();
        });
    }

    private async Task<string> LoadConnectionStringAsync()
    {
        // Load from secure configuration
        await Task.Delay(100);
        return "Server=localhost;Database=mydb";
    }
}
```

---

## Important Considerations

### When to Use AsyncHelper

✅ **Good use cases:**
- Legacy synchronous code that cannot be easily converted to async
- Console applications with synchronous Main methods (pre-C# 7.1)
- Constructors that need to call async initialization
- Property getters that must be synchronous (use sparingly with caching)
- Unit tests that require synchronous test methods

❌ **Avoid using when:**
- You're in an async context already (use `await` instead)
- You're on the UI thread (high deadlock risk)
- You're in ASP.NET request pipeline (can cause thread pool starvation)
- The calling code can be made async instead

---

### Deadlock Risks

AsyncHelper uses `TaskScheduler.Default` to avoid common deadlock scenarios, but risks remain:

```csharp
// ⚠️ DANGEROUS in ASP.NET or UI contexts
public class Controller
{
    public IActionResult GetData()
    {
        // This can deadlock in ASP.NET!
        var data = AsyncHelper.RunSync(async () =>
        {
            return await _service.GetDataAsync();
        });

        return Ok(data);
    }
}

// ✅ CORRECT approach
public class Controller
{
    public async Task<IActionResult> GetData()
    {
        var data = await _service.GetDataAsync();
        return Ok(data);
    }
}
```

---

### Performance Impact

Running async code synchronously has performance implications:

- **Thread blocking**: The calling thread is blocked until the async operation completes
- **Thread pool starvation**: In high-load scenarios, can exhaust thread pool threads
- **No parallelism benefits**: Loses the scalability benefits of async/await

---

## Alternatives to Consider

### Modern C# Main Methods

```csharp
// Instead of:
static void Main(string[] args)
{
    AsyncHelper.RunSync(async () =>
    {
        await DoWorkAsync();
    });
}

// Use async Main (C# 7.1+):
static async Task Main(string[] args)
{
    await DoWorkAsync();
}
```

### Factory Pattern for Async Construction

```csharp
// Instead of async work in constructor:
public class Service
{
    private Service(string data)
    {
        Data = data;
    }

    public string Data { get; }

    public static async Task<Service> CreateAsync()
    {
        var data = await LoadDataAsync();
        return new Service(data);
    }

    private static async Task<string> LoadDataAsync()
    {
        await Task.Delay(100);
        return "loaded-data";
    }
}

// Usage:
var service = await Service.CreateAsync();
```

### Lazy Async Initialization

```csharp
using System;
using System.Threading.Tasks;

public class ServiceWithLazyInit
{
    private readonly Lazy<Task<string>> _dataLoader;

    public ServiceWithLazyInit()
    {
        _dataLoader = new Lazy<Task<string>>(LoadDataAsync);
    }

    public async Task<string> GetDataAsync()
    {
        return await _dataLoader.Value;
    }

    private async Task<string> LoadDataAsync()
    {
        await Task.Delay(100);
        return "lazy-loaded-data";
    }
}
```

---

## Implementation Details

AsyncHelper uses a custom `TaskFactory` with `TaskScheduler.Default` to avoid capturing synchronization contexts, which helps prevent deadlocks in many scenarios:

```csharp
private static readonly TaskFactory _myTaskFactory = new(
    CancellationToken.None,
    TaskCreationOptions.None,
    TaskContinuationOptions.None,
    TaskScheduler.Default
);
```

This approach is based on Stephen Cleary's AsyncEx library and similar patterns used in the .NET ecosystem.

---

## See Also

- **[Async Operations How-To](../how-to/async-operations.md)** – Practical async/sync bridging patterns
- **[Why Extension Methods?](../explanations/why-extension-methods.md)** – Understanding library design choices
- [Stephen Cleary's Async/Await Best Practices](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming)

---

**[← Back to Documentation Hub](../readme.md)**
