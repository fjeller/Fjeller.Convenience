﻿# Fjeller.Convenience Documentation

Welcome to the comprehensive documentation for **Fjeller.Convenience** – a collection of extension methods and utility classes designed to simplify common .NET development tasks and improve code readability.

## About This Documentation

This documentation follows the [Diátaxis framework](https://diataxis.fr/), organizing content into four distinct types to serve different user needs:

- **📚 Tutorials** – Learning-oriented lessons for newcomers
- **📖 How-To Guides** – Problem-oriented recipes for specific tasks
- **📘 Reference** – Information-oriented technical descriptions
- **💡 Explanations** – Understanding-oriented discussions of key concepts

---

## Quick Navigation

### 🚀 Getting Started

**New to Fjeller.Convenience?** Start here:

- [Getting Started Tutorial](tutorials/getting-started.md) – A beginner-friendly walkthrough

### 📘 API Reference

Complete technical documentation for all extension methods:

- [StringExtensions Reference](reference/stringextensions.md) – String validation, conversion, and manipulation
- [ListExtensions Reference](reference/listextensions.md) – List utility methods
- [DictionaryExtensions Reference](reference/dictionaryextensions.md) – Dictionary helper methods
- [EnumerableExtensions Reference](reference/enumerableextensions.md) – IEnumerable sequence helpers
- [NullableExtensions Reference](reference/nullableextensions.md) – Nullable value type helpers
- [GenericObjectExtensions Reference](reference/genericobjectextensions.md) – Generic null-checking helpers
- [AsyncHelper Reference](reference/asynchelper.md) – Async-to-sync bridging utilities
- [Complete API Index](api-reference.md) – Alphabetical index of all methods

### 📖 How-To Guides

Solve specific problems with step-by-step guides:

- [How to Convert Strings Safely](how-to/string-conversions.md)
- [How to Validate String Input](how-to/string-validation.md)
- [How to Manipulate HTML Content](how-to/html-manipulation.md)
- [How to Work with Collections](how-to/collection-operations.md)
- [How to Handle Async/Sync Scenarios](how-to/async-operations.md)

### 💡 Understanding Fjeller.Convenience

Deep dives into design decisions and concepts:

- [Why Extension Methods?](explanations/why-extension-methods.md)
- [Safe Type Conversions Explained](explanations/safe-type-conversions.md)
- [Culture Handling in Conversions](explanations/culture-handling.md)

---

## Installation

### Via NuGet Package Manager

```bash
dotnet add package Fjeller.Convenience
```

### Via Package Manager Console

```powershell
Install-Package Fjeller.Convenience
```

### Manual Reference

Clone the repository and add a project reference:

```bash
git clone https://github.com/fjeller/Fjeller.Convenience
```

---

## Supported Platforms

- **.NET 8.0** and later
- **.NET 9.0** and later
- **.NET 10.0** and later

---

## Quick Example

```csharp
using Fjeller.Convenience.Extensions;

// Safe string conversions with defaults
string userInput = "42";
int value = userInput.ToInt32(defaultValue: 0);

// Null-safe checks
if (userInput.HasValue())
{
    Console.WriteLine("User provided input!");
}

// Collection helpers
var list = new List<string>();
list.AddIfNotNull(null); // Does nothing
list.AddIfNotNull("Hello"); // Adds "Hello"

// Dictionary helpers
var dict = new Dictionary<string, string>();
dict.AddIfNotNull("key", null); // Does nothing
string? result = dict.Get("missing", "default"); // Returns "default"
```

---

## Contributing

Contributions are welcome! Please read the [Contributing Guidelines](../CONTRIBUTING.md) before submitting pull requests.

---

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

---

## Support

- **Issues:** Report bugs or request features on [GitHub Issues](https://github.com/fjeller/Fjeller.Convenience/issues)
- **Discussions:** Ask questions on [GitHub Discussions](https://github.com/fjeller/Fjeller.Convenience/discussions)

---

## Documentation Conventions

Throughout this documentation:

- 📚 indicates tutorials
- 📖 indicates how-to guides
- 📘 indicates reference material
- 💡 indicates explanations

**Code examples** use C# 12+ syntax targeting .NET 8/9/10.
