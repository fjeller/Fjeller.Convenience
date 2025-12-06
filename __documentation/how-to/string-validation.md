﻿# How to Validate String Input

**📖 How-To Guide**

---

## Problem

You need to validate user input or data from external sources to ensure it meets expected formats before processing.

---

## Solution

Use Fjeller.Convenience's string validation extension methods for common validation scenarios like emails, URLs, dates, and type formats.

---

## Validating Email Addresses

```csharp
using Fjeller.Convenience.Extensions;

string email = "user@example.com";
if (email.IsEmail())
{
    Console.WriteLine("Valid email address");
    SendEmail(email);
}
else
{
    Console.WriteLine("Invalid email format");
}
```

### Real-World Example: Form Validation

```csharp
public class RegistrationForm
{
    public string Email { get; set; } = string.Empty;

    public bool Validate(out List<string> errors)
    {
        errors = new List<string>();

        if (Email.IsEmpty())
        {
            errors.Add("Email is required");
        }
        else if (!Email.IsEmail())
        {
            errors.Add("Email format is invalid");
        }

        return errors.Count == 0;
    }
}
```

---

## Validating URLs

```csharp
string url = "https://github.com/fjeller";
if (url.IsUrl())
{
    Console.WriteLine("Valid URL");
    OpenBrowser(url);
}
```

### Validating and Ensuring URL Format

```csharp
string userUrl = "example.com";

if (!userUrl.IsUrl())
{
    userUrl = userUrl.EnsureStartsWith("https://");
}

if (userUrl.IsUrl())
{
    Console.WriteLine($"Valid URL: {userUrl}");
}
```

---

## Validating GUIDs

```csharp
string guidString = "12345678-1234-1234-1234-123456789abc";
if (StringExtensions.IsGuid(guidString))
{
    Guid guid = guidString.ToGuid(Guid.Empty);
    ProcessGuid(guid);
}
```

---

## Validating DateTime Formats

```csharp
string dateInput = "2024-01-15";
if (dateInput.IsDateTime())
{
    DateTime date = DateTime.Parse(dateInput);
    Console.WriteLine($"Valid date: {date:D}");
}
```

---

## Validating Culture Names

```csharp
string cultureName = "en-US";
if (cultureName.IsCulture())
{
    var culture = cultureName.ToCultureInfo();
    Console.WriteLine($"Valid culture: {culture?.DisplayName}");
}
```

---

## Checking String Content

### Check if String Has Value

```csharp
string? userInput = GetUserInput();

if (userInput.HasValue())
{
    Console.WriteLine($"User entered: {userInput}");
}
else
{
    Console.WriteLine("No input provided");
}
```

### Check if String is Empty

```csharp
string? name = " ";
if (name.IsEmpty())
{
    throw new ArgumentException("Name cannot be empty");
}
```

---

## Validating Case

```csharp
string password = "PASSWORD123";
if (password.IsUpper())
{
    Console.WriteLine("Password is all uppercase");
}

string username = "johndoe";
if (username.IsLower())
{
    Console.WriteLine("Username is all lowercase");
}
```

---

## Checking String Endings

```csharp
string fileName = "document.pdf";
if (fileName.EndsWithOneOf(true, ".pdf", ".doc", ".docx"))
{
    Console.WriteLine("Valid document format");
}

string image = "photo.jpg";
if (image.EndsWithOneOf(true, ".jpg", ".png", ".gif"))
{
    Console.WriteLine("Valid image format");
}
```

---

## Complete Validation Example

```csharp
public class ContactFormValidator
{
    public ValidationResult Validate(ContactForm form)
    {
        var result = new ValidationResult();

        // Check name
        if (form.Name.IsEmpty())
        {
            result.AddError("Name is required");
        }

        // Check email
        if (form.Email.IsEmpty())
        {
            result.AddError("Email is required");
        }
        else if (!form.Email.IsEmail())
        {
            result.AddError("Email format is invalid");
        }

        // Check website (optional)
        if (form.Website.HasValue() && !form.Website.IsUrl())
        {
            result.AddError("Website URL is invalid");
        }

        // Check message
        if (form.Message.IsEmpty())
        {
            result.AddError("Message is required");
        }
        else if (form.Message.Length < 10)
        {
            result.AddError("Message must be at least 10 characters");
        }

        return result;
    }
}

public class ContactForm
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class ValidationResult
{
    public List<string> Errors { get; } = new();
    public bool IsValid => Errors.Count == 0;

    public void AddError(string error) => Errors.Add(error);
}
```

---

## See Also

- **[StringExtensions Reference](../reference/stringextensions.md)** – Complete validation API
- **[String Conversions How-To](string-conversions.md)** – Converting validated input
- **[HTML Manipulation How-To](html-manipulation.md)** – Sanitizing user input

---

**[← Back to Documentation Hub](../readme.md)**
