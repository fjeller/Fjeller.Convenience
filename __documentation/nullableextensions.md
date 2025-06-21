# NullableExtensions Documentation

## Overview
The `NullableExtensions` class provides extension methods for nullable value types to simplify common null and default value checks.

---

## Methods

### `HasNoValue`
**Description:** Determines whether the nullable value type does not have a value.

**Type Parameters:**
- `T`: The underlying value type.

**Parameters:**
- `nullable`: The nullable value to check.

**Returns:**
- `true` if the nullable does not have a value; otherwise, `false`.

---

### `HasNoValueOrDefault`
**Description:** Determines whether the nullable value type does not have a value or equals the specified default value.

**Type Parameters:**
- `T`: The underlying value type.

**Parameters:**
- `nullable`: The nullable value to check.
- `defaultValue`: The default value to compare against.

**Returns:**
- `true` if the nullable does not have a value or its value equals the default value; otherwise, `false`.

---
