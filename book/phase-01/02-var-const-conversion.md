# Chapter 1.2: var, const, conversion, Parse and TryParse

> Learned: Wed 7 Oct 2026 · Code: `lessons/phase-01/03-parse-tryparse`, `04-parking-meter`

---

## 🧸 LKG story

- **`var`**: you put a toy in a box, and the box **looks at the toy and takes its shape**. After that, the shape is **locked**.
- **`const`**: a **rule painted on the wall**. "Parking costs 0.250 per hour." Nobody can change it while the program runs.
- **Cast `(int)`**: **scissors**. `2.75` → cut off the `.75` → `2`. It cuts, it does **not** round.
- **`Parse`**: a **strict teacher**. Give them `"abc"` instead of a number and they **scream and stop the class** (crash).
- **`TryParse`**: a **polite teacher**. Give them `"abc"` and they calmly say *"No, that's not a number"* (`false`) and write `0`.

🎬 **Animation idea:** two teachers receive a paper saying "abc". The Parse teacher explodes 💥 (the program crashes). The TryParse teacher shakes their head, holds up a sign saying `false`, and writes `0` on the board.

---

## 💻 Real explanation

### `var`: the type is inferred
```csharp
var exactHeight = 172.8;     // C# sees 172.8 → the type is double
var count = 5;               // int
var name = "Basith";         // string
```
- The type is decided **once**, from the value, and then it's **locked**: `count = "hi";` is an error.
- `var` **must** have a value: `var x;` is an error (CS0818). C# can't guess a type from nothing.

### `const`: values that never change
```csharp
const int CurrentYear = 2026;
const decimal PerHourRate = 0.250m;
```
- The value must be known **when you write the code** (not from user input or the clock).
- Name constants in **PascalCase**.
- Using constants instead of raw numbers removes **magic numbers**.

### Casting: `(int)value` cuts
```csharp
double averageStayHours = 2.75;
int wholeHours = (int)averageStayHours;   // 2  (cut, not rounded)
```
- This is an **explicit conversion**: you're telling C# *"I know I'll lose the decimal part, do it anyway"*.
- The syntax is `(int)value`, **not** `int(value)`.

### `Parse`: text → number, crashes on bad input
```csharp
int year = int.Parse("2000");   // 2000 ✅
int bad  = int.Parse("abc");    // 💥 FormatException: the program crashes
```
Also, with `string? input = Console.ReadLine();`, the call `int.Parse(input)` gives warning **CS8604** ("possible null reference argument"), because `input` might be null.

### `TryParse`: the safe way
```csharp
Console.Write("Enter your birth year: ");
string? input = Console.ReadLine();

bool isNumber = int.TryParse(input, out int birthYear);
Console.WriteLine($"valid number? {isNumber}");
Console.WriteLine($"Birth year: {birthYear}");
```
| Input | `isNumber` | `birthYear` |
|---|---|---|
| `"2000"` | `true` | `2000` |
| `"abc"` | `false` | `0` |
| `"2.5"` | `false` | `0` (an int can't hold 2.5) |
| (null) | `false` | `0`, with **no** warning |

- It returns a **bool**: did it work?
- The number comes out through **`out int birthYear`**: an **out parameter**. It creates the variable right there.
- It **never crashes**, and it handles null, so there's no CS8604 warning.

### TryParse **refuses**, cast **cuts**: two different tools
| | Input `2.75` | What it does |
|---|---|---|
| `int.TryParse("2.75", out int a)` | `false`, `a = 0` | **refuses**: "this text is not a whole number" |
| `(int)2.75m` | `2` | **cuts** off the decimal part |

### `string?`: may be null
The `?` means "this can be null". `Console.ReadLine()` returns `string?` because there might be no input at all.

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| Inferred type | `var x = 5;` | `var x = 5;` (same idea) |
| Never changes | `const` (compile-time) / `final` (set once) | `const` (compile-time). `readonly` comes later |
| Strict parse | `int.parse('abc')` → throws | `int.Parse("abc")` → throws |
| Safe parse | `int.tryParse('abc')` → returns `null` | `int.TryParse("abc", out int n)` → returns `false`, `n = 0` |
| double → int | `2.75.toInt()` → `2` (cuts) | `(int)2.75` → `2` (cuts) |
| May be null | `String?` | `string?` |

Main difference: Dart's `tryParse` returns `int?` (null on failure). C#'s `TryParse` returns a `bool` and gives the number through `out`.

---

## 🐞 Errors I actually hit

| Mistake | Why it's wrong | Fix |
|---|---|---|
| `var x;` | `var` needs a value to know the type (CS0818) | `var x = 0;` or `int x;` |
| `int(2.75)` | Wrong cast syntax | `(int)2.75` |
| Gave the same "why" for TryParse and cast | They're different tools | TryParse **refuses** (false, 0). Cast **cuts** (2) |
| Couldn't explain why Parse warns on `input` | `ReadLine` returns `string?` | Parse can't handle null → CS8604. TryParse can. |
| Used `double` for VAT | VAT is money | `decimal` |
| Said "fixed" without running the code | — | Always `dotnet run` before saying "done" |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| box takes the toy's shape | **type inference** (`var`) | "The compiler infers the type, it's still strongly typed." |
| rule on the wall | **constant** (`const`) | "Make the rate a constant, don't hard-code it." |
| scissors | **cast** / **explicit conversion**, which **truncates** | "The cast truncates, it doesn't round." |
| TryParse refuses | **parsing fails**, returns `false` | "If parsing fails, show an error and return." |
| `out int x` | **out parameter** | "TryParse gives the value through an out parameter." |
| may be empty | **nullable** type | "ReadLine returns a nullable string." |
| crash | **exception** (`FormatException`) | "Parse throws a FormatException on bad input." |

---

## 📋 Summary

- `var` = the type is inferred and locked, and it must have a value
- `const` = a fixed value known when you write the code, PascalCase
- `(int)2.75` = `2` (cuts, never rounds)
- `Parse` crashes on bad input. `TryParse` returns `true`/`false` + the value through `out` (0 on failure)
- Use `TryParse` for user input, always

---

## 📝 Quiz

1. Why is `var total;` an error?
2. What does `(int)9.99` give?
3. `int.TryParse("12a", out int n)`: what is returned, and what is `n`?
4. Why does `int.Parse(input)` show a warning when `input` is `string?`?
5. Can a `const` get its value from `Console.ReadLine()`? Why?

<details>
<summary>Answers</summary>

1. `var` decides the type from the value. With no value, it can't decide.
2. `9`. The cast cuts the decimal part, it doesn't round to 10.
3. It returns `false`, and `n` is `0`.
4. `input` may be null, and `Parse` can't handle null (warning CS8604, possible null reference).
5. No. A `const` value must be known **when you write the code**. User input only exists when the program runs.

</details>
