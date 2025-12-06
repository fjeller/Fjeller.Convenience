﻿# EnumerableExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `EnumerableExtensions` class provides extension methods for `IEnumerable<T>` sequences, offering null filtering and iteration helpers.

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Methods

### WhereNotNull

Filters a sequence of reference type elements, returning only the non-null elements.

```csharp
public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
```

#### Type Parameters

- **T**: The reference type of the elements in the source sequence.

#### Parameters

- **source** (`IEnumerable<T?>`): The sequence to filter.

#### Returns

`IEnumerable<T>`: An enumerable that contains only the non-null elements from the input sequence.

#### Exceptions

- **ArgumentNullException**: Thrown if `source` is null.

#### Examples

```csharp
string?[] mixedArray = { "Alice", null, "Bob", null, "Charlie" };
IEnumerable<string> names = mixedArray.WhereNotNull();

// names contains: ["Alice", "Bob", "Charlie"]
```

```csharp
List<Person?> people = new()
{
    new Person { Name = "Alice" },
    null,
    new Person { Name = "Bob" },
    null
};

IEnumerable<Person> validPeople = people.WhereNotNull();
// validPeople contains only non-null Person objects
```

#### Remarks

This method is particularly useful when working with LINQ queries where null values need to be filtered out before further processing.

```csharp
var result = GetPotentiallyNullValues()
    .WhereNotNull()
    .Select(x => x.Property)
    .ToList();
```

---

### ForEach

Executes the specified action on each element of the `IEnumerable<T>` sequence.

```csharp
public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
```

#### Type Parameters

- **T**: The type of the elements in the source sequence.

#### Parameters

- **source** (`IEnumerable<T>`): The sequence whose elements the action will be performed on.
- **action** (`Action<T>`): The delegate to perform on each element of the sequence.

#### Exceptions

- **ArgumentNullException**: Thrown if `source` or `action` is null.

#### Examples

```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };
numbers.ForEach(n => Console.WriteLine(n));

// Output:
// 1
// 2
// 3
// 4
// 5
```

```csharp
var users = GetUsers();
users.ForEach(user => user.IsActive = true);
```

```csharp
var fileNames = new[] { "file1.txt", "file2.txt", "file3.txt" };
fileNames.ForEach(fileName =>
{
    Console.WriteLine($"Processing {fileName}");
    ProcessFile(fileName);
});
```

#### Remarks

This method provides a convenient way to iterate over a sequence and perform side effects. Note that this converts the enumerable to a list internally, so it will enumerate the entire sequence immediately.

For pure functional transformations without side effects, prefer LINQ methods like `Select`, `Where`, etc.

---

## Usage Patterns

### Filtering Null Values in LINQ Chains

```csharp
var validEmails = GetEmailAddresses()
    .WhereNotNull()
    .Where(email => email.Contains("@"))
    .Select(email => email.ToLower())
    .ToList();
```

### Processing Collections with Side Effects

```csharp
GetLogEntries()
    .Where(entry => entry.Level == LogLevel.Error)
    .ForEach(entry => SendAlert(entry));
```

### Combining Both Methods

```csharp
GetOptionalData()
    .WhereNotNull()
    .ForEach(data => ProcessData(data));
```

---

## Performance Considerations

### WhereNotNull

- **Deferred execution**: The filtering is performed lazily as the sequence is enumerated.
- **Best for**: LINQ query chains where null filtering is needed.

### ForEach

- **Immediate execution**: Converts the enumerable to a list and iterates immediately.
- **Best for**: Performing side effects on each element when immediate execution is acceptable.
- **Alternative**: For better control over execution, use a standard `foreach` loop.

---

## See Also

- **[Collection Operations How-To](../how-to/collection-operations.md)** – Practical collection patterns
- **[ListExtensions Reference](listextensions.md)** – Extensions for lists
- **[DictionaryExtensions Reference](dictionaryextensions.md)** – Extensions for dictionaries

---

**[← Back to Documentation Hub](../readme.md)**
