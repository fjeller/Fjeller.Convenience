# StringExtensions Documentation

## Overview
The `StringExtensions` class provides a set of extension methods for the `string` type to simplify common operations such as checks for emptiness, conversions, and type validations.

---

## Methods

### Checks for Empty

#### `HasValue`
**Description:** Determines whether the specified string is not `null`, empty, or consists only of white-space characters.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string has a value; otherwise, `false`.

---

#### `IsEmpty`
**Description:** Determines whether the specified string is `null`, empty, or consists only of white-space characters.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is empty; otherwise, `false`.

---

### Conversions

#### `ToInt32`
**Description:** Converts the string to a 32-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableInt32`
**Description:** Converts the string to a nullable 32-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToInt64`
**Description:** Converts the string to a 64-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableInt64`
**Description:** Converts the string to a nullable 64-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToDouble`
**Description:** Converts the string to a double-precision floating-point number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted double, or `defaultValue` if conversion fails.

---

#### `ToNullableDouble`
**Description:** Converts the string to a nullable double-precision floating-point number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable double, or `defaultValue` if conversion fails.

---

#### `ToByte`
**Description:** Converts the string to a byte. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted byte, or `defaultValue` if conversion fails.

---

#### `ToNullableByte`
**Description:** Converts the string to a nullable byte. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable byte, or `defaultValue` if conversion fails.

---

#### `ToGuid`
**Description:** Converts the string to a `Guid`. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted `Guid`, or `defaultValue` if conversion fails.

---

#### `ToNullableGuid`
**Description:** Converts the string to a nullable `Guid`. Returns `null` if conversion fails.

**Parameters:**
- `value`: The string to convert.

**Returns:**
- The converted nullable `Guid`, or `null` if conversion fails.

---

#### `ToSingle`
**Description:** Converts the string to a single-precision floating-point number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted float, or `defaultValue` if conversion fails.

---

#### `ToNullableSingle`
**Description:** Converts the string to a nullable single-precision floating-point number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable float, or `defaultValue` if conversion fails.

---

#### `ToDecimal`
**Description:** Converts the string to a decimal number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted decimal, or `defaultValue` if conversion fails.

---

#### `ToNullableDecimal`
**Description:** Converts the string to a nullable decimal number. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable decimal, or `defaultValue` if conversion fails.

---

#### `ToInt16`
**Description:** Converts the string to a 16-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableInt16`
**Description:** Converts the string to a nullable 16-bit signed integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToUInt16`
**Description:** Converts the string to a 16-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableUInt16`
**Description:** Converts the string to a nullable 16-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToUInt32`
**Description:** Converts the string to a 32-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableUInt32`
**Description:** Converts the string to a nullable 32-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToUInt64`
**Description:** Converts the string to a 64-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted integer, or `defaultValue` if conversion fails.

---

#### `ToNullableUInt64`
**Description:** Converts the string to a nullable 64-bit unsigned integer. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable integer, or `defaultValue` if conversion fails.

---

#### `ToSByte`
**Description:** Converts the string to a signed byte. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted signed byte, or `defaultValue` if conversion fails.

---

#### `ToNullableSByte`
**Description:** Converts the string to a nullable signed byte. Returns the specified default value if conversion fails.

**Parameters:**
- `value`: The string to convert.
- `defaultValue`: The value to return if conversion fails.

**Returns:**
- The converted nullable signed byte, or `defaultValue` if conversion fails.

---

### Case Checks

#### `IsUpper`
**Description:** Determines whether the specified string is entirely upper-case.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is entirely upper-case; otherwise, `false`.

---

#### `IsLower`
**Description:** Determines whether the specified string is entirely lower-case.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is entirely lower-case; otherwise, `false`.

---

### Null Handling

#### `ValueOrDefault`
**Description:** Returns the original string if it is not null; otherwise, returns the specified fallback value.

**Parameters:**
- `item`: The string to check.
- `fallback`: The fallback value to return if `item` is null.

**Returns:**
- The original string if not null; otherwise, the fallback value.

---

### Type Checks

#### `IsGuid`
**Description:** Determines whether the specified string is a valid `Guid` format.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is a valid `Guid`; otherwise, `false`.

---

#### `IsDateTime`
**Description:** Determines whether the specified string is a valid `DateTime` format.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is a valid `DateTime`; otherwise, `false`.

---

#### `IsCulture`
**Description:** Determines whether the specified string is a valid culture name.

**Parameters:**
- `item`: The string to check.

**Returns:**
- `true` if the string is a valid culture name; otherwise, `false`.

---