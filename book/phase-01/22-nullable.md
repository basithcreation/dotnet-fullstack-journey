# Chapter 1.22: Nullable types and the null operators (`?`, `??`, `?.`, `??=`)

> Learned: Sat 24 Oct 2026 · Code: `lessons/phase-01/32-nullable`

---

## 🧸 LKG story

**The empty box on the parcel form.** A KPOST parcel form has a box: "Weight (kg): ___". When the parcel is weighed, you write `12`. When it hasn't been weighed yet, the box stays **empty**. Empty is not `0`: a 0 kg parcel would be wrong. "Not weighed yet" is its own answer.

In C#, the empty box is **`null`**: no value at all.

The office has 3 rules for empty boxes:
- **"If the box is empty, use this instead"** → `??`
- **"If the box is empty, don't even try"** (you can't phone a sender who isn't there) → `?.`
- **"If the box is empty, fill it in. If it's already filled, don't touch it"** → `??=`

🎬 **Animation idea:** a row of boxes, some empty and some with a value. Pick an operator (`??`, `?.`, `??=`) and press Run. An empty box lights up and the backup value slides in; a full box keeps its value. Turn off the `?` in `?.` and the empty box explodes into a red `NullReferenceException`.

---

## 💻 Real explanation

### 1. `int?`: a type that can be empty

A normal `int` must **always** hold a number:

```csharp
int weight = null;   // ❌ error CS0037: Cannot convert null to 'int' because it is a non-nullable value type
```

Add `?` to the type and it becomes a **nullable type**: "an int, or null".

```csharp
int? weight = null;
Console.WriteLine($"[{weight}]");
Console.WriteLine(weight.HasValue);

weight = 12;
Console.WriteLine($"[{weight}]");
Console.WriteLine(weight.HasValue);
```
```
[]
False
[12]
True
```

- `null` inside `$"..."` prints **nothing** (an empty string). Dart prints the word `null`
- `.HasValue` is a `bool`: `True` when there is a number
- `string?` works the same way: a string that may be null. `Console.ReadLine()` returns a `string?`

### 2. `??`: the backup value

```csharp
int? boxes = null;
int total = boxes ?? 1;
Console.WriteLine($"Boxes: {total}");

boxes = 4;
total = boxes ?? 1;
Console.WriteLine($"Boxes: {total}");

string? driver = null;
Console.WriteLine($"Driver: {driver ?? "Not assigned"}");
```
```
Boxes: 1
Boxes: 4
Driver: Not assigned
```

`a ?? b` means: use `a`, but if `a` is null, use `b`. Its real name is the **null-coalescing operator**, and `b` is the **default** (or **fallback**) value.

You can't put an `int?` straight into an `int`, because it might be empty:

```csharp
int total = boxes;        // ❌ error CS0266: Cannot implicitly convert type 'int?' to 'int'
int total = boxes ?? 1;   // ✅ now it always gets a real number
```

### 3. `?.`: "if it's null, don't even try"

```csharp
string? sender = null;
Console.WriteLine($"[{sender?.ToUpper()}]");
Console.WriteLine($"[{sender?.ToUpper() ?? "UNKNOWN"}]");

sender = "omar";
Console.WriteLine($"[{sender?.ToUpper()}]");
```
```
[]
[UNKNOWN]
[OMAR]
```

- `sender?.ToUpper()`: if `sender` is null, skip the method and give back `null`
- without the `?`, `sender.ToUpper()` **crashes** with a **`NullReferenceException`**, the most common bug in C#. The editor warns you first with **CS8602: Dereference of a possibly null reference**
- `?.` and `??` work well together: "uppercase it if it exists, otherwise UNKNOWN"
- Real name: the **null-conditional operator**

### 4. `??=`: "fill it only if it's empty"

```csharp
string? area = null;
area ??= "Hawalli";
area ??= "Jahra";
Console.WriteLine(area);
```
```
Hawalli
```

The second line fills the empty box. On the third line the box is already full, so `"Jahra"` is ignored. `area ??= "Hawalli";` is short for `if (area == null) { area = "Hawalli"; }`. Real name: the **null-coalescing assignment** operator.

### `??` vs `??=`

```csharp
int? extra = null;
int total = extra ?? 5;    // total = 5, extra is STILL null (it only reads)
int total = extra ??= 5;   // total = 5, but extra is now 5 too (it writes)
```

`??` **reads** with a backup. `??=` **writes** into the box. Use `??` when you only need a value.

---

## 🎯 Dart comparison

Dart has the same null safety, with the same symbols:

| Dart | C# |
|---|---|
| `int? weight = null;` | `int? weight = null;` |
| `weight ?? 0` | `weight ?? 0` |
| `user?.name` | `user?.Name` |
| `area ??= 'Hawalli';` | `area ??= "Hawalli";` |
| `weight != null` | `weight != null` or `weight.HasValue` |
| prints `null` | prints nothing (empty string) |
| prints `false` | prints `False` |

One difference: in Dart, using a nullable value the wrong way is a compile **error**. In C#, for strings and other reference types, it's a yellow **warning** (CS8600, CS8602), so the code still runs and can crash. Read the warnings!

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Predicted `[null]` for a null `int?` | Dart habit: Dart prints `null` | C# prints nothing: `[]` |
| Wrote `false` / `Ture` | Dart prints small letters | C# prints `True` / `False` |
| Predicted `1` and `4` instead of `Boxes: 1` | Predicted only the variable | Predict the **whole line** |
| `branch = "Main";` instead of `branch ??= "Main";` | The output looked right because `branch` was null | Test with a value: `branch = "Jahra"` must stay `Jahra` |
| Label `Driver:` on the phone line | Copy-paste slip | Read the label every time you copy a line |
| Quiz: `int total = extra ??= 5;` | Mixed up `??` and `??=` | `??` reads, `??=` writes (it changed `extra` too) |

✅ Wins: all 4 lines of the `?.` / `??=` example right, including "`Jahra` is ignored"; found the floor answer from the `boxes` example; tested both paths (null and not null); quiz 4.5/5.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| empty box | **null** | "The weight is null until the parcel is scanned." |
| a box that may be empty | **nullable type** (`int?`, `string?`) | "Make `Weight` nullable, new parcels aren't weighed yet." |
| "use this instead" | **null-coalescing operator** (`??`) | "Use `??` to give it a default value." |
| backup value | **default** / **fallback** value | "The fallback is 'Not assigned'." |
| "don't even try" | **null-conditional operator** (`?.`) | "Use `?.` here or it throws when the sender is null." |
| the crash | **`NullReferenceException`** | "Production crashed with a NullReferenceException." |
| the yellow warning | **CS8602**: dereference of a possibly null reference | "Fix the CS8602 warnings before they become crashes." |
| "fill only if empty" | **null-coalescing assignment** (`??=`) | "`??=` sets the default only if it's still null." |
| changes the variable | **mutates** / **side effect** | "`??=` mutates the variable, `??` doesn't." |

---

## 📋 Summary

| Code | Name | Means | Example → result |
|---|---|---|---|
| `int?` | nullable type | can be empty | `int? w = null;` |
| `a ?? b` | null-coalescing | `a`, or `b` if `a` is null | `null ?? 1` → `1` |
| `a?.M()` | null-conditional | call `M` only if `a` isn't null | `null?.ToUpper()` → `null` |
| `a ??= b` | null-coalescing assignment | put `b` in `a` only if `a` is null | `area` is `"Hawalli"`, `area ??= "Jahra"` → stays `Hawalli` |

---

## 📝 Quiz

1. Will `int age = null;` compile? If not, what's the fix?
2. What does this print? `int? stock = null; Console.WriteLine($"Stock: [{stock}]");`
3. What does `count` hold after `int? count = 7; count ??= 99;`?
4. `string? city = null;` Which line can crash: A `city?.Trim() ?? "none"` or B `city.Trim()`? Why?
5. Fill the blank so `total` is `5` when `extra` is null, without changing `extra`: `int total = extra ___ 5;`

<details>
<summary>Answers</summary>

1. No, error CS0037. Fix: `int? age = null;`
2. `Stock: []`
3. `7`. `??=` doesn't touch a box that already has a value.
4. B. `city` is null, so `.Trim()` throws a `NullReferenceException`. Line A uses `?.` (skip if null) and `??` (fallback).
5. `??`. (`??=` would also set `extra` to 5.)

</details>
