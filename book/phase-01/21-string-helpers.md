# Chapter 1.21: String helpers (Trim, ToUpper, Contains, Replace, Split, IsNullOrWhiteSpace)

> Learned: Thu 22 Oct 2026 · Code: `lessons/phase-01/31-string-helpers`

---

## 🧸 LKG story

**The cleaning toolbox.** A customer types their city into the app: `"  hawalli  "`. Extra spaces, small letters. Before we save it, we clean it with small tools from a toolbox: one cuts the spaces, one makes CAPITALS, one searches like **Ctrl + F**, one does **Find and Replace**, one cuts a string of beads at every comma.

**The photocopy rule.** A tool never touches your original paper. It makes a **cleaned photocopy** and hands it back. If you don't pick up the copy, it goes in the bin, and your original is still messy. That is why strings are called **immutable**.

🎬 **Animation idea:** a workbench with the original string on a sheet of paper. You pick a tool (`Trim`, `ToUpper`, `Contains`, `Replace`, `Split`, `IsNullOrWhiteSpace`). The tool makes a new sheet (or a `True`/`False` light, or a row of boxes for `Split`). The original sheet stays the same. A switch "assign it back" (`name = name.Trim()`) replaces the original with the copy.

---

## 💻 Real explanation

String helpers are **string methods**: they are built into every `string`, and you call them with a dot (`city.Trim()`).

### 1. `Trim`, `ToUpper`, `ToLower`

```csharp
string city = "  hawalli  ";
Console.WriteLine($"[{city}]");
Console.WriteLine($"[{city.Trim()}]");
Console.WriteLine($"[{city.Trim().ToUpper()}]");
Console.WriteLine($"[{city}]");
```
```
[  hawalli  ]
[hawalli]
[HAWALLI]
[  hawalli  ]
```

- `Trim()` removes spaces at the **start and end** (not in the middle)
- `ToUpper()` → CAPITALS, `ToLower()` → small letters
- `city.Trim().ToUpper()`: the first method gives a new string, and the second method runs on that one. This is called **method chaining**
- The `[ ]` are only in the text so you can see where the spaces are
- **Line 4:** `city` still has its spaces. Strings are **immutable**: every method returns a **new** string

To keep the cleaned value, **assign it back**:

```csharp
string name = "  Ali  ";
name.Trim();            // ❌ the new string is thrown away
name = name.Trim();     // ✅ name is now "Ali"
```

### 2. `Contains` (search, like Ctrl + F)

```csharp
string note = "Please deliver to Salmiya";
Console.WriteLine(note.Contains("Salmiya"));
Console.WriteLine(note.Contains("salmiya"));
Console.WriteLine(note.ToLower().Contains("salmiya"));
```
```
True
False
True
```

- `Contains` returns a **`bool`**
- It is **case-sensitive**: `S` and `s` are different letters
- The fix: `ToLower()` first, then search with small letters
- C# prints `True` / `False` with a capital letter (Dart prints `true` / `false`)

### 3. `Replace` (Find and Replace)

```csharp
string phone = "965-5555-1234";
Console.WriteLine(phone.Replace("-", ""));
Console.WriteLine(phone.Replace("-", " "));
Console.WriteLine(phone);
```
```
96555551234
965 5555 1234
965-5555-1234
```

- `Replace("old", "new")` changes **every** `"old"`
- `""` is an **empty string**, so replacing with `""` deletes
- `phone` itself doesn't change (immutable again)

### 4. `Split` (cut into an array)

```csharp
string cities = "Hawalli,Salmiya,Jahra";
string[] parts = cities.Split(",");
Console.WriteLine(parts.Length);
Console.WriteLine(parts[0]);
foreach (string c in parts)
{
    Console.WriteLine($"- {c}");
}
```
```
3
Hawalli
- Hawalli
- Salmiya
- Jahra
```

- `Split(",")` returns a **`string[]`** (an array). The `","` is the **separator**
- The separator itself is removed: there are no commas in the parts
- `.Length` = how many parts, `[0]` = the first part

### 5. `string.IsNullOrWhiteSpace` (is it really empty?)

```csharp
string a = "Omar";
string b = "";
string d = "   ";
Console.WriteLine(string.IsNullOrWhiteSpace(a));
Console.WriteLine(string.IsNullOrWhiteSpace(b));
Console.WriteLine(string.IsNullOrWhiteSpace(d));
```
```
False
True
True
```

- `True` when the text is `null`, `""` (**empty string**) or only spaces (**whitespace**)
- **Different shape:** it's a **static method**, so you write `string.` first and put the text inside the brackets: `string.IsNullOrWhiteSpace(name)`, **not** `name.IsNullOrWhiteSpace()`. Same shape as `int.TryParse(...)`
- Use it in a **guard clause** before saving input

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `city.trim()` | `city.Trim()` |
| `city.toUpperCase()` / `toLowerCase()` | `city.ToUpper()` / `ToLower()` |
| `note.contains("x")` | `note.Contains("x")` |
| `phone.replaceAll("-", "")` | `phone.Replace("-", "")` (replaces all) |
| `cities.split(",")` → `List<String>` | `cities.Split(",")` → `string[]` (array) |
| `name.trim().isEmpty` | `string.IsNullOrWhiteSpace(name)` |
| prints `true` | prints `True` |

Both languages have immutable strings. In C# the method names start with a capital letter.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| **CS0136**: `string c = "   ";` after `foreach (string c in parts)` | The name `c` was already used by the loop variable. C# doesn't allow the same name in the enclosing scope | Rename one of them (I used `d`). Better: names that say what's inside (`spaces`, `part`) |
| Commented out all the old code to make the error go away | Didn't know what the error meant | Read the error code first. Dead code goes, Git keeps the history |
| Predicted without the `[ ]` brackets | Didn't read the text in the quotes | Predict the **whole line**, everything inside `$"..."` |
| Predicted `9655551234` (one 5 missing) and `195-...` | Copying slips | Join the parts one by one: `965` + `5555` + `1234` |
| Quiz: "`name.Trim();` is a typo" | Knew "immutable" but not what happens to the new string | It's thrown away. Assign it back: `name = name.Trim();` |
| Warm-up: said the default `= 2` goes at the call site | Header vs call site, again | Default → **method header**. The values you pass → **call site** |

✅ Wins: understood immutable straight away (line 4 of the first example); `Contains` / case-sensitive right on a new example; `Split` 5 lines right; fixed CS0136 by myself; quiz 4.5/5.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| small tools on a string | **string methods** | "Use the built-in string methods, don't write your own loop." |
| the photocopy rule | **immutable** (methods return a **new** string) | "Strings are immutable, so assign it back: `name = name.Trim()`." |
| method after method | **method chaining** | "`input.Trim().ToLower()` is fine, the chain reads left to right." |
| capitals count | **case-sensitive** | "`Contains` is case-sensitive, so lower both sides first." |
| two quotes with nothing | **empty string** (`""`) | "Replace the dashes with an empty string." |
| where `Split` cuts | **separator** (delimiter) | "Split the line on the comma separator." |
| only spaces | **whitespace** | "Reject names that are null, empty or whitespace." |
| `string.` first | **static method** (called on the type) | "`IsNullOrWhiteSpace` is static, so call it on `string`." |
| same name twice | **CS0136** (name used in an enclosing scope) | "CS0136, `c` clashes with the loop variable, rename it." |

---

## 📋 Summary

| Method | Returns | Example → result |
|---|---|---|
| `Trim()` | new `string` | `"  Jahra ".Trim()` → `"Jahra"` |
| `ToUpper()` / `ToLower()` | new `string` | `"hawalli".ToUpper()` → `"HAWALLI"` |
| `Contains("x")` | `bool` | `"Fahaheel".Contains("fah")` → `False` |
| `Replace("a", "b")` | new `string` | `"965-5555".Replace("-", "")` → `"9655555"` |
| `Split(",")` | `string[]` | `"A-B-C".Split("-").Length` → `3` |
| `string.IsNullOrWhiteSpace(x)` | `bool` | `string.IsNullOrWhiteSpace("   ")` → `True` |

The original string never changes. Keep the result with `=`.

---

## 📝 Quiz

1. What does `Console.WriteLine($"[{"  Jahra ".Trim()}]");` print?
2. `"Fahaheel".Contains("fah")`: `True` or `False`? Why?
3. `string name = "  Ali  "; name.Trim(); Console.WriteLine(name);` still prints the spaces. Why, and what is the fix?
4. What does `Console.WriteLine("A-B-C".Split("-").Length);` print?
5. Which is correct: `name.IsNullOrWhiteSpace()` or `string.IsNullOrWhiteSpace(name)`? Why?

<details>
<summary>Answers</summary>

1. `[Jahra]`
2. `False`. `Contains` is case-sensitive: `F` and `f` are different.
3. Strings are immutable. `Trim()` returns a new string, but nobody keeps it. Fix: `name = name.Trim();`
4. `3`
5. `string.IsNullOrWhiteSpace(name)`. It is a static method, called on the type `string`, and the text goes in as the argument.

</details>
