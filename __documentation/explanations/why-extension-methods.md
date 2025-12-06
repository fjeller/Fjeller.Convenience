﻿# Why Extension Methods?

**💡 Explanation**

---

## What Are Extension Methods?

Extension methods let you "add" methods to existing types without modifying them:

```csharp
// Traditional utility method
public static class StringHelper
{
    public static bool IsEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}

// Usage
bool empty = StringHelper.IsEmpty(myString);

// Extension method
public static class StringExtensions
{
    public static bool IsEmpty(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}

// Usage (more natural)
bool empty = myString.IsEmpty();
```

---

## The Philosophy Behind Fjeller.Convenience

### 1. Readability Through Fluency

Extension methods enable fluent, readable code:

```csharp
// Without extensions (nested calls)
if (!string.IsNullOrWhiteSpace(userName))
{
    var trimmed = userName.Trim();
    var lower = trimmed.ToLower();
    // Use lower
}

// With extensions (left-to-right flow)
if (userName.HasValue())
{
    var processed = userName.Trim().ToLower();
    // Use processed
}
```

### 2. Discoverability

Extensions appear in IntelliSense on the type:

```csharp
string text = "...";
text. // IntelliSense shows all string methods + extensions
     // .HasValue(), .IsEmpty(), .ToInt32(), etc.
```

This makes functionality easier to discover than static utility classes.

### 3. Method Chaining

Extensions enable fluent method chains:

```csharp
string result = input
    .Trim()
    .ToLower()
    .EnsureStartsWith("/")
    .EnsureEndsWith("/");

var items = collection
    .WhereNotNull()
    .Where(x => x.IsValid())
    .Select(x => x.Value)
    .ToList();
```

### 4. Null-Conditional Operator Support

Extensions work with the null-conditional operator:

```csharp
string? nullable = GetString();
bool isEmpty = nullable?.IsEmpty() ?? true;

int? value = nullable?.ToNullableInt32();
```

---

## Design Principles

### Principle 1: Extensions Should Feel Native

Good extensions feel like they belong to the type:

```csharp
// Feels natural on string
if (email.IsEmail())

// Feels natural on list
list.AddIfNotNull(item);

// Feels natural on dictionary
dict.AddIfNotNull(key, value);
```

### Principle 2: Consistent Naming

Extensions follow .NET naming conventions:

- **Is** prefix for boolean checks: `IsEmpty()`, `IsEmail()`, `IsNull()`
- **To** prefix for conversions: `ToInt32()`, `ToGuid()`, `ToCultureInfo()`
- **Has** prefix for state checks: `HasValue()`, `HasNoValue()`
- Verbs for actions: `AddIfNotNull()`, `EnsureStartsWith()`

### Principle 3: Fail Gracefully

Extensions should handle edge cases:

```csharp
// Handles null input gracefully
string? nullString = null;
bool empty = nullString.IsEmpty(); // true, not NullReferenceException

int value = nullString.ToInt32(); // 0, not exception
```

### Principle 4: Minimize Allocations

Where possible, extensions avoid unnecessary allocations:

```csharp
// No allocation if already starts with value
string result = path.EnsureStartsWith("/");

// Minimal allocation for filtering
var valid = items.WhereNotNull(); // Deferred execution
```

---

## Extension Methods vs. Alternatives

### vs. Static Helper Classes

```csharp
// Static helper
if (StringHelper.IsNullOrWhiteSpace(value))

// Extension
if (value.IsEmpty())
```

**Advantages of extensions:**
- More natural syntax
- Better IntelliSense
- Chainable
- Works with null-conditional operator

### vs. Inheritance

```csharp
// You can't inherit from sealed types like string
// Extensions solve this

public static class StringExtensions
{
    public static bool IsEmail(this string? value) { ... }
}
```

**Advantages of extensions:**
- Works on sealed types
- No inheritance hierarchy
- Non-invasive

### vs. Utility Methods

```csharp
// Utility class
public static class Utils
{
    public static bool IsValid(string email) { ... }
    public static int ParseInt(string value) { ... }
    public static string Clean(string input) { ... }
}

// Extensions organized by type
public static class StringExtensions
{
    public static bool IsEmail(this string value) { ... }
    public static int ToInt32(this string value) { ... }
    public static string StripTags(this string value) { ... }
}
```

**Advantages of extensions:**
- Organized by type, not by module
- Discoverable through IntelliSense
- Natural syntax

---

## Real-World Benefits

### Validation Pipelines

```csharp
public class UserValidator
{
    public bool ValidateEmail(string? email)
    {
        return email.HasValue() && email.IsEmail();
    }

    public bool ValidateAge(string? ageInput)
    {
        int age = ageInput.ToInt32(defaultValue: 0);
        return age > 0 && age < 150;
    }
}
```

### Configuration Loading

```csharp
public class AppSettings
{
    public int MaxRetries { get; }
    public int TimeoutSeconds { get; }

    public AppSettings(IConfiguration config)
    {
        MaxRetries = config["MaxRetries"].ToInt32(defaultValue: 3);
        TimeoutSeconds = config["Timeout"].ToInt32(defaultValue: 30);
    }
}
```

### Data Processing

```csharp
public List<Product> ProcessCsvLine(string line)
{
    var fields = line.Split(',');

    var products = fields
        .WhereNotNull()
        .Select(field => field.Trim())
        .Where(field => field.HasValue())
        .Select(field => new Product { Name = field })
        .ToList();

    return products;
}

public class Product
{
    public string Name { get; set; } = string.Empty;
}
```

---

## When NOT to Use Extension Methods

### ❌ Avoid When It Doesn't Fit

Don't force extension syntax when it doesn't make sense:

```csharp
// BAD: Doesn't feel natural
public static void ExtensionMethod(this int number, string message, Logger logger)
{
    logger.Log($"{message}: {number}");
}

// GOOD: Use regular method
public static class Logger
{
    public static void LogNumber(int number, string message)
    {
        Console.WriteLine($"{message}: {number}");
    }
}
```

### ❌ Avoid Overloading Core Methods

Don't create extensions that conflict with existing methods:

```csharp
// BAD: Conflicts with string.Substring
public static string Substring(this string value, int start)

// GOOD: Use different name
public static string GetSubstring(this string value, int start)
```

### ❌ Avoid Complex Logic

Keep extensions simple. Complex logic belongs in dedicated classes:

```csharp
// BAD: Too complex for extension
public static string ProcessComplexBusinessLogic(this string input)
{
    // 100 lines of complex logic
}

// GOOD: Use service class
public class BusinessLogicProcessor
{
    public string Process(string input)
    {
        // Complex logic here
    }
}
```

---

## The "this" Keyword Magic

The `this` keyword in the first parameter makes a static method an extension:

```csharp
// Static method
public static bool IsEmpty(string value)

// Extension method (note the "this")
public static bool IsEmpty(this string? value)
```

Under the hood, extensions are just syntactic sugar:

```csharp
// These are equivalent
value.IsEmpty()
StringExtensions.IsEmpty(value)
```

---

## Organizing Extensions

### By Type

Fjeller.Convenience organizes extensions by the type they extend:

```
Extensions/
  ├── StringExtensions.cs       // string extensions
  ├── ListExtensions.cs          // IList<T> extensions
  ├── DictionaryExtensions.cs    // IDictionary<K,V> extensions
  ├── EnumerableExtensions.cs    // IEnumerable<T> extensions
  ├── NullableExtensions.cs      // T? extensions
  └── GenericObjectExtensions.cs // Generic reference type extensions
```

### Namespace Strategy

Use a consistent namespace:

```csharp
namespace Fjeller.Convenience.Extensions
{
    public static class StringExtensions { ... }
}
```

Users import once:

```csharp
using Fjeller.Convenience.Extensions;

// All extensions available
string.IsEmpty()
list.AddIfNotNull()
dict.Get()
```

---

## Performance Considerations

### Negligible Overhead

Extension methods have minimal performance impact:

```csharp
// Direct call
string.IsNullOrWhiteSpace(value)

// Extension call (minimal overhead)
value.IsEmpty()
```

The difference is a single additional method call, which is negligible in most scenarios.

### When to Inline

Only inline if profiling shows a bottleneck:

```csharp
// If IsEmpty() is called millions of times in a tight loop
for (int i = 0; i < 1000000; i++)
{
    // Consider inlining
    if (string.IsNullOrWhiteSpace(value))
    {
        // ...
    }
}
```

For typical usage, the readability benefit far outweighs the minimal performance cost.

---

## Community Impact

Extension methods have become a .NET best practice:

- **LINQ**: Built entirely on extension methods (`Where`, `Select`, etc.)
- **Entity Framework**: Uses extensions for querying (`Include`, `ThenInclude`)
- **ASP.NET Core**: Uses extensions for configuration (`AddControllers`, `UseRouting`)

Fjeller.Convenience follows this established pattern.

---

## See Also

- **[StringExtensions Reference](../reference/stringextensions.md)** – String extension examples
- **[Collection Operations How-To](../how-to/collection-operations.md)** – Collection extension patterns
- [Microsoft Docs: Extension Methods](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

---

**[← Back to Documentation Hub](../readme.md)**
