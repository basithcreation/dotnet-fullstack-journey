# Chapter 1.1: Data types, what can go in the box

> Learned: Wed 7 Oct 2026 · Code: `lessons/phase-01/01-data-types`, `02-cafe-bill`

---

## 🧸 LKG story

A **variable** is a **box with a label**. The label is the name. But every box also has a **shape**, and only things of that shape fit inside:

- A box for **whole numbers** (3, 28, -5) can't hold 2.5.
- A box for **money** must be exact, without losing a single fils.
- A box for **yes/no** holds only `true` or `false`.
- A box for **one letter** holds exactly one character.
- A box for **text** holds words and sentences.

The shape of the box is the **data type**.

🎬 **Animation idea:** a shape-sorter toy. A round number `2.5` tries to go into the square "int" hole and bounces off. `3` drops straight in.

---

## 💻 Real explanation

```csharp
int age = 28;
```
reads as: *"Make a box named `age` that holds only whole numbers (`int`), and put 28 in it."*

### The six basic types

| Type | Holds | Example | Notes |
|---|---|---|---|
| `int` | whole numbers | `int days = 3;` | about ±2.1 billion |
| `double` | decimal numbers (approximate) | `double height = 172.8;` | fast, for science/measurements |
| `decimal` | decimal numbers (**exact**) | `decimal price = 1.350m;` | **use for money**, needs the `m` suffix |
| `bool` | `true` / `false` | `bool isWeekend = false;` | |
| `char` | **one** character | `char tableLetter = 'C';` | **single** quotes |
| `string` | text | `string name = "Fatima";` | **double** quotes |

### Why `decimal` for money? The `0.1 + 0.2` problem

```csharp
double a = 0.1;
double b = 0.2;
Console.WriteLine($"double : {a + b}");    // double : 0.30000000000000004

decimal c = 0.1m;
decimal d = 0.2m;
Console.WriteLine($"decimal : {c + d}");   // decimal : 0.3
```

`double` stores numbers in **binary** (base 2), and `0.1` can't be written exactly in binary, just like 1/3 can't be written exactly in decimal (0.3333...). So a tiny error appears. That's fine for a distance or a temperature, but **never** for money: tiny errors add up over thousands of bills.

`decimal` stores numbers in **base 10**, the way we write money, so `0.1` is exactly `0.1`.

🎬 **Animation idea:** two cashiers. The "double" cashier gives change of 0.30000000000000004 KWD and the customer looks confused. The "decimal" cashier gives exactly 0.300.

### Safe and unsafe conversions ("pouring")

Think of pouring water from one cup into another:
- **Small cup → big cup** is **safe**, nothing spills: `int` → `decimal` or `int` → `double` happens **automatically** (**implicit conversion**).
- `decimal` ↔ `double` is **not** automatic: they store numbers in different ways, so C# makes you decide.

```csharp
int days = 3;
decimal dailyFee = 0.750m;
decimal fee = days * dailyFee;            // int is converted to decimal automatically ✅
Console.WriteLine($"Fee: {fee:F3} KWD");  // Fee: 2.250 KWD
```

### Formatting money: `:F3`

Kuwaiti dinar has 3 decimal places (1 KWD = 1000 fils), so use `:F3`:
```csharp
decimal total = 4.8m;
Console.WriteLine($"{total:F3} KWD");   // 4.800 KWD
```
Always write the number. `:F` alone uses the PC's region settings, so it may show 2 digits on one computer and 3 on another.

### `Console.Write` vs `Console.WriteLine`
- `Console.WriteLine("Hi")` prints and then moves to a **new line**
- `Console.Write("Name: ")` prints and **stays on the same line** (good for questions)

### Naming in C#
- Local variables: **camelCase**: `totalBillAmount`, `latteQuantity`
- Constants, methods and classes: **PascalCase**: `MaxDailyFee`

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| Whole number | `int` (64-bit) | `int` (32-bit). `long` is the 64-bit one |
| Decimal | `double` | `double` |
| Exact money type | ❌ none built in (use a package or store fils as `int`) | ✅ `decimal` |
| Yes/no | `bool` | `bool` |
| Text | `String` (capital S) | `string` (small s) |
| One character | ❌ no char type (a String of length 1) | `char` with `'A'` |
| Quotes | `'text'` or `"text"` | `"text"` for strings, `'A'` only for one char |

⚠️ The two biggest Dart habits to break: `String` → `string`, and `'text'` → `"text"`.

---

## 🐞 Errors I actually hit

| Error | Why | Fix |
|---|---|---|
| Wrote `String` | Dart habit | C# uses `string` |
| `'text'` → error CS1012 "Too many characters in character literal" | Single quotes are only for **one** `char` | Use `"text"` |
| `decimal price = 1.35;` → error CS0664 | `1.35` without `m` is a `double` | `1.35m` |
| Output `x1.000 cakes` | Used `:F3` on a quantity | `:F3` only on **money** |
| Output `Fee: 0.750` with no currency | Didn't read the output like a customer | `Fee: 0.750 KWD` |
| Renamed a variable by hand and the build broke twice | Missed one place | Use **F2** (rename) in VS Code |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| box | **variable** | "Store the result in a variable called `wholeHours`." |
| shape of the box | **data type** | "Use `decimal` as the type for money." |
| safe pour | **implicit conversion** | "int to decimal is an implicit conversion." |
| tiny error in double | **floating-point precision error** | "Don't use double for money, you'll get rounding errors." |
| `:F3` | **format specifier** | "Format money with F3." |
| `m` after a number | **literal suffix** | "Add the m suffix, it's a decimal literal." |

---

## 📋 Summary

- `int` whole numbers · `double` approximate decimals · `decimal` exact (money, `m`) · `bool` · `char` `'A'` · `string` `"text"`
- `0.1 + 0.2` in double = `0.30000000000000004`, in decimal = `0.3`
- `int` → `decimal`/`double` is automatic. `decimal` ↔ `double` is not.
- Money: `decimal` + `:F3` + the currency in the text
- camelCase for variables, PascalCase for constants

---

## 📝 Quiz

1. Which type would you use for a product price in KWD, and why?
2. What's wrong with `char letter = "B";`?
3. What does `0.1 + 0.2` print with `double`?
4. Is `decimal fee = 3 * 0.250m;` OK? Why?
5. What does `Console.WriteLine($"{2.5m:F3}");` print?

<details>
<summary>Answers</summary>

1. `decimal`, because it's **exact**. `double` gives tiny rounding errors that add up.
2. `"B"` is a `string` (double quotes). A `char` needs single quotes: `'B'`.
3. `0.30000000000000004`
4. Yes. `3` is an `int`, and int → decimal is a safe **implicit conversion**.
5. `2.500`

</details>
