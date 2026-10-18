# Chapter 1.12: double, Infinity and the && guard (Console Calculator v1)

> Learned: Sat 17 Oct 2026 · Code: `lessons/phase-01/18-double-tryparse`, `projects/02-console-calculator` (v1)

---

## 🧸 LKG story

**`int` holds whole sweets, `double` can hold half a sweet.** If you share 7 sweets between 2 kids with `int`, each kid gets 3 and the half sweet is thrown in the bin. With `double`, each kid gets 3.5.

**Dividing by zero is asking "share 10 sweets between 0 kids".** `int` refuses loudly: the program crashes. `double` doesn't crash. It quietly answers **∞** (Infinity), which looks like a result but is useless to the user. So the calculator needs a guard that checks the second number **before** dividing.

🎬 **Animation idea:** a division machine with two number boxes and an `int` / `double` switch. `7 / 2` in `int` mode drops 3 whole sweets per kid and the half sweet falls into a bin labelled "decimals cut off". In `double` mode the half sweet stays. Type `0` as the second number: `int` mode explodes (crash), `double` mode shows a glowing ∞. Then switch on the zero guard: a guard stops the 0 at the door with "Cannot divide by zero".

**The operator guard is a door that only opens for 4 keys: `+`, `-`, `*`, `/`.** The door says: "if this key is not `+` **and** not `-` **and** not `*` **and** not `/`, it's the wrong key". If you write `||` instead of `&&`, the door says "not `+` **or** not `-`", and every key fails, even `+`, because `+` is not `-`.

🎬 **Animation idea:** type an operator into a box and pick `&&` or `||`. Each part of the condition (`op != "+"`, `op != "-"`, ...) lights up true or false, then the whole condition lights up. With `&&`, only a wrong key like `%` is rejected. With `||`, even `+` is rejected and the door stays shut.

---

## 💻 Real explanation

### 1. `int` division vs `double` division

```csharp
Console.WriteLine(7 / 2);     // int ÷ int
Console.WriteLine(7.0 / 2);   // a double is involved
```
```
3
3.5
```

The division happens **first**, then `WriteLine` prints what it gets:
- `int ÷ int` → the result is an `int` → the decimals are **cut off** (truncation, not rounding)
- if one side is a `double` → the result is a `double` → the decimals stay

A calculator uses `double` so the user can type `2.5` **and** get `10 / 4 = 2.5`.

### 2. `double.TryParse`

Exactly like `int.TryParse`, only the type changes:

```csharp
Console.Write("Enter the price: ");
string? input = Console.ReadLine();

if (double.TryParse(input, out double price))
    Console.WriteLine($"With delivery: {price + 1.5}");
else
    Console.WriteLine("That's not a number.");
```
```
Enter the price: 2.5
With delivery: 4

Enter the price: abc
That's not a number.
```

The `out` box must be a plain `double`. A `double?` box (which can also hold `null`) is a different type, and C# refuses it (CS1503, see the mistakes table).

### 3. Dividing by zero with `double`

```csharp
double a = 10;
double b = 0;
Console.WriteLine(a / b);
```
```
∞
```

| Code | Result |
|---|---|
| `a / b` with two `int` variables, `b = 0` | crash: `DivideByZeroException` (writing `10 / 0` literally doesn't even compile: CS0020) |
| `10.0 / 0` | `∞` (Infinity) |
| `0.0 / 0` | `NaN` (Not a Number) |

`double` doesn't warn you, so **you** add the guard. Only the **second** number (the divisor) matters. `2 / 10 = 0.2` is fine, only exactly `0` is a problem:

```csharp
if (secondNumber == 0)
    Console.WriteLine("Cannot divide by zero.");
else
    Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
```

### 4. `switch` on a string

`case` values can be text in **double quotes**. The match is **exact**: `"+ "` (with a space) is not `"+"`, and `"s"` is not `"S"`. Only **one** case runs, then `break` jumps out of the switch.

```csharp
switch (op)
{
    case "+":
        Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
        break;
    case "-":
        Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
        break;
    // * and / ...
    default:
        Console.WriteLine("Unknown operator.");
        break;
}
```

### 5. The operator guard: `&&`, not `||`

Check the operator **right after reading it**, so the user doesn't type the second number for nothing:

```csharp
string? op = Console.ReadLine();
if (op != "+" && op != "-" && op != "*" && op != "/")
{
    Console.WriteLine("Unknown operator. Try again.");
    continue;
}
```

Why `&&`? Write out the sides for `op = "+"`:

| Condition | `"+" != "+"` | `"+" != "-"` | Result |
|---|---|---|---|
| `op != "+" && op != "-"` | false | true | **false** → `+` is accepted ✅ |
| `op != "+" \|\| op != "-"` | false | true | **true** → `+` is "unknown" ❌ |

With `||`, every value is different from at least one of them, so the guard rejects everything.

The `default` case in the switch can't run any more (the guard catches bad operators first), but keep it as a **safety net** for when someone adds a new operator later.

### 6. The whole calculator (v1)

```csharp
Console.WriteLine("Simple Calculator (type q to quit)");

while (true)
{
    Console.Write("First Number: ");
    string? input = Console.ReadLine();
    if (input == "q")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    if (!double.TryParse(input, out double firstNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    Console.Write("Operator (+ - * /): ");
    string? op = Console.ReadLine();
    if (op != "+" && op != "-" && op != "*" && op != "/")
    {
        Console.WriteLine("Unknown operator. Try again.");
        continue;
    }

    Console.Write("Second number: ");
    string? input2 = Console.ReadLine();
    if (!double.TryParse(input2, out double secondNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    switch (op)
    {
        // + - * / as above, with the zero guard in "/"
    }
}
```
```
Simple Calculator (type q to quit)
First Number: 7
Operator (+ - * /): -
Second number: 10
7 - 10 = -3
First Number: abc
That's not a number. Try again.
First Number: 8
Operator (+ - * /): /
Second number: 0
Cannot divide by zero
First Number: q
Goodbye!
```

`while (true)` is an **infinite loop with a break exit**: the loop never stops by itself, only `q` (with `break`) ends it.

---

## 🎯 Dart comparison

```dart
// Dart
final price = double.tryParse(input ?? '');   // null when it fails
if (price == null) { print('Not a number'); }
print(7 ~/ 2);   // 3   (~/ is whole-number division)
print(7 / 2);    // 3.5 (/ always gives a double in Dart)
print(10 / 0);   // Infinity, same as C# double
```
```csharp
// C#
if (!double.TryParse(input, out double price)) { Console.WriteLine("Not a number"); }
Console.WriteLine(7 / 2);     // 3   (int ÷ int)
Console.WriteLine(7.0 / 2);   // 3.5
Console.WriteLine(10.0 / 0);  // ∞
```

The big difference: in Dart, `/` **always** gives a decimal. In C#, `/` with two `int`s cuts off the decimals. Switch on a string works the same in both, but Dart strings can use single quotes.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| `while (firstNumber == secoundNumber)` → the loop ended after typing `5` | The loop compared numbers, so `5 == 0` was false | The loop should only stop on `q`: use `while (true)` + `break` |
| **CS1503** `cannot convert from 'out double?' to 'out double'` (plus a strange `ReadOnlySpan<byte>` error) | The `out` box was declared as `double?` | Declare it inside: `out double firstNumber`. The second error disappears with the first |
| **CS8600** warning on `string input = Console.ReadLine();` | `ReadLine()` can return `null` | `string? input` |
| `break` in the operator guard → the whole calculator stopped | `break` leaves the loop | `continue` asks again |
| Said `5 % 7` is "false" | `%` gives a number, never true/false | `5 % 7 = 5` (the left number is smaller, so all 5 are left over) |
| Said `7 / 2` prints 3.5 | Forgot integer division | `int ÷ int` cuts off: 3 |
| Said a switch prints two cases | Only one case runs | `"+ "` ≠ `"+"`, so only `default` runs |
| Answered the `\|\|` question without writing the sides | Skipped the working out | Write each side: false \|\| true → true |
| Wrote "returns cannot divide by zero" | Mixed up C#'s result with my own message | C# returns `∞`; "Cannot divide by zero" is the guard's message |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| whole-sweet division | **integer division** / **truncation** | "`7 / 2` is integer division, it truncates to 3." |
| convert text to a decimal number | **parse as a double** | "Parse the input as a double with `double.TryParse`." |
| the number you divide by | **divisor** (and **dividend**) | "The divisor must not be zero." |
| ∞ | **Infinity** / **positive infinity** | "Double doesn't throw on `/ 0`, it returns Infinity." |
| "not a number" from `0.0 / 0` | **NaN** | "Check for NaN before showing the result." |
| loop forever until q | **infinite loop with a break exit** | "It's a `while (true)` loop with a break on q." |
| the case for everything else | **default case** / **safety net** | "Keep the default case as a safety net." |
| old code left in comments | **dead code** | "Remove the dead code, Git remembers the old version." |

---

## 📋 Summary

- `int ÷ int` cuts off the decimals (`7 / 2 = 3`). Use `double` when decimals matter
- `double.TryParse(input, out double x)` works like `int.TryParse`. The `out` box must be a plain `double`
- `double / 0` gives `∞` instead of crashing, so add a guard: `if (secondNumber == 0)`
- `switch` can match strings: exact text, double quotes, only one case runs
- "Not any of these" = `!=` joined with `&&`. With `||`, everything is rejected
- Check each input right after reading it (guard + `continue`), so the user finds out straight away

---

## 📝 Quiz

1. What do `7 / 2` and `7.0 / 2` print?
2. Why does the calculator use `double` and not `int`?
3. The user types `"+ "` (with a space). Which case runs in `switch (op) { case "+": ... default: ... }`?
4. Does `op != "+" || op != "-"` reject `+`? Write out both sides.
5. If you delete the zero guard, what does the calculator print for `8 / 0`?

<details>
<summary>Answers</summary>

1. `3` (integer division cuts off .5) and `3.5`.
2. `double` can hold decimals from the user (`2.5`) and give decimal answers (`10 / 4 = 2.5`).
3. `default`. `"+ "` is not exactly `"+"`: a space is a character too. (`Trim()` will fix this later.)
4. Yes: `"+" != "+"` is false, `"+" != "-"` is true, and `false || true` is true, so `+` is called unknown. That's why the guard uses `&&`.
5. `8 / 0 = ∞`. `double` doesn't crash, it returns Infinity.

</details>
