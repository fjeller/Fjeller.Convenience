﻿# How to Convert Strings Safely

**📖 How-To Guide**

---

## Problem

You need to convert string input into strongly-typed values (numbers, dates, GUIDs, etc.) without risking exceptions from invalid input.

---

## Solution

Use Fjeller.Convenience's safe conversion extension methods, which return default values instead of throwing exceptions when conversion fails.

---

## Converting to Numbers

### Convert to Integer

```csharp
using Fjeller.Convenience.Extensions;

string userInput = "42";
int number = userInput.ToInt32(); // 42

string invalid = "not a number";
int fallback = invalid.ToInt32(defaultValue: 0); // 0
```

### Convert to Nullable Integer

When you want to distinguish between "valid zero" and "invalid input":

```csharp
string input = "0";
int? result = input.ToNullableInt32(); // 0

string invalid = "abc";
int? nullResult = invalid.ToNullableInt32(); // null

if (nullResult.HasValue)
{
    Console.WriteLine($"Valid number: {nullResult.Value}");
}
else
{
    Console.WriteLine("Invalid input");
}
```

### Convert to Long

For larger numbers:

```csharp
string bigNumber = "9223372036854775807";
long value = bigNumber.ToInt64(); // 9223372036854775807

string overflow = "99999999999999999999";
long safe = overflow.ToInt64(defaultValue: -1); // -1
```

---

## Converting to Decimal Types

### Convert to Decimal (for Currency)

```csharp
string price = "19.99";
decimal amount = price.ToDecimal(); // 19.99m

string invalid = "free";
decimal defaultPrice = invalid.ToDecimal(defaultValue: 0m); // 0m
```

### Convert to Double

```csharp
string pi = "3.14159";
double value = pi.ToDouble(); // 3.14159

string invalid = "infinity";
double fallback = invalid.ToDouble(defaultValue: 0.0); // 0.0
```

### Convert to Float

```csharp
string measurement = "3.5";
float value = measurement.ToSingle(); // 3.5f
```

---

## Culture-Specific Conversions

When working with numbers from different cultures (different decimal separators):

### Using Specific Cultures

```csharp
using System.Globalization;

// German format uses comma as decimal separator
string germanPrice = "19,99";
decimal price = germanPrice.ToDecimal(
    defaultValue: 0m,
    culture: new CultureInfo("de-DE")
); // 19.99m

// US format uses period
string usPrice = "19.99";
decimal usPriceValue = usPrice.ToDecimal(
    defaultValue: 0m,
    culture: new CultureInfo("en-US")
); // 19.99m
```

### Using Invariant Culture (Default)

```csharp
// Invariant culture always uses period as decimal separator
string number = "3.14";
double value = number.ToDouble(); // Uses invariant culture by default
```

---

## Converting to Boolean

```csharp
string trueValue = "true";
bool result = trueValue.ToBoolean(); // true

string falseValue = "False";
bool falseResult = falseValue.ToBoolean(); // false

string invalid = "maybe";
bool defaulted = invalid.ToBoolean(defaultValue: false); // false
```

---

## Converting to GUID

```csharp
string guidString = "12345678-1234-1234-1234-123456789abc";
Guid guid = guidString.ToGuid(Guid.Empty); // Parsed GUID

string invalid = "not-a-guid";
Guid empty = invalid.ToGuid(Guid.Empty); // Guid.Empty
```

### Nullable GUID

```csharp
string guidString = "12345678-1234-1234-1234-123456789abc";
Guid? guid = guidString.ToNullableGuid(); // Parsed GUID

string invalid = "not-a-guid";
Guid? nullGuid = invalid.ToNullableGuid(); // null
```

---

## Converting to Byte Types

### Single Byte (0-255)

```csharp
string byteString = "255";
byte value = byteString.ToByte(); // 255

string overflow = "256";
byte defaulted = overflow.ToByte(defaultValue: 0); // 0
```

### Signed Byte (-128 to 127)

```csharp
string sbyteString = "-128";
sbyte value = sbyteString.ToSByte(); // -128
```

---

## Converting Unsigned Integers

```csharp
// UInt16
string ushortString = "65535";
ushort value16 = ushortString.ToUInt16();

// UInt32
string uintString = "4294967295";
uint value32 = uintString.ToUInt32();

// UInt64
string ulongString = "18446744073709551615";
ulong value64 = ulongString.ToUInt64();
```

---

## Real-World Scenarios

### Processing Form Input

```csharp
public class OrderProcessor
{
    public void ProcessOrder(Dictionary<string, string> formData)
    {
        int quantity = formData.Get("quantity", "").ToInt32(defaultValue: 1);
        decimal price = formData.Get("price", "").ToDecimal(defaultValue: 0m);

        if (price <= 0)
        {
            throw new ArgumentException("Invalid price");
        }

        decimal total = quantity * price;
        Console.WriteLine($"Total: {total:C}");
    }
}
```

### Parsing Configuration Values

```csharp
using System.Configuration;

public class AppSettings
{
    public int MaxRetries { get; }
    public int TimeoutSeconds { get; }
    public bool EnableCaching { get; }

    public AppSettings()
    {
        MaxRetries = ConfigurationManager.AppSettings["MaxRetries"]
            .ToInt32(defaultValue: 3);

        TimeoutSeconds = ConfigurationManager.AppSettings["Timeout"]
            .ToInt32(defaultValue: 30);

        EnableCaching = ConfigurationManager.AppSettings["EnableCaching"]
            .ToBoolean(defaultValue: true);
    }
}
```

### Parsing Query String Parameters

```csharp
public class ProductController
{
    public void ShowProducts(string? pageParam, string? pageSizeParam)
    {
        int page = pageParam.ToInt32(defaultValue: 1);
        int pageSize = pageSizeParam.ToInt32(defaultValue: 20);

        // Validate ranges
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var products = GetProducts(page, pageSize);
        // Display products...
    }

    private List<Product> GetProducts(int page, int pageSize)
    {
        return new List<Product>();
    }
}
```

### Reading CSV Data

```csharp
public class CsvParser
{
    public List<Product> ParseProductCsv(string csvContent)
    {
        var products = new List<Product>();
        var lines = csvContent.Split('\n').Skip(1); // Skip header

        foreach (var line in lines)
        {
            var fields = line.Split(',');

            var product = new Product
            {
                Id = fields[0].ToInt32(defaultValue: 0),
                Name = fields[1],
                Price = fields[2].ToDecimal(defaultValue: 0m),
                Stock = fields[3].ToInt32(defaultValue: 0)
            };

            if (product.Id > 0) // Skip invalid rows
            {
                products.Add(product);
            }
        }

        return products;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
```

---

## Choosing Between Nullable and Non-Nullable

### Use Non-Nullable When:

- You always need a valid value
- A default makes sense in your domain
- You want simple, straightforward code

```csharp
int age = userInput.ToInt32(defaultValue: 0);
if (age > 0 && age < 150)
{
    // Valid age
}
```

### Use Nullable When:

- You need to distinguish between "zero" and "not provided"
- Null represents "missing value" in your domain
- You need three-state logic (valid, invalid, missing)

```csharp
int? quantity = userInput.ToNullableInt32();

if (quantity is null)
{
    Console.WriteLine("No quantity provided");
}
else if (quantity == 0)
{
    Console.WriteLine("Quantity is explicitly zero");
}
else
{
    Console.WriteLine($"Quantity: {quantity}");
}
```

---

## Best Practices

### ✅ Do:

- Always provide meaningful default values
- Validate converted values for business rules
- Use culture parameter when parsing user-entered numbers
- Use nullable versions when "not provided" is different from "zero"
- Log or handle cases where conversion fails if needed

### ❌ Don't:

- Ignore the result without validation
- Assume the default was never returned
- Mix cultures inconsistently
- Use conversion methods for security-critical input without additional validation

---

## See Also

- **[StringExtensions Reference](../reference/stringextensions.md)** – Complete API documentation
- **[Safe Type Conversions Explained](../explanations/safe-type-conversions.md)** – Design philosophy
- **[Culture Handling Explained](../explanations/culture-handling.md)** – Understanding culture-specific parsing
- **[String Validation How-To](string-validation.md)** – Validating input before conversion

---

**[← Back to Documentation Hub](../readme.md)**
