# Chapter 1.20: Calculator v2, moving logic into methods (my own Try pattern)

> Learned: Wed 21 Oct 2026 · Code: `projects/02-console-calculator` (v2)

---

## 🧸 LKG story

**The front desk and the back office.** In v1 the calculator was one person doing everything at the front desk: taking the numbers, checking the operator, doing the maths, and shouting the answer.

In v2 the front desk (the `while` loop) only **takes the order and gives the answer**. The checking and the maths go to two helpers in the back office:

- **`IsValidOperator`** checks the order: "Is this `+ - * /`?" → yes or no
- **`TryCalculate`** works like `TryParse`: "Did it work?" → yes or no, **plus** the answer in an `out` box

🎬 **Animation idea:** type a first number, an operator and a second number, then press "Calculate". The values travel from the loop into `IsValidOperator` (green ✓ or red ✗), then into `TryCalculate`. Inside it, the divide-by-zero door is checked first. Then the matching switch arm lights up. It returns a big `true` / `false` badge and drops the value into the `out result` box. The loop prints the line, or "Cannot divide by zero".

---

## 💻 Real explanation

### 1. Step 1: a `bool` method replaces the long `&&` check

v1:
```csharp
if (op != "+" && op != "-" && op != "*" && op != "/")
```

v2:
```csharp
if (!Calc.IsValidOperator(op))

static class Calc
{
    public static bool IsValidOperator(string? op)
    {
        return op == "+" || op == "-" || op == "*" || op == "/";
    }
}
```

- The method answers the **positive** question "is it valid?", so it uses `==` with `||` (+ **or** - **or** ...)
- The `!` at the call flips it: "if **not** valid"
- Moving code into its own method is a **refactoring** called **extract method**

### 2. Step 2: my own Try pattern

```csharp
public static bool TryCalculate(double a, string? op, double b, out double result)
{
    if (op == "/" && b == 0)
    {
        result = 0;
        return false;
    }

    result = op switch
    {
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        _ => a / b
    };
    return true;
}
```

The rules of the **Try pattern** (same as `double.TryParse`):

| Case | Returns | `out result` |
|---|---|---|
| It worked | `true` | the answer |
| It failed (divide by zero) | `false` | the **default** (`0`) |

Every path must give `result` a value before `return`, or you get **CS0177**.

### 3. Step 3: the loop only does input and output

```csharp
if (!Calc.TryCalculate(firstNumber, op, secondNumber, out double result))
{
    Console.WriteLine("Cannot divide by zero");
    continue;
}
Console.WriteLine($"{firstNumber} {op} {secondNumber} = {result}");
```
```
First Number: 10
Operator (+ - * /): *
Second number: 4
10 * 4 = 40
First Number: 10
Operator (+ - * /): /
Second number: 0
Cannot divide by zero
```

The 21-line `switch` statement became one `if` and one `WriteLine`. The output shows `*` now (v1 printed `x`), because the line prints `{op}`.

### 4. Warning CS8509: the switch is not exhaustive

When the last arm was `"/" => a / b`, the build said:

```
warning CS8509: The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '""' is not covered.
```

A `string` can be **any** text. If no arm matches, a switch expression **crashes at runtime**. The fix is the **discard pattern** `_` ("anything else") as the last arm. It is safe here because `IsValidOperator` already let only `+ - * /` through.

---

## 🎯 Dart comparison

Dart has no `out` parameters. In Dart you would return a nullable value or a record instead:

```dart
double? tryCalculate(double a, String op, double b) {
  if (op == '/' && b == 0) return null;
  return switch (op) {
    '+' => a + b,
    '-' => a - b,
    '*' => a * b,
    _ => a / b,
  };
}
```

C# can do that too (nullable types come next), but the `bool` + `out` Try pattern is the classic .NET style (`int.TryParse`, `Dictionary.TryGetValue`).

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| CS8509 warning | Last arm was `"/"`, so other strings weren't covered | Make the last arm `_ => a / b` |
| `return true` on divide by zero, `return false` at the end | `true` / `false` swapped | Failed → `false`; worked → `true` |
| `result = a;` on failure | Gives back `10` for `10 / 0`, which looks like a real answer | `result = 0;` (the default, like `TryParse`) |
| Tested only the bad operator path | Output can hide bugs | Test every path: good, bad operator, divide by zero |
| Typo `dicide` | Typing fast | Read the text in quotes before running |
| Commented out the old `switch` | Wanted to keep it | Delete **dead code**; Git keeps the history |

✅ Wins: all three `IsValidOperator` blanks right first time; fixed the swapped `true` / `false` from a hint; predicted `10 * 4 = 40` including the `*`; tested both paths in one run.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| moved code into a method | **extract method** / **refactoring** | "I extracted the operator check into `IsValidOperator`." |
| my own TryParse | **Try pattern** | "`TryCalculate` follows the Try pattern." |
| `0` on failure | **default value** of the `out` parameter | "On failure it returns false and sets `result` to its default." |
| `_` arm | **discard pattern** | "Add a discard arm so the switch is exhaustive." |
| switch doesn't cover all values | **not exhaustive** (CS8509) | "CS8509: the switch expression isn't exhaustive." |
| old code in comments | **dead code** | "Please remove the dead code, it's in the Git history." |
| stage everything | **`git add -A`** | "Check `git status` before `git add -A`." |

---

## 📋 Summary

| Piece | Job |
|---|---|
| `while` loop | read input, print output |
| `Calc.IsValidOperator(op)` | `bool`: is it `+ - * /`? |
| `Calc.TryCalculate(a, op, b, out result)` | `bool` "did it work?" + the answer through `out` |
| `result = 0; return false;` | failure path (divide by zero) |
| `_ => a / b` | discard arm, makes the switch exhaustive |

---

## 📝 Quiz

1. Why does `IsValidOperator` use `==` and `||` while v1 used `!=` and `&&`?
2. What should a Try method return, and put in `out`, when it fails?
3. What does warning CS8509 mean, and how did I fix it?
4. Why is `result = a;` on divide by zero a bad idea?
5. What does `git add -A` stage?

<details>
<summary>Answers</summary>

1. The method asks the positive question "is it valid?" (+ OR - OR * OR /). v1 asked "is it NOT valid?" (not + AND not - ...). The `!` at the call flips the method's answer.
2. `false`, and the default value (`0` for numbers) in the `out` parameter.
3. The switch expression is not exhaustive: some strings match no arm and would crash at runtime. Fix: a `_` discard arm at the end.
4. `10 / 0` would hand back `10`, which looks like a real answer if someone forgets to check the `bool`.
5. Every change in the whole repo: new, edited and deleted files.

</details>
