# Chapter 1.3: if / else, making decisions

> Learned: Thu 8 Oct 2026 · Code: `lessons/phase-01/05-if-else`, `06-parking-meter-v2`

---

## 🧸 LKG story

An `if` is a **traffic light**: if it's green, go; else, stop.

An `if / else if / else` chain is a **row of doors**. You walk along and go through the **first door that opens**. Once you're through, you **don't try the other doors**.

A **guard** is a **security guard at the entrance**: "No ticket? Stop. Go home." (`return;`). Only good visitors get inside.

**Scope** is a **room**: a toy made inside a room (`{ }`) disappears when you leave the room (`}`). If you need the toy later, make it **before** you enter the room.

🎬 **Animation idea:** a character walks along 3 doors labelled `>= 100`, `<= 0`, `else`. The first door that opens swallows them, and the other doors fade away.

---

## 💻 Real explanation

### Comparison operators
| Operator | Meaning | `5 ? 5` |
|---|---|---|
| `==` | equal | `5 == 5` → true |
| `!=` | not equal | `5 != 5` → false |
| `>` | greater than | `5 > 5` → **false** (the edge is out) |
| `>=` | greater or equal | `5 >= 5` → **true** (the edge is in) |
| `<` `<=` | less than / less or equal | |

⚠️ `=` **saves** a value (assignment). `==` **checks** a value (comparison).

### Logical operators
| | Meaning | Example |
|---|---|---|
| `&&` | AND (both must be true) | `temp >= 30 && temp <= 40` |
| `\|\|` | OR (at least one is true) | `answer == "y" \|\| answer == "Y"` |
| `!` | NOT (flip it) | `!isWeekend` |

Text comparison counts capitals: `"Y" == "y"` is **false**.

### if / else if / else
```csharp
if (temperature <= 0)
{
    Console.WriteLine("Ice 🧊");
}
else if (temperature >= 100)
{
    Console.WriteLine("Steam ♨️");
}
else
{
    Console.WriteLine("Liquid water");
}
```
Checked **top to bottom**. The **first true one wins**, and the rest are skipped.

### Guard clause + early return
Check the bad cases **first**, and stop with `return;`. Then the rest of the code only deals with good input (the **happy path**).
```csharp
if (!int.TryParse(input, out int totalHours))
{
    Console.WriteLine("Please enter whole hours.");
    return;                 // stop the program here
}

if (totalHours < 0)
{
    Console.WriteLine("Hours can't be negative.");
    return;
}
```
`TryParse` returns a bool, so it goes straight into the `if`. `!` means "if it did NOT work".

### Scope: born inside `{ }`, dies at `}`
```csharp
if (true)
{
    string msg = "Hi";
}
Console.WriteLine(msg);    // ❌ CS0103: The name 'msg' does not exist
```
Fix: **declare the variable before the block**, and only change it inside.

### The "factory line": calculate once, adjust, print once
```csharp
decimal fee = totalHours * PerHourRate;        // 1. base fee

if (residentAnswer == "y" || residentAnswer == "Y")
{
    fee = fee * ResidentDiscount;              // 2. discount (0.5 = 50% off)
}

if (fee > MaxDailyFee)
{
    fee = MaxDailyFee;                         // 3. cap (maximum limit)
}

Console.WriteLine($"Fee: {fee:F3} KWD");      // 4. print once
```
- One variable, each `if` changes it, one print at the end, so **no repeated code**.
- A variable can change: `fee = fee * 0.5m` (no type the second time).
- 50% off = **× 0.5**. Multiplying by less than 1 makes it smaller.
- Discount first or cap first? That's a **business rule**. Ask the business, then write a comment.

🎬 **Animation idea:** a factory conveyor belt. A box labelled `fee` passes a "discount machine" (it shrinks only for residents), then a "cap machine" (it gets cut down if too tall), then the printer.

### Boundary testing
Always test the **edge numbers**: if the rule is "max 24 hours", test 23, **24** and 25. Most bugs live at the edges (`>` vs `>=`).

### Two habits
- **Save (Ctrl+S) before `dotnet run`**. Run only sees the saved file.
- **Shift+Alt+F** formats the file.

---

## 🎯 Dart comparison

Almost everything is **the same** as Dart: `if / else if / else`, `== != > < >= <=`, `&& || !`, `return;`, block scope.

| Small differences | Dart | C# |
|---|---|---|
| `if (x = 5)` | error | error too (CS0029, can't convert int to bool). C# protects you |
| Safe parse in an `if` | `final n = int.tryParse(s); if (n == null) return;` | `if (!int.TryParse(s, out int n)) { return; }` |

---

## 🐞 Errors I actually hit

| Mistake | What happened | Lesson |
|---|---|---|
| Forgot `return;` in a guard | Printed "Max 24 hours" **and then kept going** | Every guard ends with `return;` |
| `(int)PerHourRate` | `0.250` became `0`, so every fee was 0 | Money stays `decimal`, never cast to int |
| Used `TryParse` to check `y`/`n` | TryParse is only for numbers | Compare text with `==` |
| Created `fee` inside `if` and `else` | Had to write the math + print twice | Born outside, change inside |
| `fee * PerHourRate` again inside the print | Calculated twice | Once the box has a value, print the box |
| Discount `0.125` | Treated the discount as a new rate | A discount is a **multiplier** (× 0.5) |
| `isKuwaiti` held text | `is...` names are for bools only | `residentAnswer` |
| Ran before saving | Saw an old result | Ctrl+S first |
| Quiz: `else if (marks >= 90)` under `>= 50` | 95 printed "Pass" | Put the most specific check **first** |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| traffic light question | **condition** / **boolean expression** | "The condition is always false." |
| row of doors | **if-else chain**, evaluated **top to bottom** | "Put the most specific check first." |
| security guard | **guard clause** / **early return** | "Add a guard clause for negative hours." |
| good path after guards | **happy path** | "After the guards, the rest is the happy path." |
| room `{ }` | **code block** / **scope** | "`fee` is out of scope there." |
| edge number | **boundary value** | "Test the boundary values: 0, 24 and 25." |
| `>` instead of `>=` | **off-by-one error** | "Looks like an off-by-one at 24." |
| cap | **upper limit**; **clamping** | "Clamp the fee to MaxDailyFee." |
| same code twice | **duplication** → **DRY** | "Pull the print out of the if/else." |
| discount before cap | **business rule** | "Confirm the business rule with the product owner." |

---

## 📋 Summary

- `=` saves, `==` checks. `>` excludes the edge, `>=` includes it.
- `&&` both, `||` either, `!` not. Capitals count in text.
- if-else chains: top to bottom, first match wins
- Guard clause: check bad input first, then `return;`
- Scope: declare before the block, change inside
- Factory line: calculate once, adjust with `if`s, print once
- Test the boundary values

---

## 📝 Quiz

1. `int age = 18;` Is `age > 18` true or false?
2. What does this print for `marks = 95`, and how do you fix it?
   ```csharp
   if (marks >= 50) Console.WriteLine("Pass");
   else if (marks >= 90) Console.WriteLine("Excellent");
   ```
3. Why do guard clauses end with `return;`?
4. You need `total` after an `if` block, but you create it inside. What error do you get, and what's the fix?
5. What is `"Y" == "y"`?

<details>
<summary>Answers</summary>

1. False. `>` doesn't include the edge, and 18 is not greater than 18.
2. "Pass". The first true condition wins. Fix: check `>= 90` **first**.
3. To **stop** the program after the error message. Without it, the code keeps going with bad input.
4. CS0103 ("the name does not exist"). Declare `total` **before** the block and only change it inside.
5. `false`, because capital and small letters are different.

</details>
