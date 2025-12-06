﻿# GenericObjectExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `GenericObjectExtensions` class provides extension methods for reference types to simplify common null checks with improved readability and compiler null-state analysis support.

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Methods

### IsNotNull

Determines whether the specified object is not null.

```csharp
public static bool IsNotNull<T>([NotNullWhen(true)] this T? item) where T : class
```

#### Type Parameters

- **T**: The reference type of the object.

#### Parameters

- **item** (`T?`): The object to check.

#### Returns

`bool`: `true` if the object is not null; otherwise, `false`.

#### Examples

```csharp
string? text = "Hello";
if (text.IsNotNull())
{
    Console.WriteLine(text.Length); // Safe to access
}

string? nullText = null;
bool isValid = nullText.IsNotNull(); // false
```

```csharp
public class Person
{
    public string Name { get; set; }
}

Person? person = GetPerson();
if (person.IsNotNull())
{
    Console.WriteLine(person.Name); // Compiler knows person is not null
}
```

#### Remarks

This method improves code readability compared to `!= null` checks and provides better null-state analysis support through the `[NotNullWhen(true)]` attribute.

```csharp
// Instead of:
if (obj != null) { }

// You can write:
if (obj.IsNotNull()) { }
```

---

### IsNull

Determines whether the specified object is null.

```csharp
public static bool IsNull<T>([NotNullWhen(false)] this T? item) where T : class
```

#### Type Parameters

- **T**: The reference type of the object.

#### Parameters

- **item** (`T?`): The object to check.

#### Returns

`bool`: `true` if the object is null; otherwise, `false`.

#### Examples

```csharp
string? text = null;
if (text.IsNull())
{
    Console.WriteLine("Text is null");
}

string? validText = "Hello";
bool isNull = validText.IsNull(); // false
```

```csharp
public void ProcessData(Data? data)
{
    if (data.IsNull())
    {
        throw new ArgumentNullException(nameof(data));
    }

    // Compiler knows data is not null here
    Console.WriteLine(data.Value);
}
```

#### Remarks

This method provides a more fluent alternative to `== null` checks and works seamlessly with C#'s null-state analysis.

```csharp
// Instead of:
if (obj == null) { }

// You can write:
if (obj.IsNull()) { }
```

---

## Usage Patterns

### Validation and Guard Clauses

```csharp
public void ProcessOrder(Order? order)
{
    if (order.IsNull())
    {
        throw new ArgumentNullException(nameof(order));
    }

    // order is guaranteed non-null here
    Console.WriteLine($"Processing order {order.Id}");
}
```

### Conditional Logic

```csharp
public string GetDisplayName(User? user)
{
    if (user.IsNotNull())
    {
        return user.Name;
    }

    return "Anonymous";
}
```

### LINQ Query Filtering

```csharp
var validUsers = users
    .Where(u => u.IsNotNull())
    .Select(u => u.Name)
    .ToList();
```

### Method Chaining

```csharp
public class Builder
{
    private Config? _config;

    public Builder WithConfig(Config? config)
    {
        if (config.IsNotNull())
        {
            _config = config;
        }
        return this;
    }
}
```

---

## Comparison with Standard Approach

### IsNotNull vs. != null

```csharp
// Standard approach
if (obj != null)
{
    DoSomething(obj);
}

// With IsNotNull extension
if (obj.IsNotNull())
{
    DoSomething(obj);
}
```

### IsNull vs. == null

```csharp
// Standard approach
if (obj == null)
{
    return;
}

// With IsNull extension
if (obj.IsNull())
{
    return;
}
```

---

## Null-State Analysis

Both methods include attributes that help the C# compiler's null-state analysis:

### IsNotNull with [NotNullWhen(true)]

```csharp
string? nullable = GetString();

if (nullable.IsNotNull())
{
    // Compiler knows nullable is not null here
    int length = nullable.Length; // No warning
}
```

### IsNull with [NotNullWhen(false)]

```csharp
string? nullable = GetString();

if (nullable.IsNull())
{
    return;
}

// Compiler knows nullable is not null here
int length = nullable.Length; // No warning
```

---

## Advanced Usage

### Early Returns

```csharp
public void ProcessItems(List<Item>? items)
{
    if (items.IsNull())
    {
        return;
    }

    // items is guaranteed non-null
    foreach (var item in items)
    {
        ProcessItem(item);
    }
}
```

### Complex Conditionals

```csharp
public bool IsValid(User? user, Config? config)
{
    if (user.IsNull() || config.IsNull())
    {
        return false;
    }

    // Both user and config are non-null here
    return user.Age >= config.MinimumAge;
}
```

### Ternary Expressions

```csharp
string displayName = user.IsNotNull() ? user.Name : "Unknown";

int count = items.IsNotNull() ? items.Count : 0;
```

---

## Best Practices

### Use for Readability

Choose `IsNotNull()` and `IsNull()` when it improves code readability, especially in fluent chains:

```csharp
return GetUser()
    .Where(u => u.IsNotNull())
    .Select(u => u.Email)
    .FirstOrDefault();
```

### Prefer Standard Operators for Simple Checks

For simple null checks, standard operators are equally clear:

```csharp
// Both are fine
if (obj is not null) { }
if (obj.IsNotNull()) { }
```

### Combine with Other Checks

```csharp
if (user.IsNotNull() && user.Age >= 18)
{
    GrantAccess(user);
}
```

---

## See Also

- **[NullableExtensions Reference](nullableextensions.md)** – Null checking for nullable value types
- **[StringExtensions Reference](stringextensions.md)** – HasValue/IsEmpty for strings
- **[Collection Operations How-To](../how-to/collection-operations.md)** – Working with nullable collections

---

**[← Back to Documentation Hub](../readme.md)**
