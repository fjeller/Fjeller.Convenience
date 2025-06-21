# EnumerableExtensions Documentation

## Overview
The `EnumerableExtensions` class provides extension methods for working with `IEnumerable<T>` sequences, such as filtering out null elements and performing actions on each element.

---

## Methods

### `WhereNotNull`
**Description:** Filters a sequence of reference type elements, returning only the non-null elements.

**Type Parameters:**
- `T`: The reference type of the elements in the source sequence.

**Parameters:**
- `source`: The sequence to filter.

**Returns:**
- An `IEnumerable<T>` that contains only the non-null elements from the input sequence.

**Exceptions:**
- Throws `ArgumentNullException` if `source` is `null`.

---

### `ForEach`
**Description:** Executes the specified action on each element of the `IEnumerable<T>` sequence.

**Type Parameters:**
- `T`: The type of the elements in the source sequence.

**Parameters:**
- `source`: The sequence whose elements the action will be performed on.
- `action`: The `Action<T>` delegate to perform on each element of the sequence.

**Returns:**
- None.

**Exceptions:**
- Throws `ArgumentNullException` if `source` or `action` is `null`.

---
