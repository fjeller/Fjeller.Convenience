# ListExtensions Documentation

## Overview
The `ListExtensions` class provides extension methods for working with `List<T>` collections, such as conditionally adding elements based on null checks.

---

## Methods

### `AddIfNotNull`
**Description:** Adds the specified item to the list if the item is not `null`.

**Type Parameters:**
- `T`: The type of elements in the list (must be a reference type).

**Parameters:**
- `list`: The list to which the item will be added.
- `item`: The item to add if it is not `null`.

**Returns:**
- None.

**Remarks:**
- If `item` is `null`, nothing is added to the list.

---
