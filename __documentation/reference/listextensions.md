﻿# ListExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `ListExtensions` class provides extension methods for `IList<T>` collections, enabling conditional additions, insertions, and bulk operations.

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Methods

### AddIfNotNull

Adds the specified item to the list if the item is not null.

```csharp
public static IList<T> AddIfNotNull<T>(this IList<T> list, T? item) where T : class
```

#### Type Parameters

- **T**: The type of elements in the list. Must be a reference type.

#### Parameters

- **list** (`IList<T>`): The list to which the item will be added.
- **item** (`T?`): The item to add if it is not null.

#### Returns

`IList<T>`: The list itself, for method chaining.

#### Examples

```csharp
var names = new List<string>();
names.AddIfNotNull("Alice");
names.AddIfNotNull(null);
names.AddIfNotNull("Bob");

// names contains: ["Alice", "Bob"]
```

---

### InsertIfNotNull

Inserts the specified item at the given index if the item is not null.

```csharp
public static IList<T> InsertIfNotNull<T>(this IList<T> list, int index, T? item) where T : class
```

#### Type Parameters

- **T**: The type of elements in the list. Must be a reference type.

#### Parameters

- **list** (`IList<T>`): The list to which the item will be inserted.
- **index** (`int`): The zero-based index at which the item should be inserted.
- **item** (`T?`): The item to insert if it is not null.

#### Returns

`IList<T>`: The list itself, for method chaining.

#### Examples

```csharp
var names = new List<string> { "Alice", "Charlie" };
names.InsertIfNotNull(1, "Bob");
names.InsertIfNotNull(1, null);

// names contains: ["Alice", "Bob", "Charlie"]
```

---

### AddIf

Adds the specified item to the list if the given condition is true for the item.

```csharp
public static IList<T> AddIf<T>(this IList<T> list, T item, Func<T, bool> condition)
```

#### Type Parameters

- **T**: The type of elements in the list.

#### Parameters

- **list** (`IList<T>`): The list to which the item will be added.
- **item** (`T`): The item to add if the condition is true.
- **condition** (`Func<T, bool>`): A function that determines whether the item should be added.

#### Returns

`IList<T>`: The list itself, for method chaining.

#### Examples

```csharp
var numbers = new List<int>();
numbers.AddIf(5, n => n > 0);
numbers.AddIf(-3, n => n > 0);
numbers.AddIf(10, n => n % 2 == 0);

// numbers contains: [5, 10]
```

---

### InsertIf

Inserts the specified item at the given index if the given condition is true for the item.

```csharp
public static IList<T> InsertIf<T>(this IList<T> list, int index, T item, Func<T, bool> condition)
```

#### Type Parameters

- **T**: The type of elements in the list.

#### Parameters

- **list** (`IList<T>`): The list to which the item will be inserted.
- **index** (`int`): The zero-based index at which the item should be inserted.
- **item** (`T`): The item to insert if the condition is true.
- **condition** (`Func<T, bool>`): A function that determines whether the item should be inserted.

#### Returns

`IList<T>`: The list itself, for method chaining.

#### Examples

```csharp
var numbers = new List<int> { 1, 5 };
numbers.InsertIf(1, 3, n => n < 10);
numbers.InsertIf(1, 20, n => n < 10);

// numbers contains: [1, 3, 5]
```

---

### RemoveAll

Removes all specified items from the list.

```csharp
public static IList<T> RemoveAll<T>(this IList<T> list, params T[] items)
```

#### Type Parameters

- **T**: The type of elements in the list.

#### Parameters

- **list** (`IList<T>`): The list from which the items will be removed.
- **items** (`params T[]`): The items to remove from the list.

#### Returns

`IList<T>`: The list itself, for method chaining.

#### Examples

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.RemoveAll(2, 4);

// numbers contains: [1, 3, 5]
```

---

## Method Chaining

All methods return the list itself, enabling fluent method chaining:

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

## See Also

- **[Collection Operations How-To](../how-to/collection-operations.md)** – Practical collection manipulation patterns
- **[EnumerableExtensions Reference](enumerableextensions.md)** – Extensions for IEnumerable<T>
- **[DictionaryExtensions Reference](dictionaryextensions.md)** – Extensions for dictionaries

---

**[← Back to Documentation Hub](../readme.md)**
