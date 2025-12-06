﻿# NullableExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `NullableExtensions` class provides extension methods for nullable value types (`T?` where `T` is a struct), simplifying common null checks and default value comparisons.

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Methods

### HasNoValue

Determines whether the nullable value type does not have a value.

```csharp
public static bool HasNoValue<T>([NotNullWhen(false)] this T? nullable) where T : struct
```

#### Type Parameters

- **T**: The underlying value type.

#### Parameters

- **nullable** (`T?`): The nullable value to check.

#### Returns

`bool`: `true` if the nullable does not have a value; otherwise, `false`.

#### Examples

```csharp
int? number = null;
bool isEmpty = number.HasNoValue(); // true

int? withValue = 42;
bool hasValue = withValue.HasNoValue(); // false
```

```csharp
DateTime? optionalDate = null;
if (optionalDate.HasNoValue())
{
    Console.WriteLine("No date provided");
}
```

#### Remarks

This method is the inverse of the built-in `HasValue` property, providing a more intuitive API for checking null values.

```csharp
// Instead of:
if (!nullable.HasValue) { }

// You can write:
if (nullable.HasNoValue()) { }
```

---

### HasNoValueOrDefault

Determines whether the nullable value type does not have a value or equals the specified default value.

```csharp
public static bool HasNoValueOrDefault<T>([NotNullWhen(false)] this T? nullable, T defaultValue) where T : struct
```

#### Type Parameters

- **T**: The underlying value type.

#### Parameters

- **nullable** (`T?`): The nullable value to check.
- **defaultValue** (`T`): The default value to compare against.

#### Returns

`bool`: `true` if the nullable does not have a value or its value equals the default value; otherwise, `false`.

#### Examples

```csharp
int? number = null;
bool result = number.HasNoValueOrDefault(0); // true (no value)

int? zero = 0;
bool isDefaultOrNull = zero.HasNoValueOrDefault(0); // true (equals default)

int? five = 5;
bool isNotDefault = five.HasNoValueOrDefault(0); // false (has value and not default)
```

```csharp
DateTime? optionalDate = DateTime.MinValue;
if (optionalDate.HasNoValueOrDefault(DateTime.MinValue))
{
    Console.WriteLine("No valid date provided");
}
```

#### Remarks

This method is useful when you want to treat both null and a specific "sentinel" default value as equivalent to "no meaningful value".

Common use cases:
- Treating `0` as equivalent to null for numeric IDs
- Treating `DateTime.MinValue` as equivalent to null for dates
- Treating `Guid.Empty` as equivalent to null for identifiers

---

## Usage Patterns

### Input Validation

```csharp
public class UserProfile
{
    public int? Age { get; set; }

    public bool IsAgeValid()
    {
        return !Age.HasNoValueOrDefault(0) && Age.Value > 0 && Age.Value < 150;
    }
}
```

### Optional Parameters with Defaults

```csharp
public void ConfigureTimeout(int? timeout)
{
    if (timeout.HasNoValueOrDefault(0))
    {
        timeout = 30; // Use default timeout
    }

    SetTimeout(timeout.Value);
}
```

### Database Entity Validation

```csharp
public class Order
{
    public int? CustomerId { get; set; }
    public DateTime? OrderDate { get; set; }

    public bool IsValid()
    {
        if (CustomerId.HasNoValueOrDefault(0))
        {
            return false;
        }

        if (OrderDate.HasNoValueOrDefault(DateTime.MinValue))
        {
            return false;
        }

        return true;
    }
}
```

### Form Data Processing

```csharp
public void ProcessFormData(int? quantity, decimal? price)
{
    if (quantity.HasNoValue() || price.HasNoValue())
    {
        throw new ArgumentException("Quantity and price are required");
    }

    if (quantity.HasNoValueOrDefault(0))
    {
        throw new ArgumentException("Quantity must be greater than zero");
    }

    // Process with non-null, non-zero values
    var total = quantity.Value * price.Value;
}
```

---

## Comparison with Standard Approach

### HasNoValue vs. !HasValue

```csharp
// Standard approach
if (!nullable.HasValue)
{
    // Handle null
}

// With HasNoValue extension
if (nullable.HasNoValue())
{
    // Handle null - reads more naturally
}
```

### HasNoValueOrDefault vs. Manual Check

```csharp
// Standard approach
if (!nullable.HasValue || nullable.Value == 0)
{
    // Handle null or zero
}

// With HasNoValueOrDefault extension
if (nullable.HasNoValueOrDefault(0))
{
    // Handle null or zero - more concise
}
```

---

## Null-State Analysis

Both methods include the `[NotNullWhen(false)]` attribute, which helps the C# compiler's null-state analysis:

```csharp
int? nullable = GetNullableValue();

if (!nullable.HasNoValue())
{
    // Compiler knows nullable has a value here
    int value = nullable.Value; // No warning
}

if (!nullable.HasNoValueOrDefault(0))
{
    // Compiler knows nullable has a value here and it's not 0
    int value = nullable.Value; // No warning
}
```

---

## See Also

- **[GenericObjectExtensions Reference](genericobjectextensions.md)** – Null checking for reference types
- **[StringExtensions Reference](stringextensions.md)** – HasValue/IsEmpty for strings
- **[Collection Operations How-To](../how-to/collection-operations.md)** – Working with nullable values in collections

---

**[← Back to Documentation Hub](../readme.md)**
