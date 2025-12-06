﻿# Culture Handling in Conversions Explained

**💡 Explanation**

---

## What Is Culture in .NET?

A culture (represented by `CultureInfo`) defines region-specific formatting rules for:

- **Number formats**: Decimal separator (`.` vs `,`), thousands separator, negative signs
- **Date formats**: Order of day/month/year, separators
- **Currency**: Symbol, position, decimal places
- **Text**: Casing rules, sorting

```csharp
using System.Globalization;

// United States: period as decimal separator
var usCulture = new CultureInfo("en-US");
Console.WriteLine(3.14.ToString(usCulture)); // "3.14"

// Germany: comma as decimal separator
var deCulture = new CultureInfo("de-DE");
Console.WriteLine(3.14.ToString(deCulture)); // "3,14"
```

---

## The Culture Problem in Parsing

When parsing strings to numbers, .NET uses a culture to interpret the format:

```csharp
// Current culture determines interpretation
double.Parse("3.14"); // Works in en-US, fails in de-DE
double.Parse("3,14"); // Fails in en-US, works in de-DE
```

This creates problems:

1. **Server location dependency**: Code behaves differently on different servers
2. **User input ambiguity**: "1,000" could mean 1000 or 1.0
3. **API inconsistency**: APIs should be culture-agnostic

---

## Fjeller.Convenience's Approach

### Default to Invariant Culture

All conversion methods use `CultureInfo.InvariantCulture` by default:

```csharp
string number = "3.14";
double value = number.ToDouble(); // Always uses period as decimal separator
```

**Invariant culture** is culture-independent, designed for:
- Storing data
- API communication
- Configuration files
- Database interactions

### Opt-In to Specific Cultures

When you need culture-specific parsing (e.g., user input), you opt-in explicitly:

```csharp
using System.Globalization;

string germanNumber = "3,14";
double value = germanNumber.ToDouble(
    defaultValue: 0.0,
    culture: new CultureInfo("de-DE")
);
```

---

## Why Invariant Culture by Default?

### 1. Predictability

```csharp
// Invariant: Always works the same
"3.14".ToDouble(); // 3.14 everywhere

// Current culture: Unpredictable
double.Parse("3.14"); // Works in US, fails in Germany
```

### 2. API Consistency

APIs should not depend on server culture:

```csharp
// API endpoint receives "3.14"
[HttpGet]
public IActionResult GetPrice(string priceParam)
{
    // Always interprets as 3.14, regardless of server location
    decimal price = priceParam.ToDecimal(defaultValue: 0m);
    return Ok(price);
}
```

### 3. Configuration Files

Config values are typically written in invariant format:

```json
{
  "timeout": "30.5",
  "threshold": "0.95"
}
```

```csharp
double timeout = config["timeout"].ToDouble(defaultValue: 30.0);
// Always reads 30.5, not 305 in some cultures
```

---

## When to Use Specific Cultures

### User-Entered Data

When parsing user input displayed in their locale:

```csharp
public class PriceInputHandler
{
    public decimal ParseUserPrice(string input, CultureInfo userCulture)
    {
        return input.ToDecimal(defaultValue: 0m, culture: userCulture);
    }
}

// German user enters "19,99"
var userCulture = new CultureInfo("de-DE");
decimal price = handler.ParseUserPrice("19,99", userCulture); // 19.99
```

### Localized Reports

When generating or parsing localized content:

```csharp
public class ReportGenerator
{
    public string FormatCurrency(decimal amount, CultureInfo culture)
    {
        return amount.ToString("C", culture);
    }

    public decimal ParseCurrency(string formatted, CultureInfo culture)
    {
        return formatted.ToDecimal(defaultValue: 0m, culture: culture);
    }
}
```

---

## Common Scenarios

### Scenario 1: REST API

```csharp
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductDto dto)
    {
        // API receives invariant-formatted strings
        decimal price = dto.PriceString.ToDecimal(defaultValue: 0m);
        double weight = dto.WeightString.ToDouble(defaultValue: 0.0);

        // Process with culture-independent values
        var product = new Product { Price = price, Weight = weight };
        return Ok(product);
    }
}

public class ProductDto
{
    public string PriceString { get; set; } = string.Empty;
    public string WeightString { get; set; } = string.Empty;
}

public class Product
{
    public decimal Price { get; set; }
    public double Weight { get; set; }
}
```

### Scenario 2: User Forms

```csharp
public class OrderFormProcessor
{
    public Order ProcessForm(Dictionary<string, string> formData, CultureInfo userCulture)
    {
        // User entered data in their culture
        decimal amount = formData.Get("amount", "")
            .ToDecimal(defaultValue: 0m, culture: userCulture);

        int quantity = formData.Get("quantity", "")
            .ToInt32(defaultValue: 1); // No culture needed for integers

        return new Order { Amount = amount, Quantity = quantity };
    }
}

public class Order
{
    public decimal Amount { get; set; }
    public int Quantity { get; set; }
}
```

### Scenario 3: Configuration Loading

```csharp
public class AppConfig
{
    public double PerformanceThreshold { get; }
    public decimal DefaultPrice { get; }

    public AppConfig(IConfiguration config)
    {
        // Config values are invariant
        PerformanceThreshold = config["Performance:Threshold"]
            .ToDouble(defaultValue: 0.95);

        DefaultPrice = config["Pricing:Default"]
            .ToDecimal(defaultValue: 9.99m);
    }
}
```

---

## Culture-Independent Types

Some types don't require culture information:

### Integers

```csharp
// Integers format the same in all cultures
"42".ToInt32(); // No culture parameter needed
```

### Booleans

```csharp
// Boolean parsing is culture-independent
"true".ToBoolean(); // No culture parameter needed
```

### GUIDs

```csharp
// GUID format is standardized
"12345678-1234-1234-1234-123456789abc".ToGuid(Guid.Empty);
```

---

## Detecting User Culture

### From HTTP Request (ASP.NET Core)

```csharp
public class CultureAwareController : Controller
{
    public IActionResult ProcessInput(string numberInput)
    {
        // Get user's culture from request
        CultureInfo userCulture = HttpContext.Request.GetTypedHeaders()
            .AcceptLanguage
            .FirstOrDefault()
            ?.Value.ToString()
            .ToCultureInfo() ?? CultureInfo.InvariantCulture;

        decimal value = numberInput.ToDecimal(
            defaultValue: 0m,
            culture: userCulture
        );

        return Ok(value);
    }
}
```

### From User Profile

```csharp
public class UserService
{
    public decimal ParseUserInput(User user, string input)
    {
        CultureInfo userCulture = user.PreferredCulture
            .ToCultureInfo() ?? CultureInfo.InvariantCulture;

        return input.ToDecimal(defaultValue: 0m, culture: userCulture);
    }
}

public class User
{
    public string PreferredCulture { get; set; } = "en-US";
}
```

---

## Best Practices

### ✅ Do:

- Use invariant culture for APIs, configs, and storage
- Use specific cultures for user-facing input/output
- Store data in culture-independent format
- Convert to user's culture only for display
- Document when culture matters in your API

### ❌ Don't:

- Rely on `Thread.CurrentCulture` for parsing
- Store culture-specific formatted data in databases
- Assume all users use the same culture
- Parse API parameters with specific cultures
- Mix culture-specific and invariant data

---

## The Storage and Display Pattern

**Best practice**: Store invariant, display localized.

```csharp
public class PriceService
{
    // Store in database (invariant)
    public void SavePrice(decimal price)
    {
        string invariantString = price.ToString(CultureInfo.InvariantCulture);
        _database.Save("price", invariantString);
    }

    // Retrieve from database (invariant)
    public decimal LoadPrice()
    {
        string stored = _database.Load("price");
        return stored.ToDecimal(defaultValue: 0m); // Uses invariant by default
    }

    // Display to user (localized)
    public string FormatForUser(decimal price, CultureInfo userCulture)
    {
        return price.ToString("C", userCulture);
    }

    private readonly IDatabase _database = null!;
}

public interface IDatabase
{
    void Save(string key, string value);
    string Load(string key);
}
```

---

## Culture Validation

Check if a culture string is valid:

```csharp
string cultureInput = "en-US";
if (cultureInput.IsCulture())
{
    CultureInfo? culture = cultureInput.ToCultureInfo();
    // Use culture
}
```

---

## Comparison: Current Culture vs. Invariant

```csharp
// On US server
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
double.Parse("3.14"); // 3.14 ✓

// Same code on German server
Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
double.Parse("3.14"); // Exception! ✗

// With Fjeller.Convenience (consistent everywhere)
"3.14".ToDouble(); // 3.14 ✓ (uses invariant culture)
```

---

## See Also

- **[String Conversions How-To](../how-to/string-conversions.md)** – Practical culture examples
- **[Safe Type Conversions Explained](safe-type-conversions.md)** – Conversion philosophy
- **[StringExtensions Reference](../reference/stringextensions.md)** – Conversion API details
- [Microsoft Docs: CultureInfo Class](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo)

---

**[← Back to Documentation Hub](../readme.md)**
