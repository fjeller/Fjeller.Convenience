# Fjeller.Convenience
A collection of convenience Methods and classes, mostly Extension methods, that provide some standard functionality for .NET Applications.

## Overview
This repository contains a collection of extension methods and other classes for common .NET types, designed to simplify development and improve 
code readability. The reason to create this package was basically to have some convenience extension methods ready which I had to write everytime 
in every project.

Currently in alpha. Correct functionality not guaranteed.

The following methods are currently implemented:

### Fjeller.Convenience.Extensions.DictionaryExtensions
Dictionary utility:
- `AddIfNotNull()`: Adds a key-value pair to a dictionary only if the value is not null.
- `Get(key, defaultValue)`: Tries to get the value for a key; returns the provided default if the key is not found or is null.
- `Get(key)`: Tries to get the value for a key; returns the default value for the value type if the key is not found or is null.

---

### Fjeller.Convenience.Extensions.EnumerableExtensions
IEnumerable sequence helpers:
- `WhereNotNull()`: Filters a sequence to only include non-null reference type elements.
- `ForEach()`: Executes an action for each element in a sequence.

---

### Fjeller.Convenience.Extensions.GenericObjectExtensions
Null-checking helpers for reference types:
- `IsNotNull()`: Returns true if the object is not null.
- `IsNull()`: Returns true if the object is null.

---

### Fjeller.Convenience.Extensions.ListExtensions
List utility:
- `AddIfNotNull()`: Adds an item to a list only if it is not null.

---

### Fjeller.Convenience.Extensions.NullableExtensions
Nullable value type helpers:
- `HasNoValue()`: Returns true if a nullable value type has no value.
- `HasNoValueOrDefault()`: Returns true if a nullable value type is unset or equals a specified default value.

---

### Fjeller.Convenience.Extensions.StringExtensions
A comprehensive set of string extension methods for validation, conversion, and manipulation:
- `HasValue()`: Checks if a string is not null, empty, or whitespace.
- `IsEmpty()`: Checks if a string is null, empty, or whitespace.
- `ToInt32()`: Converts a string to an integer, returning a default if conversion fails.
- `ToNullableInt32()`: Converts a string to a nullable integer, or returns a default/null if conversion fails.
- `ToInt64()`: Converts a string to a long, with a default fallback.
- `ToNullableInt64()`: Converts a string to a nullable long, or returns a default/null if conversion fails.
- `ToDouble()`: Converts a string to a double, using a specified or invariant culture, with a default fallback.
- `ToNullableDouble()`: Converts a string to a nullable double, using a specified or invariant culture, or returns a default/null if conversion fails.
- `ToByte()`: Converts a string to a byte, with a default fallback.
- `ToNullableByte()`: Converts a string to a nullable byte, or returns a default/null if conversion fails.
- `ToGuid()`: Converts a string to a Guid, with a default fallback.
- `ToNullableGuid()`: Converts a string to a nullable Guid, or returns null if conversion fails.
- `ToSingle()`: Converts a string to a float, using a specified or invariant culture, with a default fallback.
- `ToNullableSingle()`: Converts a string to a nullable float, using a specified or invariant culture, or returns a default/null if conversion fails.
- `ToDecimal()`: Converts a string to a decimal, using a specified or invariant culture, with a default fallback.
- `ToNullableDecimal()`: Converts a string to a nullable decimal, using a specified or invariant culture, or returns a default/null if conversion fails.
- `ToInt16()`: Converts a string to a short, with a default fallback.
- `ToNullableInt16()`: Converts a string to a nullable short, or returns a default/null if conversion fails.
- `ToUInt16()`: Converts a string to an unsigned short, with a default fallback.
- `ToNullableUInt16()`: Converts a string to a nullable unsigned short, or returns a default/null if conversion fails.
- `ToUInt32()`: Converts a string to an unsigned int, with a default fallback.
- `ToNullableUInt32()`: Converts a string to a nullable unsigned int, or returns a default/null if conversion fails.
- `ToUInt64()`: Converts a string to an unsigned long, with a default fallback.
- `ToNullableUInt64()`: Converts a string to a nullable unsigned long, or returns a default/null if conversion fails.
- `ToSByte()`: Converts a string to a signed byte, with a default fallback.
- `ToNullableSByte()`: Converts a string to a nullable signed byte, or returns a default/null if conversion fails.
- `ToBoolean()`: Converts a string to a boolean, with a default fallback.
- `ToCultureInfo()`: Converts a string to a CultureInfo, or returns null if conversion fails.
- `IsUpper()`: Checks if all letters in a string are uppercase.
- `IsLower()`: Checks if all letters in a string are lowercase.
- `ValueOrDefault()`: Returns the string or a fallback if it is null.
- `IsGuid()`: Checks if a string is a valid Guid.
- `IsDateTime()`: Checks if a string is a valid DateTime.
- `IsCulture()`: Checks if a string is a valid culture name.
- `EnsureStartsWith()`: Ensures a string starts with a given substring, adding it if missing.
- `EnsureEndsWith()`: Ensures a string ends with a given substring, adding it if missing.
- `IsEmail()`: Checks if a string matches an email address pattern.
- `IsUrl()`: Checks if a string matches a URL pattern.
- `StripEvents()`: Removes HTML event attributes (like onclick) from a string.
- `StripTags()`: Removes all HTML tags from a string.
- `StripTags(allowedTags)`: Removes all HTML tags except those specified in an allowed list.
- `StripTags(semicolonSeparatedAllowedTags)`: Removes all HTML tags except those specified in a semicolon-separated list.

---

### Fjeller.Convenience.SyncAsync.AsyncHelper
Async-to-sync bridging helpers:
- `RunSync<TResult>()`: Runs an asynchronous function and returns its result synchronously.
- `RunSync()`: Runs an asynchronous function synchronously, waiting for it to complete.

## Documentation
- [StringExtensions Documentation](__documentation/stringextensions.md)
- [GenericObjectExtensions Documentation](__documentation/genericobjectextensions.md)
- [DictionaryExtensions Documentation](__documentation/dictionaryextensions.md)
- [EnumerableExtensions Documentation](__documentation/enumerableextensions.md)
- [ListExtensions Documentation](__documentation/listextensions.md)
- [NullableExtensions Documentation](__documentation/nullableextensions.md)

## Projects

### Fjeller.Convenience
Contains the core extension methods and classes.

### Tests.Fjeller.Convenience
Contains unit tests for the extension methods and classes.

## How to Use
1. Clone the repository.
2. Add a reference to the `Fjeller.Convenience` project in your solution.
3. Use the extension methods in your code.

or

1. Install the nuget-Package into the projects where you want to use the methods
2. add `using Fjeller.Convenience.Extensions` and use the extension methods

## How to Run Tests
1. Open the solution in Visual Studio.
2. Build the solution.
3. Run the tests using the Test Explorer.

## License
This project is licensed under the MIT License.
