﻿# Safe Type Conversions Explained

**💡 Explanation**

---

## The Problem with Traditional Parsing

In C#, traditional parsing methods throw exceptions when conversion fails:

```csharp
string input = "not a number";
int number = int.Parse(input); // Throws FormatException
```

This leads to defensive programming with try-catch blocks:

```csharp
try
{
    int number = int.Parse(input);
    // Use number
}
catch (FormatException)
{
    // Handle error
    int number = 0; // Use default
}
```

Or `TryParse` patterns:

```csharp
if (int.TryParse(input, out int number))
{
    // Use number
}
else
{
    number = 0; // Use default
}
```

---

## The Philosophy Behind Safe Conversions

Fjeller.Convenience takes a different approach based on these principles:

### 1. Exceptions Are for Exceptional Circumstances

Invalid user input is **not exceptional**—it's expected and normal. A user typing "abc" into an age field shouldn't throw an exception.

### 2. Default Values Are Meaningful

In most business scenarios, you need a fallback value anyway:

```csharp
// Traditional
int timeout = 30;
if (int.TryParse(configValue, out int parsed))
{
    timeout = parsed;
}

// With safe conversions
int timeout = configValue.ToInt32(defaultValue: 30);
```

### 3. Cleaner Code Reflects Intent

The conversion expresses what you want directly:

```csharp
// Clear intent: convert or use 0
int age = userInput.ToInt32(defaultValue: 0);

// Less clear: parsing with error handling
int age = 0;
if (!int.TryParse(userInput, out age))
{
    age = 0;
}
```

---

## How It Works

Every conversion method follows this pattern:

1. Attempt to parse the string using the appropriate `TryParse` method
2. If successful, return the parsed value
3. If unsuccessful, return the specified default value
4. **Never throw an exception**

```csharp
public static int ToInt32(this string? value, int defaultValue = 0)
{
    return Int32.TryParse(value, out int result) ? result : defaultValue;
}
```

---

## The Nullable vs. Non-Nullable Decision

Fjeller.Convenience provides both nullable and non-nullable versions:

### Non-Nullable: When You Always Need a Value

```csharp
int age = userInput.ToInt32(defaultValue: 0);
```

Use when:
- A default makes sense in your domain
- You want simple, straightforward code
- Zero/empty is a valid fallback

### Nullable: When "Not Provided" Is Different from "Zero"

```csharp
int? age = userInput.ToNullableInt32();

if (age is null)
{
    Console.WriteLine("Age not provided");
}
else if (age == 0)
{
    Console.WriteLine("Age is explicitly zero");
}
else
{
    Console.WriteLine($"Age: {age}");
}
```

Use when:
- You need three-state logic (valid, zero, not provided)
- Null represents "missing value" in your domain
- You're mapping to nullable database columns

---

## Culture Handling

Numeric parsing depends on culture for decimal separators and formatting:

```csharp
// Invariant culture (default): always uses period
"3.14".ToDouble(); // 3.14

// Specific culture: respects culture conventions
"3,14".ToDouble(culture: new CultureInfo("de-DE")); // 3.14
```

### Why Invariant Culture Is the Default

1. **Predictability**: Code behaves the same regardless of server locale
2. **API consistency**: APIs typically use invariant format
3. **Configuration files**: Most config formats use invariant culture
4. **Explicit**: When you need culture-specific parsing, you opt-in explicitly

---

## Comparison with Alternatives

### vs. Traditional Parse

```csharp
// Traditional: Exception-driven
try
{
    int value = int.Parse(input);
}
catch (FormatException)
{
    value = 0;
}

// Safe conversion: Value-driven
int value = input.ToInt32(defaultValue: 0);
```

**Advantages**: Cleaner, faster (no exception overhead), intent is clear

### vs. TryParse

```csharp
// TryParse: Requires out parameter
int value;
if (!int.TryParse(input, out value))
{
    value = 0;
}

// Safe conversion: Single expression
int value = input.ToInt32(defaultValue: 0);
```

**Advantages**: More concise, works in expressions, clearer intent

### vs. Null-Coalescing with TryParse

```csharp
// Null-coalescing: Complex
int value = int.TryParse(input, out int temp) ? temp : 0;

// Safe conversion: Straightforward
int value = input.ToInt32(defaultValue: 0);
```

**Advantages**: Simpler syntax, better readability

---

## When to Use Each Approach

### Use Safe Conversions When:

✅ Processing user input  
✅ Parsing configuration values  
✅ Reading query string parameters  
✅ Processing CSV/data files  
✅ You have a meaningful default value  
✅ Invalid input is expected and normal

### Use Traditional Parsing When:

⚠️ The input MUST be valid (parse failures are bugs)  
⚠️ You need detailed error information  
⚠️ You're validating data format strictly  
⚠️ Exceptions are part of your error handling strategy

### Use TryParse When:

⚠️ You need to differentiate between "invalid" and "default"  
⚠️ You're building validation logic  
⚠️ You need maximum performance (no method call overhead)

---

## The Default Value Philosophy

### Choosing Good Defaults

Good defaults should be:

1. **Safe**: Won't cause errors in downstream code
2. **Obvious**: Clearly indicate "no value provided"
3. **Documented**: Callers understand what default means

```csharp
// Good: 0 is safe and obvious for quantities
int quantity = input.ToInt32(defaultValue: 0);

// Good: Empty Guid is safe and obvious
Guid id = input.ToGuid(Guid.Empty);

// Consider: Is -1 obvious for age? Maybe null is better
int age = input.ToInt32(defaultValue: -1);
int? age = input.ToNullableInt32(); // More expressive
```

### Domain-Specific Defaults

```csharp
// E-commerce: Minimum order is 1
int quantity = input.ToInt32(defaultValue: 1);

// Configuration: Default timeout
int timeoutSeconds = config.ToInt32(defaultValue: 30);

// Pagination: Start at page 1
int page = param.ToInt32(defaultValue: 1);
```

---

## Performance Considerations

### No Exception Overhead

Exceptions are expensive. Safe conversions avoid exception overhead:

```csharp
// Traditional: Throws exception on every invalid input
for (int i = 0; i < 10000; i++)
{
    try
    {
        int value = int.Parse(invalidInput);
    }
    catch (FormatException)
    {
        value = 0;
    }
}

// Safe conversion: No exceptions
for (int i = 0; i < 10000; i++)
{
    int value = invalidInput.ToInt32(defaultValue: 0);
}
```

The safe conversion approach is significantly faster when dealing with invalid input.

### Method Call Overhead

There is a tiny method call overhead compared to inline `TryParse`, but it's negligible in most scenarios:

```csharp
// Slightly faster (inline)
int.TryParse(input, out int value);

// Negligibly slower (method call)
input.ToInt32();
```

**Use safe conversions unless profiling shows a bottleneck.**

---

## Design Patterns Enabled

### Fluent Configuration

```csharp
var config = new Configuration()
{
    MaxRetries = settings.Get("maxRetries", "").ToInt32(3),
    Timeout = settings.Get("timeout", "").ToInt32(30),
    EnableCache = settings.Get("cache", "").ToBoolean(true)
};
```

### Pipeline Processing

```csharp
var result = GetInput()
    .Trim()
    .ToInt32(defaultValue: 0);
```

### Validation with Defaults

```csharp
int age = userInput
    .ToInt32(defaultValue: 0);

if (age <= 0 || age > 150)
{
    throw new ValidationException("Invalid age");
}
```

---

## Common Misunderstandings

### "I'll never know if conversion failed"

**Response**: That's by design. If you need to know:

```csharp
int? nullable = input.ToNullableInt32();
if (nullable is null)
{
    // Handle conversion failure
}
```

### "What if I don't want a default?"

**Response**: Use nullable versions or TryParse:

```csharp
int? value = input.ToNullableInt32();
if (value is null)
{
    throw new ArgumentException("Value is required");
}
```

### "Aren't you hiding errors?"

**Response**: No—we're distinguishing expected cases (invalid input) from unexpected errors (bugs). Invalid user input is not an error; it's a normal scenario requiring a default behavior.

---

## See Also

- **[String Conversions How-To](../how-to/string-conversions.md)** – Practical conversion examples
- **[Culture Handling Explained](culture-handling.md)** – Understanding culture-specific parsing
- **[StringExtensions Reference](../reference/stringextensions.md)** – Complete conversion API

---

**[← Back to Documentation Hub](../readme.md)**
