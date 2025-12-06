﻿# Getting Started with Fjeller.Convenience

**📚 Tutorial** | **⏱️ Estimated time: 15 minutes** | **🎯 Target: Beginner to Intermediate**

---

## What You'll Learn

In this tutorial, you'll learn how to:

1. Install and set up Fjeller.Convenience in your project
2. Use string extension methods for safe conversions
3. Validate string input
4. Work with collections using helper methods
5. Handle null values gracefully

By the end, you'll have a simple console application demonstrating the most commonly used features.

---

## Prerequisites

- Visual Studio 2022 or later, or any .NET IDE
- .NET 8.0 SDK or later installed
- Basic knowledge of C# and .NET

---

## Step 1: Create a New Console Application

Open your terminal or command prompt and create a new console project:

```bash
dotnet new console -n FjellerConvenienceDemo
cd FjellerConvenienceDemo
```

---

## Step 2: Install Fjeller.Convenience

Add the Fjeller.Convenience package to your project:

```bash
dotnet add package Fjeller.Convenience
```

This will download and install the latest version of the library.

---

## Step 3: Your First Extension Method

Open `Program.cs` and replace its contents with the following:

```csharp
using Fjeller.Convenience.Extensions;

Console.WriteLine("=== Fjeller.Convenience Demo ===\n");

// Example 1: Safe string checking
string? userName = "  ";
if (userName.HasValue())
{
    Console.WriteLine($"Welcome, {userName}!");
}
else
{
    Console.WriteLine("No username provided.");
}
```

**Run the application:**

```bash
dotnet run
```

**Expected output:**

```
=== Fjeller.Convenience Demo ===

No username provided.
```

**What happened?** The `HasValue()` method checks if a string is not null, not empty, and not just whitespace. Since our string contains only spaces, it returns `false`.

---

## Step 4: Safe Type Conversions

Add this code to demonstrate safe string-to-number conversions:

```csharp
// Example 2: Safe integer conversion
Console.WriteLine("\n--- Safe Conversions ---");

string ageInput = "25";
int age = ageInput.ToInt32(defaultValue: 0);
Console.WriteLine($"Age: {age}");

string invalidInput = "not a number";
int invalidAge = invalidInput.ToInt32(defaultValue: 18);
Console.WriteLine($"Invalid input converted to: {invalidAge}");
```

**Run again and see:**

```
--- Safe Conversions ---
Age: 25
Invalid input converted to: 18
```

**What happened?** The `ToInt32()` method attempts to parse the string. If parsing fails, it returns your specified default value instead of throwing an exception.

---

## Step 5: Working with Collections

Now let's explore collection helpers:

```csharp
// Example 3: Adding items conditionally
Console.WriteLine("\n--- Collection Helpers ---");

var names = new List<string>();
names.AddIfNotNull("Alice");
names.AddIfNotNull(null);
names.AddIfNotNull("Bob");

Console.WriteLine($"Names in list: {string.Join(", ", names)}");
Console.WriteLine($"Total count: {names.Count}");
```

**Output:**

```
--- Collection Helpers ---
Names in list: Alice, Bob
Total count: 2
```

**What happened?** The `AddIfNotNull()` method only adds non-null items to the list. The `null` value was silently skipped.

---

## Step 6: Dictionary Helpers

Let's use dictionary extension methods:

```csharp
// Example 4: Safe dictionary operations
Console.WriteLine("\n--- Dictionary Helpers ---");

var settings = new Dictionary<string, string>
{
    ["theme"] = "dark",
    ["language"] = "en"
};

// Add only if value is not null
settings.AddIfNotNull("timeout", null);

// Get with default fallback
string theme = settings.Get("theme", "light");
string notFound = settings.Get("missingKey", "default");

Console.WriteLine($"Theme: {theme}");
Console.WriteLine($"Missing key result: {notFound}");
Console.WriteLine($"Dictionary count: {settings.Count}");
```

**Output:**

```
--- Dictionary Helpers ---
Theme: dark
Missing key result: default
Dictionary count: 2
```

**What happened?** `AddIfNotNull()` prevented adding a null value, and `Get()` returned a default value for the missing key instead of throwing an exception.

---

## Step 7: String Validation

Add validation examples:

```csharp
// Example 5: String validation
Console.WriteLine("\n--- String Validation ---");

string email = "user@example.com";
string url = "https://github.com/fjeller";
string notAnEmail = "invalid-email";

Console.WriteLine($"'{email}' is email: {email.IsEmail()}");
Console.WriteLine($"'{url}' is URL: {url.IsUrl()}");
Console.WriteLine($"'{notAnEmail}' is email: {notAnEmail.IsEmail()}");
```

**Output:**

```
--- String Validation ---
'user@example.com' is email: True
'https://github.com/fjeller' is URL: True
'invalid-email' is email: False
```

---

## Step 8: Null Checking Made Easy

Finally, let's see generic null-checking helpers:

```csharp
// Example 6: Null checking
Console.WriteLine("\n--- Null Checking ---");

string? nullableString = null;
string? validString = "Hello";

Console.WriteLine($"nullableString.IsNull(): {nullableString.IsNull()}");
Console.WriteLine($"validString.IsNotNull(): {validString.IsNotNull()}");

if (validString.IsNotNull())
{
    // Compiler knows validString is not null here
    Console.WriteLine($"String length: {validString.Length}");
}
```

**Output:**

```
--- Null Checking ---
nullableString.IsNull(): True
validString.IsNotNull(): True
String length: 5
```

---

## Complete Program

Here's the full `Program.cs` with all examples:

```csharp
using Fjeller.Convenience.Extensions;

Console.WriteLine("=== Fjeller.Convenience Demo ===\n");

// Example 1: Safe string checking
string? userName = "  ";
if (userName.HasValue())
{
    Console.WriteLine($"Welcome, {userName}!");
}
else
{
    Console.WriteLine("No username provided.");
}

// Example 2: Safe integer conversion
Console.WriteLine("\n--- Safe Conversions ---");

string ageInput = "25";
int age = ageInput.ToInt32(defaultValue: 0);
Console.WriteLine($"Age: {age}");

string invalidInput = "not a number";
int invalidAge = invalidInput.ToInt32(defaultValue: 18);
Console.WriteLine($"Invalid input converted to: {invalidAge}");

// Example 3: Adding items conditionally
Console.WriteLine("\n--- Collection Helpers ---");

var names = new List<string>();
names.AddIfNotNull("Alice");
names.AddIfNotNull(null);
names.AddIfNotNull("Bob");

Console.WriteLine($"Names in list: {string.Join(", ", names)}");
Console.WriteLine($"Total count: {names.Count}");

// Example 4: Safe dictionary operations
Console.WriteLine("\n--- Dictionary Helpers ---");

var settings = new Dictionary<string, string>
{
    ["theme"] = "dark",
    ["language"] = "en"
};

settings.AddIfNotNull("timeout", null);

string theme = settings.Get("theme", "light");
string notFound = settings.Get("missingKey", "default");

Console.WriteLine($"Theme: {theme}");
Console.WriteLine($"Missing key result: {notFound}");
Console.WriteLine($"Dictionary count: {settings.Count}");

// Example 5: String validation
Console.WriteLine("\n--- String Validation ---");

string email = "user@example.com";
string url = "https://github.com/fjeller";
string notAnEmail = "invalid-email";

Console.WriteLine($"'{email}' is email: {email.IsEmail()}");
Console.WriteLine($"'{url}' is URL: {url.IsUrl()}");
Console.WriteLine($"'{notAnEmail}' is email: {notAnEmail.IsEmail()}");

// Example 6: Null checking
Console.WriteLine("\n--- Null Checking ---");

string? nullableString = null;
string? validString = "Hello";

Console.WriteLine($"nullableString.IsNull(): {nullableString.IsNull()}");
Console.WriteLine($"validString.IsNotNull(): {validString.IsNotNull()}");

if (validString.IsNotNull())
{
    Console.WriteLine($"String length: {validString.Length}");
}

Console.WriteLine("\n=== Demo Complete ===");
```

---

## What You've Accomplished

✅ Installed Fjeller.Convenience in your project  
✅ Used `HasValue()` to check for meaningful string content  
✅ Performed safe type conversions with default fallbacks  
✅ Added items conditionally to collections  
✅ Safely retrieved dictionary values  
✅ Validated email addresses and URLs  
✅ Simplified null checking with fluent syntax

---

## Next Steps

Now that you understand the basics, explore more advanced features:

- **[String Conversions How-To](../how-to/string-conversions.md)** – Learn about culture-specific conversions
- **[HTML Manipulation How-To](../how-to/html-manipulation.md)** – Strip tags and sanitize HTML
- **[StringExtensions Reference](../reference/stringextensions.md)** – Complete API documentation
- **[Safe Type Conversions Explained](../explanations/safe-type-conversions.md)** – Understand the design philosophy

---

## Troubleshooting

**Q: My extension methods aren't showing up in IntelliSense.**  
**A:** Make sure you have `using Fjeller.Convenience.Extensions;` at the top of your file.

**Q: I get a compile error saying the method doesn't exist.**  
**A:** Verify that you've installed the package with `dotnet add package Fjeller.Convenience` and restored dependencies.

**Q: Can I use this with older .NET versions?**  
**A:** Fjeller.Convenience targets .NET 8.0 and later. For older versions, you may need to build from source with a different target framework.

---

**Congratulations!** You've completed the Getting Started tutorial. You're now ready to use Fjeller.Convenience in your projects.
