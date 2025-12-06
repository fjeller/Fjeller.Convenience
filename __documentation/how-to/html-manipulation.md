﻿# How to Manipulate HTML Content

**📖 How-To Guide**

---

## Problem

You need to sanitize or manipulate HTML content from user input, rich text editors, or external sources by removing unwanted tags and event handlers.

---

## Solution

Use Fjeller.Convenience's HTML manipulation extension methods to strip tags, remove event handlers, and create safe HTML output.

---

## Removing All HTML Tags

```csharp
using Fjeller.Convenience.Extensions;

string html = "<p>Hello <b>World</b>!</p>";
string? plainText = html.StripTags();
// Result: "Hello World!"
```

### Use Case: Generating Plain Text Previews

```csharp
public class ArticlePreview
{
    public string GeneratePreview(string htmlContent, int maxLength = 200)
    {
        string? plainText = htmlContent.StripTags();

        if (plainText is null || plainText.Length <= maxLength)
        {
            return plainText ?? string.Empty;
        }

        return plainText.Substring(0, maxLength) + "...";
    }
}
```

---

## Removing Event Handlers

```csharp
string dangerousHtml = "<div onclick='alert(\"XSS\")'>Click me</div>";
string? safe = dangerousHtml.StripEvents();
// Result: "<div>Click me</div>"
```

### Use Case: Sanitizing Rich Text Editor Output

```csharp
public class ContentSanitizer
{
    public string SanitizeUserContent(string userHtml)
    {
        // First remove all event handlers
        string? withoutEvents = userHtml.StripEvents();

        // Then strip all tags except safe ones
        string? sanitized = withoutEvents?.StripTags("<p;<br;<b;<i;<strong;<em;<ul;<ol;<li");

        return sanitized ?? string.Empty;
    }
}
```

---

## Allowing Specific Tags

### Using Array of Allowed Tags

```csharp
string html = "<p>Hello <b>World</b> <script>alert('XSS');</script></p>";
string?[] allowedTags = { "<b", "<i", "<p" };
string? sanitized = html.StripTags(allowedTags);
// Result: "<p>Hello <b>World</b> </p>"
```

### Using Semicolon-Separated Tags

```csharp
string html = "<div><h1>Title</h1><p>Content</p><script>evil();</script></div>";
string? sanitized = html.StripTags("<h1;<p;<div");
// Result: "<div><h1>Title</h1><p>Content</p></div>"
```

---

## Real-World Scenarios

### Blog Comment System

```csharp
public class CommentProcessor
{
    private static readonly string AllowedTags = "<b;<i;<em;<strong;<a";

    public string ProcessComment(string userInput)
    {
        // Step 1: Remove dangerous event handlers
        string? withoutEvents = userInput.StripEvents();

        // Step 2: Allow only safe formatting tags
        string? withSafeTags = withoutEvents?.StripTags(AllowedTags);

        // Step 3: Ensure links open in new tab (additional processing)
        return withSafeTags ?? string.Empty;
    }
}

// Usage
var processor = new CommentProcessor();
string comment = "<p onclick='steal()'>Check <a href='#'>this</a> <script>alert('xss');</script></p>";
string safe = processor.ProcessComment(comment);
// Result: "Check <a href='#'>this</a> "
```

### Email Content Extraction

```csharp
public class EmailParser
{
    public string ExtractPlainTextFromHtmlEmail(string htmlEmail)
    {
        string? plainText = htmlEmail
            .StripTags()
            ?.Trim();

        return plainText ?? string.Empty;
    }

    public string GetPreviewText(string htmlEmail, int maxLength = 100)
    {
        string plainText = ExtractPlainTextFromHtmlEmail(htmlEmail);

        if (plainText.Length <= maxLength)
        {
            return plainText;
        }

        return plainText.Substring(0, maxLength).TrimEnd() + "...";
    }
}
```

### CMS Content Publishing

```csharp
public class ContentPublisher
{
    private readonly string _editorAllowedTags = "<p;<br;<h1;<h2;<h3;<h4;<h5;<h6;<b;<i;<strong;<em;<ul;<ol;<li;<a;<blockquote;<code;<pre";

    public string PrepareForPublication(string richTextContent)
    {
        // Remove event handlers for security
        string? withoutEvents = richTextContent.StripEvents();

        // Allow only editor-safe tags
        string? publishable = withoutEvents?.StripTags(_editorAllowedTags);

        return publishable ?? string.Empty;
    }

    public string CreateSocialMediaPreview(string richTextContent)
    {
        // Strip all HTML for social media
        string? plainText = richTextContent.StripTags();

        // Limit to 280 characters for Twitter
        if (plainText is not null && plainText.Length > 280)
        {
            return plainText.Substring(0, 277) + "...";
        }

        return plainText ?? string.Empty;
    }
}
```

### Search Index Generator

```csharp
public class SearchIndexer
{
    public SearchDocument CreateSearchDocument(Article article)
    {
        // Strip all HTML to create searchable plain text
        string? searchableContent = article.HtmlContent.StripTags();

        return new SearchDocument
        {
            Id = article.Id,
            Title = article.Title,
            Content = searchableContent ?? string.Empty,
            Url = article.Url
        };
    }
}

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string HtmlContent { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class SearchDocument
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
```

---

## Combining with Other String Operations

```csharp
public class ContentProcessor
{
    public string ProcessUserSubmittedContent(string input)
    {
        if (input.IsEmpty())
        {
            return string.Empty;
        }

        // Chain multiple operations
        string? processed = input
            .StripEvents()                          // Remove event handlers
            ?.StripTags("<p;<br;<b;<i")             // Allow only basic tags
            ?.Trim();                                // Remove whitespace

        // Validate result has content
        if (processed.IsEmpty())
        {
            return string.Empty;
        }

        return processed!;
    }
}
```

---

## Tag Format Notes

When specifying allowed tags:

### ✅ Correct Formats

```csharp
"<p"         // Without closing bracket
"<p;"        // With semicolon separator
"<p>"        // With closing bracket (will be stripped internally)
```

### Tag Specification Examples

```csharp
// These are all equivalent:
html.StripTags("<a;<b;<i");
html.StripTags(new[] { "<a", "<b", "<i" });
html.StripTags(new[] { "<a>", "<b>", "<i>" });
```

---

## Security Considerations

### ⚠️ Important Warnings

- **Not a complete XSS solution**: These methods help sanitize content but don't provide comprehensive XSS protection
- **No attribute filtering**: Allowed tags keep their attributes; use additional validation for `href`, `src`, etc.
- **Use specialized libraries for critical security**: For production scenarios requiring strict security, consider libraries like HtmlSanitizer

### Recommended Additional Validation

```csharp
public class SecureContentProcessor
{
    public string SanitizeUserHtml(string input)
    {
        // Step 1: Remove events
        string? withoutEvents = input.StripEvents();

        // Step 2: Strip to allowed tags
        string? withAllowedTags = withoutEvents?.StripTags("<p;<b;<i;<a");

        // Step 3: Additional validation (example - validate anchor tags)
        string? validated = ValidateAnchors(withAllowedTags);

        return validated ?? string.Empty;
    }

    private string? ValidateAnchors(string? html)
    {
        // Additional processing to validate href attributes
        // This is a simplified example
        return html;
    }
}
```

---

## Best Practices

### ✅ Do:

- Always remove event handlers from user input
- Define a whitelist of allowed tags for your use case
- Test your sanitization with common XSS payloads
- Use additional validation for attributes like `href` and `src`
- Consider using specialized HTML sanitization libraries for critical scenarios

### ❌ Don't:

- Trust user input without sanitization
- Allow `<script>`, `<iframe>`, `<object>`, or `<embed>` tags
- Assume these methods provide complete XSS protection
- Forget to sanitize data before storing AND before displaying

---

## See Also

- **[StringExtensions Reference](../reference/stringextensions.md)** – Complete HTML manipulation API
- **[String Validation How-To](string-validation.md)** – Validating string content
- **[Safe Type Conversions Explained](../explanations/safe-type-conversions.md)** – Understanding null handling

---

**[← Back to Documentation Hub](../readme.md)**
