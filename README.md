﻿# Fjeller.Convenience

A collection of extension methods and utility classes that provide standard functionality for .NET applications, designed to simplify development and improve code readability.

[![NuGet](https://img.shields.io/nuget/v/Fjeller.Convenience.svg)](https://www.nuget.org/packages/Fjeller.Convenience/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

---

## 🚀 Quick Start

### Installation

```bash
dotnet add package Fjeller.Convenience
```

### Basic Usage

```csharp
using Fjeller.Convenience.Extensions;

// Safe string conversions with defaults
string userInput = "42";
int value = userInput.ToInt32(defaultValue: 0);

// Null-safe string checks
if (userInput.HasValue())
{
    Console.WriteLine("User provided input!");
}

// Validate email addresses
string email = "user@example.com";
if (email.IsEmail())
{
    SendEmail(email);
}

// Collection helpers
var list = new List<string>();
list.AddIfNotNull("Hello");
list.AddIfNotNull(null); // Does nothing

// Dictionary helpers with safe retrieval
var config = new Dictionary<string, string> { ["theme"] = "dark" };
string theme = config.Get("theme", "light"); // "dark"
string missing = config.Get("timeout", "30"); // "30" (default)
```

---

## 📚 Documentation

**Complete documentation is available in the [`__documentation`](__documentation/readme.md) folder.**

### Quick Links

- **[Getting Started Tutorial](__documentation/tutorials/getting-started.md)** – Learn the basics with a hands-on walkthrough
- **[API Reference](__documentation/api-reference.md)** – Complete alphabetical index of all methods
- **[How-To Guides](__documentation/readme.md#how-to-guides)** – Solve specific problems
- **[Explanations](__documentation/readme.md#understanding-fjellerconvenience)** – Understand design decisions

---

## 📦 What's Included

### String Extensions ([Reference](__documentation/reference/stringextensions.md))

**Validation:**
- `HasValue()` / `IsEmpty()` – Check for meaningful content
- `IsEmail()` / `IsUrl()` – Validate formats
- `IsGuid()` / `IsDateTime()` / `IsCulture()` – Type validation
- `IsUpper()` / `IsLower()` – Case checking

**Safe Conversions:**
- `ToInt32()` / `ToInt64()` / `ToInt16()` – Integer conversions
- `ToDouble()` / `ToSingle()` / `ToDecimal()` – Floating-point conversions
- `ToByte()` / `ToSByte()` – Byte conversions
- `ToUInt16()` / `ToUInt32()` / `ToUInt64()` – Unsigned integer conversions
- `ToBoolean()` / `ToGuid()` / `ToCultureInfo()` – Other type conversions
- All conversions have nullable variants (e.g., `ToNullableInt32()`)

**Manipulation:**
- `EnsureStartsWith()` / `EnsureEndsWith()` – Ensure prefix/suffix
- `EndsWithOneOf()` – Check multiple endings
- `ValueOrDefault()` – Null coalescing
- `StripTags()` / `StripEvents()` – HTML sanitization

### List Extensions ([Reference](__documentation/reference/listextensions.md))

- `AddIfNotNull<T>()` – Add only non-null items
- `InsertIfNotNull<T>()` – Insert only non-null items
- `AddIf<T>()` / `InsertIf<T>()` – Conditional operations
- `RemoveAll<T>()` – Remove multiple items

### Dictionary Extensions ([Reference](__documentation/reference/dictionaryextensions.md))

- `AddIfNotNull<TKey, TValue>()` – Add only non-null values
- `Get<TKey, TValue>()` – Safe retrieval with defaults

### Enumerable Extensions ([Reference](__documentation/reference/enumerableextensions.md))

- `WhereNotNull<T>()` – Filter out null elements
- `ForEach<T>()` – Execute action on each element

### Nullable Extensions ([Reference](__documentation/reference/nullableextensions.md))

- `HasNoValue<T>()` – Check if nullable has no value
- `HasNoValueOrDefault<T>()` – Check if null or equals default

### Generic Object Extensions ([Reference](__documentation/reference/genericobjectextensions.md))

- `IsNull<T>()` / `IsNotNull<T>()` – Fluent null checking

### AsyncHelper ([Reference](__documentation/reference/asynchelper.md))

- `RunSync<TResult>()` – Execute async methods synchronously
- `RunSync()` – Execute async void methods synchronously

---

## 💡 Key Features

### 🛡️ Safe by Design

No exceptions thrown for invalid conversions – always returns meaningful defaults:

```csharp
string invalid = "not a number";
int value = invalid.ToInt32(defaultValue: 0); // Returns 0, no exception
```

### 🌍 Culture-Aware

Numeric conversions use invariant culture by default, with opt-in culture support:

```csharp
// Invariant culture (default)
"3.14".ToDouble(); // Always works

// Specific culture
"3,14".ToDouble(culture: new CultureInfo("de-DE")); // German format
```

### 🔗 Fluent and Chainable

Extension methods enable natural, readable code:

```csharp
string result = input
    .Trim()
    .EnsureStartsWith("/")
    .EnsureEndsWith("/");

var valid = items
    .WhereNotNull()
    .Where(x => x.IsValid())
    .ToList();
```

### 📘 Well-Documented

Comprehensive documentation following the [Diátaxis framework](https://diataxis.fr/):
- **Tutorials** for learning
- **How-to guides** for problem-solving
- **Reference** for lookup
- **Explanations** for understanding

---

## 🎯 Supported Platforms

- **.NET 8.0** and later
- **.NET 9.0** and later
- **.NET 10.0** and later

---

## 📖 Learn More

### Tutorials
- [Getting Started](__documentation/tutorials/getting-started.md) – Complete beginner walkthrough

### How-To Guides
- [Convert Strings Safely](__documentation/how-to/string-conversions.md)
- [Validate String Input](__documentation/how-to/string-validation.md)
- [Manipulate HTML Content](__documentation/how-to/html-manipulation.md)
- [Work with Collections](__documentation/how-to/collection-operations.md)
- [Handle Async/Sync Scenarios](__documentation/how-to/async-operations.md)

### Explanations
- [Why Extension Methods?](__documentation/explanations/why-extension-methods.md)
- [Safe Type Conversions Explained](__documentation/explanations/safe-type-conversions.md)
- [Culture Handling in Conversions](__documentation/explanations/culture-handling.md)

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

---

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## 🔗 Links

- **[Documentation Hub](__documentation/readme.md)** – Complete documentation
- **[NuGet Package](https://www.nuget.org/packages/Fjeller.Convenience/)**
- **[GitHub Repository](https://github.com/fjeller/Fjeller.Convenience)**
- **[Report Issues](https://github.com/fjeller/Fjeller.Convenience/issues)**

---

## 📝 Status

Currently in **alpha**. API may change. Correct functionality not guaranteed for production use.

---

**Made with ❤️ for the .NET community**
