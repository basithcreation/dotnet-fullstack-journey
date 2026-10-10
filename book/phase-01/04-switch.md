# Chapter 1.4: switch and switch expressions

> Learned: Sat 10 Oct 2026 · Code: `lessons/phase-01/07-switch`, `08-grade-calculator`

---

## 🧸 LKG story

**switch statement = a vending machine that does jobs.** You press button A1 and it drops chips. B2 drops juice. Any other button: "Invalid". It doesn't ask "is it A1? no... is it B2? no..." the way an if-else chain does. It looks up your button and does that job.

**switch expression = a price list on the wall.** You look up an item and **get a value back**, which you keep in a box (a variable).

The big difference:
- A machine that only **does jobs** can do **nothing** when you press a wrong button. No harm done.
- A price list **must give you an answer**. If your item isn't on the list, it has nothing to give, and it **breaks** (crash). That's why the compiler wants a "for everything else" line (`_`).

🎬 **Animation idea:** two machines side by side. Press an unknown button on the "statement" machine: a light blinks and nothing happens. Press an unknown button on the "expression" machine: it shakes, sparks fly, and the screen says `SwitchExpressionException`. Then a worker adds a sticker "`_` = everything else", and the machine calmly gives an answer.

---

## 💻 Real explanation

### 1. The switch statement (`case` / `break`)

Use it when you compare **one variable** against exact values, and each case **does something**.

```csharp
string light = "red";

switch (light)
{
    case "red":
        Console.WriteLine("Stop");
        break;
    case "yellow":
        Console.WriteLine("Slow down");
        break;
    case "green":
        Console.WriteLine("Go");
        break;
    case "flashing":            // stacked cases: many values, one job
    case "off":
        Console.WriteLine("Drive carefully");
        break;
    default:
        Console.WriteLine("Unknown light");
        break;
}
```
| Part | Meaning |
|---|---|
| `switch (light)` | the value we check |
| `case "red":` | "if light == "red"" |
| `break;` | stop here and leave the switch. **Required** at the end of every case (or `return;`) |
| stacked cases | empty `case` labels on top of each other share one job |
| `default:` | runs when no case matches (like the last `else`). **Optional** |

Text matching is exact: `"Red"` does **not** match `case "red"`.

### 2. The switch expression (`=>`)

Use it when you want to **get a value back**.

```csharp
int day = 6;

string dayType = day switch
{
    1 or 2 or 3 or 4 or 5 => "Work day",
    6 or 7                => "Weekend",
    _                     => "Invalid day"
};
```
| Part | Meaning |
|---|---|
| `day switch { }` | the variable comes **before** `switch` |
| `=>` | "gives": `6 or 7 => "Weekend"` reads "6 or 7 gives Weekend" |
| `or` | many values, one result (**or pattern**) |
| `_` | "anything else" (**discard pattern**) |
| `,` after each line, `};` at the end | |

**Ranges with relational patterns:**
```csharp
int temp = 35;

string feel = temp switch
{
    >= 40 => "Very hot",
    >= 25 => "Warm",
    >= 10 => "Cool",
    _     => "Cold"
};

Console.WriteLine(feel);    // Warm
```
Test results: 45 → Very hot, 25 → Warm (the edge is included), 24 → Cool, 5 → Cold.

The Day 3 rule still applies: **top to bottom, first match wins**. Put the biggest number first.

### 3. The compiler protects you (better than if-else!)

**Wrong order = build error.** Put `>= 10` at the top:
```csharp
>= 10 => "Cool",
>= 40 => "Very hot",   // ❌ CS8510: The pattern is unreachable
>= 25 => "Warm",       // ❌ CS8510
```
Every number ≥ 40 is also ≥ 10, so those arms can **never** run. The program won't even build.
With if-else, the same mistake gives a **wrong answer silently** (95 → "Pass").

**Missing values = warning, then a crash.** A `char` can hold about 65,000 different characters. If your switch expression doesn't cover all of them:
```
warning CS8509: The switch expression does not handle all possible values
of its input type (it is not exhaustive).
```
If a value comes in that no arm matches, the program **crashes at runtime**:
```
Unhandled exception. System.Runtime.CompilerServices.SwitchExpressionException:
Non-exhaustive switch expression failed to match its input.
Unmatched value was C.
   at Program.<Main>$(String[] args) in ...\Program.cs:line 22
```
Fix: add a `_ => ...` arm at the end. But first check that **no real case is missing**.

### 4. Statement vs expression: which one?

| | switch **statement** | switch **expression** |
|---|---|---|
| Purpose | **does** something | **returns** a value |
| Syntax | `case X:` ... `break;` | `X => value,` |
| Many values | stacked cases | `or` |
| Ranges (`>= 90`) | possible (`case >= 90:`) but rarely used | natural ✅ |
| Must cover every value? | No: with no match, it just skips | Yes: warning CS8509, crash at runtime |
| "Everything else" | `default:` | `_` |

In modern code, the **expression** is preferred when you're choosing a value. You'll still see the statement a lot in older company code.

### 5. Full example: Grade Calculator

```csharp
Console.Write("Enter your mark (0-100): ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int mark))
{
    Console.WriteLine("Please enter a number.");
    return;
}
if (mark < 0 || mark > 100)
{
    Console.WriteLine("Marks must be between 0 and 100.");
    return;
}

char grade = mark switch
{
    >= 90 => 'A',
    >= 75 => 'B',
    >= 60 => 'C',
    >= 50 => 'D',
    _     => 'F'
};

string gradeComment = "";          // declared BEFORE the switch (scope!)

switch (grade)
{
    case 'A':
    case 'B':
        gradeComment = "Great job!";
        break;
    case 'C':
    case 'D':
        gradeComment = "You passed.";
        break;
    case 'F':
        gradeComment = "Try again.";
        break;
    default:
        gradeComment = "Unknown grade";
        break;
}

Console.WriteLine($"Marks: {mark} | Grade: {grade} | {gradeComment}");
```

| Input | Output |
|---|---|
| `abc` | Please enter a number. |
| `-5` / `101` | Marks must be between 0 and 100. |
| `100` / `90` | Grade: A \| Great job! |
| `89` | Grade: B \| Great job! |
| `50` | Grade: D \| You passed. |
| `49` / `0` | Grade: F \| Try again. |

### Reading an error message
`Program.cs(5,5): error CS0163` means **line 5, column 5**. The compiler tells you exactly where to look.

---

## 🎯 Dart comparison

| | Dart 3 | C# |
|---|---|---|
| Statement `break` | not needed | **required** (CS0163) |
| Fall-through from a case with code | not allowed | not allowed |
| Expression syntax | `switch (day) { ... }` | `day switch { ... }` (variable first) |
| Many values | `6 \|\| 7 =>` | `6 or 7 =>` |
| Anything else | `_` | `_` (same) |
| Ranges | `>= 90 =>` | `>= 90 =>` (same) |
| Not exhaustive | **compile error** | **warning** (CS8509) + crash at runtime |

```dart
// Dart 3
var dayType = switch (day) { 6 || 7 => 'Weekend', _ => 'Work day' };
```
```csharp
// C#
var dayType = day switch { 6 or 7 => "Weekend", _ => "Work day" };
```

---

## 🐞 Errors I actually hit

| Error / mistake | Why | Fix |
|---|---|---|
| **CS0163** "Control cannot fall through from one case label" | Removed `break;` after `"Stop"` | Every case ends with `break;` |
| **CS8510** "The pattern is unreachable" | Put `>= 10` above `>= 40` | Biggest / most specific first |
| **CS0103** "The name 'A' does not exist" | Wrote `A or B` without quotes, so C# looked for a **variable** named A | `'A' or 'B'` (a char needs single quotes) |
| **CS8509** not exhaustive + crash on 65 | Typo `'B' or 'D'` instead of `'C' or 'D'`, so `'C'` had no arm | Fix the typo, then add `_` as a safety net |
| Added `_ => "Invalid"` and 65 printed "Invalid" | `_` hid the missing case | `_` is a **safety net**, not a fix |
| `<= 50 => 'F'` after `>= 50 => 'D'` | 50 matched both (it worked only because the first match wins) | Use `_` for "everything else" |
| Range guard without `return;` | Printed the error, then a grade too | Every guard ends with `return;` |
| `mark <= 0 \|\| mark >= 100` | Refused valid marks 0 and 100 | `mark < 0 \|\| mark > 100` |
| Only tested 90 | The `'C'` bug stayed hidden | **Test every branch** |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| vending machine (does jobs) | **switch statement** | "A switch statement is fine here, each case just prints." |
| price list (gives a value) | **switch expression** | "Turn that into a switch expression, it'll be shorter." |
| each `case "red":` | **case label**; `default:` = **default case** | "Add a default case." |
| sliding into the next case | **fall-through** | "C# doesn't allow fall-through." |
| each `pattern => value` line | **arm** | "That arm is unreachable." |
| `>= 90` | **relational pattern** | |
| `6 or 7` | **or pattern** | |
| `_` | **discard pattern** | "Add a discard arm at the end." |
| covers every value | **exhaustive** | "The switch isn't exhaustive, it can throw at runtime." |
| line that can never run | **unreachable code** | |
| crash while running | **exception**; the `at ...` lines are the **stack trace** | "Send me the stack trace." |
| yellow message | **warning** (it still builds) vs red **error** (it doesn't) | "Don't ignore warnings." |
| long if-else → switch | **refactor** | "This if-else chain is long, let's refactor it to a switch expression." |

---

## 📋 Summary

- **Statement** = does jobs: `case X:` + `break;`, stacked cases, optional `default:`
- **Expression** = returns a value: `x switch { pattern => value, _ => ... };`
- Patterns: exact values, `or`, relational `>= 90`, discard `_`
- Order matters (first match wins). A wrong order in an expression → CS8510 build error
- An expression must be **exhaustive**, or you get CS8509 and a runtime crash
- `char` values need single quotes. Test **every** branch.

---

## 📝 Quiz

1. What happens when you build this?
   ```csharp
   string s = n switch { > 5 => "Big", > 10 => "Huge", _ => "Small" };
   ```
2. What error do you get if a `case` has code but no `break;`?
3. Why does a switch expression need `_`, while a switch statement doesn't need `default`?
4. Fix: `char grade = mark switch { >= 50 => "P", _ => "F" }`
5. Your teammate has 6 `else if`s that all check `day == 1`, `day == 2`... What do you suggest, using team words?

<details>
<summary>Answers</summary>

1. It **doesn't build**: CS8510. `> 10` is unreachable, because `> 5` already catches every number above 10.
2. **CS0163**, "Control cannot fall through from one case label to another".
3. An expression must **return a value**. With no match, it has nothing to return, so it crashes. A statement only **does jobs**. With no match, it just skips.
4. `char grade = mark switch { >= 50 => 'P', _ => 'F' };` (single quotes for char, and a `;` at the end)
5. "This if-else chain checks the same variable every time. Let's **refactor** it to a **switch expression**."

</details>
