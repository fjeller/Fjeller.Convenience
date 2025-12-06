﻿# DictionaryExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `DictionaryExtensions` class provides extension methods for `IDictionary<TKey, TValue>` collections, offering null-safe addition and safe retrieval with default values.

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Methods

### AddIfNotNull

Adds the specified key and value to the dictionary if the value is not null.

```csharp
public static void AddIfNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue? value)
    where TKey : notnull
    where TValue : class
```

#### Type Parameters

- **TKey**: The type of the keys in the dictionary. Must be non-nullable.
- **TValue**: The type of the values in the dictionary. Must be a reference type.

#### Parameters

- **dictionary** (`IDictionary<TKey, TValue>`): The dictionary to add the key and value to.
- **key** (`TKey`): The key of the element to add.
- **value** (`TValue?`): The value of the element to add. If null, the key-value pair is not added.

#### Examples

```csharp
var settings = new Dictionary<string, string>();
settings.AddIfNotNull("theme", "dark");
settings.AddIfNotNull("timeout", null);

// settings contains: { ["theme"] = "dark" }
// "timeout" was not added because value was null
```

```csharp
var userPreferences = new Dictionary<int, UserProfile>();
userPreferences.AddIfNotNull(1, new UserProfile { Name = "Alice" });
userPreferences.AddIfNotNull(2, null);

// Only key 1 is in the dictionary
```

---

### Get (With Default Value)

Tries to get the value associated with the specified key. If the key does not exist or the key is null, returns the provided default value.

```csharp
public static TValue? Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey? key, TValue? defaultValue)
```

#### Type Parameters

- **TKey**: The type of the keys in the dictionary.
- **TValue**: The type of the values in the dictionary.

#### Parameters

- **dictionary** (`IDictionary<TKey, TValue>`): The dictionary to retrieve the value from.
- **key** (`TKey?`): The key whose value to get. If null, returns the default value.
- **defaultValue** (`TValue?`): The value to return if the key is not found or key is null.

#### Returns

`TValue?`: The value associated with the key, or `defaultValue` if the key is not found or key is null.

#### Examples

```csharp
var config = new Dictionary<string, string>
{
    ["host"] = "localhost",
    ["port"] = "8080"
};

string host = config.Get("host", "127.0.0.1"); // "localhost"
string timeout = config.Get("timeout", "30"); // "30" (default)
string? nullKey = config.Get(null, "fallback"); // "fallback"
```

```csharp
var scores = new Dictionary<string, int>
{
    ["Alice"] = 95,
    ["Bob"] = 87
};

int aliceScore = scores.Get("Alice", 0); // 95
int charlieScore = scores.Get("Charlie", 0); // 0 (default)
```

---

### Get (With Type Default)

Tries to get the value associated with the specified key. If the key does not exist or the key is null, returns the default value for the value type.

```csharp
public static TValue? Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey? key)
```

#### Type Parameters

- **TKey**: The type of the keys in the dictionary.
- **TValue**: The type of the values in the dictionary.

#### Parameters

- **dictionary** (`IDictionary<TKey, TValue>`): The dictionary to retrieve the value from.
- **key** (`TKey?`): The key whose value to get. If null, returns the default value for the value type.

#### Returns

`TValue?`: The value associated with the key, or the default value for `TValue` if the key is not found or key is null.

#### Examples

```csharp
var counts = new Dictionary<string, int>
{
    ["apples"] = 5,
    ["oranges"] = 3
};

int apples = counts.Get("apples"); // 5
int bananas = counts.Get("bananas"); // 0 (default(int))
```

```csharp
var cache = new Dictionary<string, string?>
{
    ["key1"] = "value1"
};

string? value1 = cache.Get("key1"); // "value1"
string? missing = cache.Get("key2"); // null (default(string))
```

---

## Usage Patterns

### Configuration Management

```csharp
var appConfig = new Dictionary<string, string>
{
    ["ApiUrl"] = "https://api.example.com",
    ["Timeout"] = "30"
};

// Safe retrieval with defaults
string apiUrl = appConfig.Get("ApiUrl", "https://localhost");
string timeout = appConfig.Get("Timeout", "60");
string retries = appConfig.Get("Retries", "3");

// Conditional addition
appConfig.AddIfNotNull("CacheDir", GetCacheDirectory());
```

### Building Objects from Partial Data

```csharp
var userData = new Dictionary<string, string>();

// Only add non-null values
userData.AddIfNotNull("firstName", GetFirstName());
userData.AddIfNotNull("lastName", GetLastName());
userData.AddIfNotNull("email", GetEmail());

// Safely read with defaults
var user = new User
{
    FirstName = userData.Get("firstName", "Unknown"),
    LastName = userData.Get("lastName", "Unknown"),
    Email = userData.Get("email", "no-email@example.com")
};
```

---

## See Also

- **[Collection Operations How-To](../how-to/collection-operations.md)** – Practical dictionary patterns
- **[ListExtensions Reference](listextensions.md)** – Extensions for lists
- **[EnumerableExtensions Reference](enumerableextensions.md)** – Extensions for IEnumerable<T>

---

**[← Back to Documentation Hub](../readme.md)**
