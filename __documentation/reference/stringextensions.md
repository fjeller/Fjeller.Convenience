﻿# StringExtensions Reference

**📘 Reference Documentation**

---

## Overview

The `StringExtensions` class provides a comprehensive set of extension methods for the `string` type, offering:

- **Null and emptiness checking**
- **Safe type conversions** with default values
- **Case validation**
- **Type format validation** (email, URL, Guid, DateTime, culture)
- **String prefix/suffix manipulation**
- **HTML content sanitization**

**Namespace:** `Fjeller.Convenience.Extensions`

---

## Null and Emptiness Checking

### HasValue

Determines whether the specified string is not null, empty, or consists only of white-space characters.

```csharp
public static bool HasValue([NotNullWhen(true)] this string? item)
```

#### Parameters

- **item** (`string?`): The string to check.

#### Returns

`bool`: `true` if the string has a value; otherwise, `false`.

#### Examples

```csharp
string? text = "Hello";
bool hasValue = text.HasValue(); // true

string? empty = "";
bool isEmpty = empty.HasValue(); // false

string? whitespace = "   ";
bool isWhitespace = whitespace.HasValue(); // false

string? nullString = null;
bool isNull = nullString.HasValue(); // false
```

---

### IsEmpty

Determines whether the specified string is null, empty, or consists only of white-space characters.

```csharp
public static bool IsEmpty([NotNullWhen(false)] this string? item)
```

#### Parameters

- **item** (`string?`): The string to check.

#### Returns

`bool`: `true` if the string is null, empty, or whitespace; otherwise, `false`.

#### Examples

```csharp
string? empty = "";
bool result = empty.IsEmpty(); // true

string? text = "Hello";
bool hasText = text.IsEmpty(); // false
```

---

## Type Conversions

All conversion methods follow a consistent pattern: they attempt to parse the string and return a default value if parsing fails, **never throwing exceptions**.

### ToInt32

Converts the string to a 32-bit signed integer.

```csharp
public static int ToInt32(this string? value, int defaultValue = 0)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`int`): The value to return if conversion fails. Default is `0`.

#### Returns

`int`: The converted integer, or `defaultValue` if conversion fails.

#### Examples

```csharp
string validNumber = "42";
int result = validNumber.ToInt32(); // 42

string invalid = "not a number";
int defaulted = invalid.ToInt32(defaultValue: 100); // 100

string? nullString = null;
int fromNull = nullString.ToInt32(); // 0
```

---

### ToNullableInt32

Converts the string to a nullable 32-bit signed integer.

```csharp
public static int? ToNullableInt32(this string? value, int? defaultValue = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`int?`): The value to return if conversion fails. Default is `null`.

#### Returns

`int?`: The converted nullable integer, or `defaultValue` if conversion fails.

#### Examples

```csharp
string validNumber = "42";
int? result = validNumber.ToNullableInt32(); // 42

string invalid = "not a number";
int? fromInvalid = invalid.ToNullableInt32(); // null

int? withDefault = invalid.ToNullableInt32(defaultValue: 100); // 100
```

---

### ToInt64

Converts the string to a 64-bit signed integer.

```csharp
public static long ToInt64(this string? value, long defaultValue = 0)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`long`): The value to return if conversion fails. Default is `0`.

#### Returns

`long`: The converted 64-bit integer, or `defaultValue` if conversion fails.

#### Examples

```csharp
string bigNumber = "9223372036854775807";
long result = bigNumber.ToInt64(); // 9223372036854775807

string invalid = "too big for int64";
long defaulted = invalid.ToInt64(defaultValue: -1); // -1
```

---

### ToNullableInt64

Converts the string to a nullable 64-bit signed integer.

```csharp
public static long? ToNullableInt64(this string? value, long? defaultValue = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`long?`): The value to return if conversion fails. Default is `null`.

#### Returns

`long?`: The converted nullable 64-bit integer, or `defaultValue` if conversion fails.

---

### ToDouble

Converts the string to a double-precision floating-point number using invariant culture by default.

```csharp
public static double ToDouble(this string? value, double defaultValue = 0, CultureInfo? culture = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`double`): The value to return if conversion fails. Default is `0`.
- **culture** (`CultureInfo?`): The culture to use for conversion. Default is `null` (invariant culture).

#### Returns

`double`: The converted double, or `defaultValue` if conversion fails.

#### Examples

```csharp
using System.Globalization;

string number = "3.14159";
double pi = number.ToDouble(); // 3.14159

string germanNumber = "3,14159";
double parsed = germanNumber.ToDouble(culture: new CultureInfo("de-DE")); // 3.14159

string invalid = "not a number";
double defaulted = invalid.ToDouble(defaultValue: 1.0); // 1.0
```

---

### ToNullableDouble

Converts the string to a nullable double-precision floating-point number.

```csharp
public static double? ToNullableDouble(this string? value, double? defaultValue = null, CultureInfo? culture = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`double?`): The value to return if conversion fails. Default is `null`.
- **culture** (`CultureInfo?`): The culture to use for conversion. Default is `null` (invariant culture).

#### Returns

`double?`: The converted nullable double, or `defaultValue` if conversion fails.

---

### ToByte

Converts the string to a byte (0-255).

```csharp
public static byte ToByte(this string? value, byte defaultValue = 0)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`byte`): The value to return if conversion fails. Default is `0`.

#### Returns

`byte`: The converted byte, or `defaultValue` if conversion fails.

#### Examples

```csharp
string number = "255";
byte result = number.ToByte(); // 255

string outOfRange = "256";
byte defaulted = outOfRange.ToByte(defaultValue: 0); // 0
```

---

### ToNullableByte

Converts the string to a nullable byte.

```csharp
public static byte? ToNullableByte(this string? value, byte? defaultValue = null)
```

---

### ToGuid

Converts the string to a Guid.

```csharp
public static Guid ToGuid(this string? value, Guid defaultValue)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`Guid`): The value to return if conversion fails.

#### Returns

`Guid`: The converted Guid, or `defaultValue` if conversion fails.

#### Examples

```csharp
string guidString = "12345678-1234-1234-1234-123456789abc";
Guid result = guidString.ToGuid(Guid.Empty); // Parsed Guid

string invalid = "not-a-guid";
Guid defaulted = invalid.ToGuid(Guid.Empty); // Guid.Empty
```

---

### ToNullableGuid

Converts the string to a nullable Guid.

```csharp
public static Guid? ToNullableGuid(this string? value)
```

#### Returns

`Guid?`: The converted nullable Guid, or `null` if conversion fails.

#### Examples

```csharp
string guidString = "12345678-1234-1234-1234-123456789abc";
Guid? result = guidString.ToNullableGuid(); // Parsed Guid

string invalid = "not-a-guid";
Guid? nullResult = invalid.ToNullableGuid(); // null
```

---

### ToSingle

Converts the string to a single-precision floating-point number (float).

```csharp
public static float ToSingle(this string? value, float defaultValue = 0, CultureInfo? culture = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`float`): The value to return if conversion fails. Default is `0`.
- **culture** (`CultureInfo?`): The culture to use for conversion. Default is `null` (invariant culture).

#### Returns

`float`: The converted float, or `defaultValue` if conversion fails.

---

### ToNullableSingle

Converts the string to a nullable single-precision floating-point number.

```csharp
public static float? ToNullableSingle(this string? value, float? defaultValue = null, CultureInfo? culture = null)
```

---

### ToDecimal

Converts the string to a decimal number.

```csharp
public static decimal ToDecimal(this string? value, decimal defaultValue = 0m, CultureInfo? culture = null)
```

#### Parameters

- **value** (`string?`): The string to convert.
- **defaultValue** (`decimal`): The value to return if conversion fails. Default is `0m`.
- **culture** (`CultureInfo?`): The culture to use for conversion. Default is `null` (invariant culture).

#### Returns

`decimal`: The converted decimal, or `defaultValue` if conversion fails.

#### Examples

```csharp
string price = "19.99";
decimal amount = price.ToDecimal(); // 19.99

string invalid = "free";
decimal defaulted = invalid.ToDecimal(defaultValue: 0m); // 0m
```

---

### ToNullableDecimal

Converts the string to a nullable decimal number.

```csharp
public static decimal? ToNullableDecimal(this string? value, decimal? defaultValue = null, CultureInfo? culture = null)
```

---

### ToInt16

Converts the string to a 16-bit signed integer (short).

```csharp
public static short ToInt16(this string? value, short defaultValue = 0)
```

---

### ToNullableInt16

Converts the string to a nullable 16-bit signed integer.

```csharp
public static short? ToNullableInt16(this string? value, short? defaultValue = null)
```

---

### ToUInt16

Converts the string to a 16-bit unsigned integer (ushort).

```csharp
public static ushort ToUInt16(this string? value, ushort defaultValue = 0)
```

---

### ToNullableUInt16

Converts the string to a nullable 16-bit unsigned integer.

```csharp
public static ushort? ToNullableUInt16(this string? value, ushort? defaultValue = null)
```

---

### ToUInt32

Converts the string to a 32-bit unsigned integer (uint).

```csharp
public static uint ToUInt32(this string? value, uint defaultValue = 0)
```

---

### ToNullableUInt32

Converts the string to a nullable 32-bit unsigned integer.

```csharp
public static uint? ToNullableUInt32(this string? value, uint? defaultValue = null)
```

---

### ToUInt64

Converts the string to a 64-bit unsigned integer (ulong).

```csharp
public static ulong ToUInt64(this string? value, ulong defaultValue = 0)
```

---

### ToNullableUInt64

Converts the string to a nullable 64-bit unsigned integer.

```csharp
public static ulong? ToNullableUInt64(this string? value, ulong? defaultValue = null)
```

---

### ToSByte

Converts the string to a signed byte (sbyte).

```csharp
public static sbyte ToSByte(this string? value, sbyte defaultValue = 0)
```

---

### ToNullableSByte

Converts the string to a nullable signed byte.

```csharp
public static sbyte? ToNullableSByte(this string? value, sbyte? defaultValue = null)
```

---

### ToBoolean

Converts the string to a boolean.

```csharp
public static bool ToBoolean(this string? item, bool defaultValue = false)
```

#### Parameters

- **item** (`string?`): The string to convert.
- **defaultValue** (`bool`): The value to return if conversion fails. Default is `false`.

#### Returns

`bool`: The converted boolean, or `defaultValue` if conversion fails.

#### Examples

```csharp
string trueString = "true";
bool result = trueString.ToBoolean(); // true

string falseString = "False";
bool falseResult = falseString.ToBoolean(); // false

string invalid = "maybe";
bool defaulted = invalid.ToBoolean(defaultValue: false); // false
```

---

### ToCultureInfo

Converts the string to a CultureInfo object.

```csharp
public static CultureInfo? ToCultureInfo(this string? item)
```

#### Returns

`CultureInfo?`: The converted CultureInfo, or `null` if conversion fails.

#### Examples

```csharp
using System.Globalization;

string cultureName = "en-US";
CultureInfo? culture = cultureName.ToCultureInfo(); // en-US culture

string invalid = "invalid-culture";
CultureInfo? nullCulture = invalid.ToCultureInfo(); // null
```

---

## Case Checking

### IsUpper

Determines whether the specified string is entirely upper-case.

```csharp
public static bool IsUpper(this string? item)
```

#### Returns

`bool`: `true` if all letters are upper-case; otherwise, `false`.

#### Examples

```csharp
string upper = "HELLO";
bool result = upper.IsUpper(); // true

string mixed = "Hello";
bool mixedResult = mixed.IsUpper(); // false

string withNumbers = "HELLO123";
bool numbersResult = withNumbers.IsUpper(); // true (numbers ignored)
```

---

### IsLower

Determines whether the specified string is entirely lower-case.

```csharp
public static bool IsLower(this string? item)
```

#### Returns

`bool`: `true` if all letters are lower-case; otherwise, `false`.

#### Examples

```csharp
string lower = "hello";
bool result = lower.IsLower(); // true

string mixed = "Hello";
bool mixedResult = mixed.IsLower(); // false
```

---

## Null Handling

### ValueOrDefault

Returns the original string if not null; otherwise, returns the specified fallback value.

```csharp
public static string ValueOrDefault(this string? item, string fallback)
```

#### Parameters

- **item** (`string?`): The string to check.
- **fallback** (`string`): The fallback value if item is null.

#### Returns

`string`: The original string or the fallback.

#### Examples

```csharp
string? nullString = null;
string result = nullString.ValueOrDefault("default"); // "default"

string? validString = "Hello";
string valid = validString.ValueOrDefault("default"); // "Hello"
```

---

## Type Validation

### IsGuid

Determines whether the specified string is a valid Guid format.

```csharp
public static bool IsGuid(string? item)
```

#### Returns

`bool`: `true` if the string is a valid Guid; otherwise, `false`.

#### Examples

```csharp
string validGuid = "12345678-1234-1234-1234-123456789abc";
bool result = StringExtensions.IsGuid(validGuid); // true

string invalid = "not-a-guid";
bool invalidResult = StringExtensions.IsGuid(invalid); // false
```

---

### IsDateTime

Determines whether the specified string is a valid DateTime format.

```csharp
public static bool IsDateTime(this string? item)
```

#### Returns

`bool`: `true` if the string is a valid DateTime; otherwise, `false`.

#### Examples

```csharp
string validDate = "2024-01-15";
bool result = validDate.IsDateTime(); // true

string invalid = "not-a-date";
bool invalidResult = invalid.IsDateTime(); // false
```

---

### IsCulture

Determines whether the specified string is a valid culture name.

```csharp
public static bool IsCulture(this string? item)
```

#### Returns

`bool`: `true` if the string is a valid culture; otherwise, `false`.

#### Examples

```csharp
string valid = "en-US";
bool result = valid.IsCulture(); // true

string invalid = "xx-YY";
bool invalidResult = invalid.IsCulture(); // false
```

---

## String Manipulation

### EnsureStartsWith

Ensures the string starts with the specified sequence, adding it if missing.

```csharp
public static string EnsureStartsWith(this string? item, string value, bool ignoreCase = true)
```

#### Parameters

- **item** (`string?`): The string to check.
- **value** (`string`): The sequence the string must start with.
- **ignoreCase** (`bool`): If true, case is ignored. Default is `true`.

#### Returns

`string`: The string starting with the given sequence.

#### Examples

```csharp
string path = "myfile.txt";
string result = path.EnsureStartsWith("/"); // "/myfile.txt"

string alreadyHas = "/myfile.txt";
string unchanged = alreadyHas.EnsureStartsWith("/"); // "/myfile.txt"

string caseTest = "Hello";
string caseResult = caseTest.EnsureStartsWith("HELLO", ignoreCase: true); // "Hello"
```

---

### EnsureEndsWith

Ensures the string ends with the specified sequence, adding it if missing.

```csharp
public static string EnsureEndsWith(this string? item, string value, bool ignoreCase = true)
```

#### Parameters

- **item** (`string?`): The string to check.
- **value** (`string`): The sequence the string must end with.
- **ignoreCase** (`bool`): If true, case is ignored. Default is `true`.

#### Returns

`string`: The string ending with the given sequence.

#### Examples

```csharp
string url = "https://example.com";
string result = url.EnsureEndsWith("/"); // "https://example.com/"

string alreadyHas = "https://example.com/";
string unchanged = alreadyHas.EnsureEndsWith("/"); // "https://example.com/"
```

---

### EndsWithOneOf

Checks if the string ends with one of the provided endings.

```csharp
public static bool EndsWithOneOf(this string? item, bool ignoreCase = true, params string[] endStrings)
```

#### Parameters

- **item** (`string?`): The string to check.
- **ignoreCase** (`bool`): If true, case is ignored. Default is `true`.
- **endStrings** (`params string[]`): The endings to check.

#### Returns

`bool`: `true` if the string ends with one of the endings; otherwise, `false`.

#### Examples

```csharp
string filename = "document.pdf";
bool result = filename.EndsWithOneOf(true, ".pdf", ".doc", ".txt"); // true

string image = "photo.jpg";
bool imageResult = image.EndsWithOneOf(true, ".png", ".gif"); // false
```

---

## Validation

### IsEmail

Validates if the given string is an email address.

```csharp
public static bool IsEmail(this string? item)
```

#### Returns

`bool`: `true` if the string matches an email pattern; otherwise, `false`.

#### Examples

```csharp
string valid = "user@example.com";
bool result = valid.IsEmail(); // true

string invalid = "not-an-email";
bool invalidResult = invalid.IsEmail(); // false
```

**Note:** This uses regex pattern matching. For production scenarios requiring strict RFC compliance, consider additional validation.

---

### IsUrl

Validates if the given string is a URL.

```csharp
public static bool IsUrl(this string? item)
```

#### Returns

`bool`: `true` if the string matches a URL pattern; otherwise, `false`.

#### Examples

```csharp
string valid = "https://github.com/fjeller";
bool result = valid.IsUrl(); // true

string invalid = "not a url";
bool invalidResult = invalid.IsUrl(); // false
```

---

## HTML Sanitization

### StripEvents

Strips all event attributes (onclick, onmouse, etc.) from HTML tags in the string.

```csharp
public static string? StripEvents(this string? item)
```

#### Returns

`string?`: The string without event attributes.

#### Examples

```csharp
string html = "<div onclick='alert()'>Click</div>";
string? cleaned = html.StripEvents(); // "<div>Click</div>"
```

---

### StripTags

Removes all HTML tags from the string.

```csharp
public static string? StripTags(this string? item)
```

#### Returns

`string?`: The string without HTML tags.

#### Examples

```csharp
string html = "<p>Hello <b>World</b>!</p>";
string? plain = html.StripTags(); // "Hello World!"
```

---

### StripTags (With Allowed Tags)

Removes all HTML tags except those specified in the allowed list.

```csharp
public static string? StripTags(this string? item, string[] allowedTags)
```

#### Parameters

- **item** (`string?`): The string to process.
- **allowedTags** (`string[]`): Array of allowed tags (e.g., `["<a", "<b"]`).

#### Returns

`string?`: The string with only allowed tags remaining.

#### Examples

```csharp
string html = "<p>Hello <b>World</b> <script>alert();</script></p>";
string?[] allowed = { "<b" };
string? result = html.StripTags(allowed); // "Hello <b>World</b> "
```

---

### StripTags (With Semicolon-Separated Allowed Tags)

Removes all HTML tags except those specified in a semicolon-separated string.

```csharp
public static string? StripTags(this string? item, string? semicolonSeparatedAllowedTags)
```

#### Parameters

- **item** (`string?`): The string to process.
- **semicolonSeparatedAllowedTags** (`string?`): Semicolon-separated allowed tags (e.g., `"<a;<b"`).

#### Returns

`string?`: The string with only allowed tags remaining.

#### Examples

```csharp
string html = "<p>Hello <b>World</b> <i>!</i></p>";
string? result = html.StripTags("<b;<i"); // "Hello <b>World</b> <i>!</i>"
```

---

## See Also

- **[String Conversions How-To](../how-to/string-conversions.md)** – Practical examples of safe conversions
- **[String Validation How-To](../how-to/string-validation.md)** – Validation patterns and best practices
- **[HTML Manipulation How-To](../how-to/html-manipulation.md)** – Sanitizing HTML content
- **[Safe Type Conversions Explained](../explanations/safe-type-conversions.md)** – Design philosophy
- **[Culture Handling Explained](../explanations/culture-handling.md)** – Understanding culture-specific parsing

---

**[← Back to Documentation Hub](../readme.md)**
