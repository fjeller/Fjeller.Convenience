﻿# How to Handle Async/Sync Scenarios

**📖 How-To Guide**

---

## Problem

You need to call asynchronous methods from synchronous code (e.g., constructors, property getters, synchronous interface implementations).

---

## Solution

Use `AsyncHelper` to bridge async and sync code when absolutely necessary. **⚠️ Prefer async/await whenever possible.**

---

## ⚠️ Before You Begin

**AsyncHelper should be your last resort.** Modern C# supports async/await in most scenarios:

- ✅ Use `async Task Main()` instead of synchronous Main
- ✅ Make your methods async when calling async APIs
- ✅ Use factory patterns instead of async constructors
- ✅ Convert interfaces to async when possible

**Only use AsyncHelper when you truly cannot make your code async.**

---

## Running Async Methods with Return Values

```csharp
using Fjeller.Convenience.SyncAsync;

public class DataService
{
    public string GetDataSync()
    {
        return AsyncHelper.RunSync(async () =>
        {
            var response = await _client.GetAsync("https://api.example.com/data");
            return await response.Content.ReadAsStringAsync();
        });
    }

    private readonly HttpClient _client = new();
}
```

---

## Running Async Methods Without Return Values

```csharp
public class Logger
{
    public void LogSync(string message)
    {
        AsyncHelper.RunSync(async () =>
        {
            await File.AppendAllTextAsync("log.txt", message + Environment.NewLine);
        });
    }
}
```

---

## When to Use AsyncHelper

### ✅ Acceptable Use Cases

#### 1. Constructor Initialization (With Caching)

```csharp
public class ConfigurationService
{
    private readonly string _apiKey;

    public ConfigurationService()
    {
        _apiKey = AsyncHelper.RunSync(async () =>
        {
            return await LoadApiKeyFromVaultAsync();
        });
    }

    private async Task<string> LoadApiKeyFromVaultAsync()
    {
        await Task.Delay(100); // Simulated async operation
        return "secret-key";
    }
}
```

#### 2. Legacy Interface Implementation

```csharp
public interface ILegacyRepository
{
    User GetUser(int id);
}

public class ModernRepository : ILegacyRepository
{
    private readonly IAsyncRepository _asyncRepo;

    public ModernRepository(IAsyncRepository asyncRepo)
    {
        _asyncRepo = asyncRepo;
    }

    public User GetUser(int id)
    {
        return AsyncHelper.RunSync(() => _asyncRepo.GetUserAsync(id));
    }
}

public interface IAsyncRepository
{
    Task<User> GetUserAsync(int id);
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
```

#### 3. Console Applications (Pre-C# 7.1)

```csharp
class Program
{
    static void Main(string[] args)
    {
        AsyncHelper.RunSync(async () =>
        {
            await RunApplicationAsync(args);
        });
    }

    static async Task RunApplicationAsync(string[] args)
    {
        Console.WriteLine("Starting...");
        await ProcessDataAsync();
        Console.WriteLine("Complete!");
    }

    static async Task ProcessDataAsync()
    {
        await Task.Delay(1000);
    }
}
```

**Better alternative (C# 7.1+):**

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting...");
        await ProcessDataAsync();
        Console.WriteLine("Complete!");
    }

    static async Task ProcessDataAsync()
    {
        await Task.Delay(1000);
    }
}
```

---

## Better Alternatives

### Factory Pattern for Async Construction

```csharp
public class Service
{
    private readonly string _data;

    private Service(string data)
    {
        _data = data;
    }

    public static async Task<Service> CreateAsync()
    {
        string data = await LoadDataAsync();
        return new Service(data);
    }

    private static async Task<string> LoadDataAsync()
    {
        await Task.Delay(100);
        return "loaded-data";
    }
}

// Usage
var service = await Service.CreateAsync();
```

### Lazy Async Initialization

```csharp
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
        return "lazy-data";
    }
}
```

### Async Interface Migration

```csharp
// Old synchronous interface
public interface IOldRepository
{
    User GetUser(int id);
}

// New async interface
public interface IRepository
{
    Task<User> GetUserAsync(int id);
}

// Migration wrapper
public class RepositoryAdapter : IOldRepository
{
    private readonly IRepository _repository;

    public RepositoryAdapter(IRepository repository)
    {
        _repository = repository;
    }

    public User GetUser(int id)
    {
        return AsyncHelper.RunSync(() => _repository.GetUserAsync(id));
    }
}
```

---

## Deadlock Risks

### ❌ Dangerous: Using in ASP.NET

```csharp
// DON'T DO THIS
public class BadController : Controller
{
    public IActionResult GetData()
    {
        // High risk of deadlock!
        var data = AsyncHelper.RunSync(async () =>
        {
            return await _service.GetDataAsync();
        });

        return Ok(data);
    }

    private readonly IDataService _service = null!;
}
```

### ✅ Correct: Use Async

```csharp
public class GoodController : Controller
{
    public async Task<IActionResult> GetData()
    {
        var data = await _service.GetDataAsync();
        return Ok(data);
    }

    private readonly IDataService _service = null!;
}
```

---

## Real-World Example: Migration Scenario

```csharp
public class DataMigrationHelper
{
    private readonly IModernAsyncApi _modernApi;

    public DataMigrationHelper(IModernAsyncApi modernApi)
    {
        _modernApi = modernApi;
    }

    // Legacy method that must remain synchronous
    public void MigrateData(List<LegacyData> data)
    {
        Console.WriteLine($"Migrating {data.Count} records...");

        AsyncHelper.RunSync(async () =>
        {
            foreach (var item in data)
            {
                await _modernApi.SaveAsync(item);
            }
        });

        Console.WriteLine("Migration complete");
    }
}

public interface IModernAsyncApi
{
    Task SaveAsync(LegacyData data);
}

public class LegacyData
{
    public int Id { get; set; }
    public string Value { get; set; } = string.Empty;
}
```

---

## Performance Implications

### Thread Blocking

```csharp
// This blocks a thread while waiting
public string SlowSync()
{
    return AsyncHelper.RunSync(async () =>
    {
        await Task.Delay(5000); // Thread is blocked for 5 seconds
        return "done";
    });
}
```

### Better: True Async

```csharp
// This doesn't block threads
public async Task<string> FastAsync()
{
    await Task.Delay(5000); // Thread is released during delay
    return "done";
}
```

---

## Best Practices

### ✅ Do:

- Use only when you cannot make your code async
- Document why AsyncHelper is necessary
- Consider refactoring to async when possible
- Use factory patterns for async construction
- Test for deadlocks in your specific environment

### ❌ Don't:

- Use in ASP.NET request pipeline
- Use on UI threads (WPF, WinForms)
- Use when the calling code could be made async
- Nest multiple RunSync calls
- Ignore performance implications

---

## Decision Tree

```
Need to call async method?
│
├─ Can you make your method async?
│  └─ YES → Use async/await ✅
│
├─ NO → Is it a constructor?
│  ├─ YES → Can you use factory pattern?
│  │  ├─ YES → Use static async factory ✅
│  │  └─ NO → Use AsyncHelper with caching ⚠️
│  │
│  └─ NO → Is it a property getter?
│     ├─ YES → Can you make it a method?
│     │  ├─ YES → Make it async method ✅
│     │  └─ NO → Use lazy async pattern ⚠️
│     │
│     └─ NO → Is it a legacy interface?
│        ├─ YES → Can you change the interface?
│        │  ├─ YES → Add async version ✅
│        │  └─ NO → Use AsyncHelper ⚠️
│        │
│        └─ NO → Reconsider your design 🤔
```

---

## See Also

- **[AsyncHelper Reference](../reference/asynchelper.md)** – Complete API documentation
- [Microsoft: Async/Await Best Practices](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming)
- [Stephen Cleary: Don't Block on Async Code](https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html)

---

**[← Back to Documentation Hub](../readme.md)**
