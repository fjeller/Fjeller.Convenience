﻿# How to Work with Collections

**📖 How-To Guide**

---

## Problem

You need to manipulate collections (lists, dictionaries, enumerables) with null-safe operations and conditional logic.

---

## Solution

Use Fjeller.Convenience's collection extension methods for adding, filtering, and iterating over collections safely.

---

## Adding Items Conditionally to Lists

### Add If Not Null

```csharp
using Fjeller.Convenience.Extensions;

var names = new List<string>();
names.AddIfNotNull("Alice");
names.AddIfNotNull(null);      // Does nothing
names.AddIfNotNull("Bob");

// names contains: ["Alice", "Bob"]
```

### Add Based on Condition

```csharp
var numbers = new List<int>();
numbers
    .AddIf(5, n => n > 0)
    .AddIf(-3, n => n > 0)     // Not added
    .AddIf(10, n => n % 2 == 0);

// numbers contains: [5, 10]
```

---

## Inserting Items

### Insert If Not Null

```csharp
var names = new List<string> { "Alice", "Charlie" };
names.InsertIfNotNull(1, "Bob");
names.InsertIfNotNull(0, null);    // Does nothing

// names contains: ["Alice", "Bob", "Charlie"]
```

### Insert Based on Condition

```csharp
var numbers = new List<int> { 1, 5 };
numbers
    .InsertIf(1, 3, n => n < 10)
    .InsertIf(0, 20, n => n < 10);  // Not inserted

// numbers contains: [1, 3, 5]
```

---

## Removing Multiple Items

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.RemoveAll(2, 4);

// numbers contains: [1, 3, 5]
```

---

## Working with Dictionaries

### Add If Not Null

```csharp
var settings = new Dictionary<string, string>();
settings.AddIfNotNull("theme", "dark");
settings.AddIfNotNull("timeout", null);  // Not added

// settings contains: { ["theme"] = "dark" }
```

### Safe Retrieval with Defaults

```csharp
var config = new Dictionary<string, string>
{
    ["host"] = "localhost",
    ["port"] = "8080"
};

string host = config.Get("host", "127.0.0.1");     // "localhost"
string timeout = config.Get("timeout", "30");      // "30" (default)
```

---

## Filtering Null Values from Sequences

```csharp
string?[] mixed = { "Alice", null, "Bob", null, "Charlie" };
IEnumerable<string> valid = mixed.WhereNotNull();

// valid contains: ["Alice", "Bob", "Charlie"]
```

### Use Case: Processing User Input

```csharp
public List<User> ProcessUserData(string?[] emails)
{
    return emails
        .WhereNotNull()
        .Where(e => e.IsEmail())
        .Select(e => new User { Email = e })
        .ToList();
}

public class User
{
    public string Email { get; set; } = string.Empty;
}
```

---

## Iterating with ForEach

```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };
numbers.ForEach(n => Console.WriteLine(n * 2));

// Output: 2, 4, 6, 8, 10
```

---

## Real-World Scenarios

### Building Dynamic Forms

```csharp
public class FormBuilder
{
    public List<FormField> BuildForm(UserPreferences prefs)
    {
        var fields = new List<FormField>();

        fields.AddIfNotNull(CreateTextField("name", "Name", true));
        fields.AddIfNotNull(CreateTextField("email", "Email", true));
        fields.AddIfNotNull(CreateTextField("phone", "Phone", prefs.RequirePhone));

        return fields;
    }

    private FormField? CreateTextField(string id, string label, bool required)
    {
        return required ? new FormField { Id = id, Label = label } : null;
    }
}

public class FormField
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}

public class UserPreferences
{
    public bool RequirePhone { get; set; }
}
```

### Processing API Responses

```csharp
public class ApiResponseProcessor
{
    public List<Product> ProcessProducts(ApiResponse response)
    {
        var products = new List<Product>();

        response.Items
            .WhereNotNull()
            .ForEach(item =>
            {
                products.AddIf(
                    new Product { Id = item.Id, Name = item.Name },
                    p => p.Id > 0 && p.Name.HasValue()
                );
            });

        return products;
    }
}

public class ApiResponse
{
    public List<ApiItem?> Items { get; set; } = new();
}

public class ApiItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
```

### Configuration Management

```csharp
public class ConfigurationManager
{
    private readonly Dictionary<string, string> _config = new();

    public void LoadConfiguration(Dictionary<string, string?> source)
    {
        foreach (var kvp in source)
        {
            _config.AddIfNotNull(kvp.Key, kvp.Value);
        }
    }

    public string GetValue(string key, string defaultValue = "")
    {
        return _config.Get(key, defaultValue);
    }

    public int GetIntValue(string key, int defaultValue = 0)
    {
        string value = _config.Get(key, "");
        return value.ToInt32(defaultValue);
    }
}
```

---

## Method Chaining

All list methods return the list for fluent chaining:

```csharp
var list = new List<string>();
list
    .AddIfNotNull("Alice")
    .AddIfNotNull(null)
    .AddIf("Bob", s => s.Length > 2)
    .InsertIfNotNull(1, "Charlie")
    .RemoveAll("Alice");

// list contains: ["Charlie", "Bob"]
```

---

## Best Practices

### ✅ Do:

- Use `AddIfNotNull` when building lists from potentially null sources
- Use `WhereNotNull` before LINQ operations on nullable sequences
- Use `Get` with meaningful defaults for dictionaries
- Chain operations for cleaner code
- Use `ForEach` for side effects, LINQ for transformations

### ❌ Don't:

- Overuse `ForEach` where LINQ methods (`Select`, `Where`) are more appropriate
- Forget that `ForEach` evaluates immediately (not deferred like LINQ)
- Use conditional adds without documenting the business logic

---

## See Also

- **[ListExtensions Reference](../reference/listextensions.md)** – Complete list API
- **[DictionaryExtensions Reference](../reference/dictionaryextensions.md)** – Complete dictionary API
- **[EnumerableExtensions Reference](../reference/enumerableextensions.md)** – Complete enumerable API

---

**[← Back to Documentation Hub](../readme.md)**
