# DictionaryExtensions Documentation

## Overview
The `DictionaryExtensions` class provides extension methods for working with `Dictionary<TKey, TValue>` collections, such as conditionally adding elements based on null checks.

---

## Methods

### `AddIfNotNull`
**Description:** Adds the specified value to the dictionary with the given key if the value is not `null`.

**Type Parameters:**
- `TKey`: The type of the dictionary key (must be non-nullable).
- `TValue`: The type of the dictionary value (must be a reference type).

**Parameters:**
- `dictionary`: The dictionary to which the value will be added.
- `key`: The key for the value.
- `value`: The value to add if it is not `null`.

**Returns:**
- None.

**Remarks:**
- If `value` is `null`, nothing is added to the dictionary.

---
