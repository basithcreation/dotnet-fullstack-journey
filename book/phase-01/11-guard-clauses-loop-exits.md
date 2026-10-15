# Chapter 1.11: Remainder, OR, guard clauses and loop exits (Guessing Game v1.1)

> Learned: Thu 15 Oct 2026 · Code: `projects/01-number-guessing-game` (v1.1)

---

## 🧸 LKG story

**`%` is sharing sweets.** You have 7 sweets and 3 kids. Each kid gets 2, and **1 sweet is left over**. In C#, `7 / 3` is how many each kid gets (2), and `7 % 3` is **what is left over** (1).

🎬 **Animation idea:** pick how many sweets and how many kids with two sliders. The sweets drop one by one into the kids' bowls, round after round. The sweets that can't make a full round stay in the middle and glow: that's the remainder. Below, `sweets / kids` and `sweets % kids` light up with the two answers.

**Guard clauses are security guards at a door.** People queue to enter a party (the loop body). Guard 1 checks: *"Is this a number?"* If not, he sends that person away (`continue`), and the next person comes. Guard 2 checks: *"Is it between 1 and 100?"* Only the people who pass **every** guard get inside, where the real work happens (count the attempt, too high / too low). And one person can say *"I'm going home"* (`q`): they leave the **whole party** (`break`).

🎬 **Animation idea:** a game console where you type a guess (try `abc`, `500`, `q`, or a number). The guess walks along a corridor of guards. The guard that catches it lights up red and the guess turns back (`continue`), or the `q` guard opens the exit door (`break`). A guess that passes every guard reaches the counter (`attempts++`) and gets "Too high" or "Too low". When the game ends, a sign shows the **exit reason**: 🎉 won or 🚪 quit, and only "won" prints "Correct!".

---

## 💻 Real explanation

### 1. `%`: the remainder operator (modulo)

| Code | Means | Result |
|---|---|---|
| `7 / 3` | how many each kid gets (whole numbers) | `2` |
| `7 % 3` | how many are left over | `1` |
| `6 % 3` | shares out exactly | `0` |
| `10 % 4` | 10 sweets, 4 kids | `2` |
| `2 % 5` | nobody gets one, all 2 are left over | `2` |

The most common use: **"is it a multiple of…?"**

```csharp
if (n % 2 == 0) Console.WriteLine("even");
if (n % 3 == 0) Console.WriteLine("multiple of 3");
```

⚠️ The `%` in maths class (and the `%` button on Windows Calculator) means **percent**. In C#, `%` is **never** percent.

### 2. Tracing a loop where the update comes before `continue`

```csharp
int i = 0;
int sum = 0;

while (i < 7)
{
    i++;
    if (i % 3 == 0) continue;
    sum += i;
}

Console.WriteLine(sum);
```
```
19
```

| Check | `i` after `i++` | `i % 3` | `continue`? | `sum` |
|---|---|---|---|---|
| 0 < 7 ✅ | 1 | 1 | no | 1 |
| 1 < 7 ✅ | 2 | 2 | no | 3 |
| 2 < 7 ✅ | 3 | **0** | **yes** | 3 |
| 3 < 7 ✅ | 4 | 1 | no | 7 |
| 4 < 7 ✅ | 5 | 2 | no | 12 |
| 5 < 7 ✅ | 6 | **0** | **yes** | 12 |
| 6 < 7 ✅ | **7** | 1 | no | **19** |
| 7 < 7 ❌ | | | | stop |

Three rules for every row:
1. Work out `i % 3`. Is it `0`?
2. If yes → `continue` → `sum` **doesn't change**
3. If no → `sum = sum + i` (add `i`, not the remainder!)

The surprise is the last row: the condition checks `6 < 7`, **then** `i++` makes it 7, so 7 is still added. Check it a second way: 1 + 2 + 4 + 5 + 7 = 19 ✅.

### 3. `||` (OR) and `&&` (AND)

| `a` | `b` | `a \|\| b` | `a && b` |
|---|---|---|---|
| true | true | true | true |
| true | false | **true** | false |
| false | true | **true** | false |
| false | false | false | false |

- `||`: **one** true is enough
- `&&`: **both** must be true

```csharp
int temperature = 40;

if (temperature < 0 || temperature > 40)
    Console.WriteLine("Danger! Stay inside.");
else
    Console.WriteLine("Weather is OK.");
```
```
Weather is OK.
```

40 > 40 is **false**: `>` means *strictly* greater. Use `>=` if the edge should count.

Out of range vs in range are opposites:
- out: `guess < 1 || guess > 100`
- in: `guess >= 1 && guess <= 100`

### 4. Guard clauses with `continue`

Before (v1.0), the loop body was a **staircase**:

```csharp
while (guessNumber != secretNumber)
{
    string? input = Console.ReadLine();
    if (int.TryParse(input, out guessNumber))
    {
        numberOfAttempts++;
        // too high / too low ...
    }
    else
    {
        Console.WriteLine("That's not a number. Try again.");  // far away from its if
    }
}
```

After (v1.1), the **bad cases are thrown out first**, and the rest is flat:

```csharp
while (guessNumber != secretNumber)
{
    Console.Write("Your guess: ");
    string? input = Console.ReadLine();

    if (input == "q")
    {
        Console.WriteLine($"The number was {secretNumber}.");
        break;
    }

    if (!int.TryParse(input, out guessNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    if (guessNumber < 1 || guessNumber > 100)
    {
        Console.WriteLine("Please guess between 1 and 100.");
        continue;
    }

    numberOfAttempts++;
    if (guessNumber > secretNumber)
        Console.WriteLine("Too high!");
    else if (guessNumber < secretNumber)
        Console.WriteLine("Too low!");
}
```

The **order of the guards matters**:
1. `q` first. `q` is not a number, so if TryParse ran first it would say "not a number" and the game could never quit
2. Not a number
3. Out of range, **before** `numberOfAttempts++`, so `500` is not counted

A guard uses the **opposite** test of what you keep: we keep valid numbers, so the guard checks `!int.TryParse(...)`.

### 5. Comparing text with `==`

```csharp
if (input == "q") { ... }
```

- Text goes in **double quotes**. `'q'` (single quotes) is a `char`, a different type
- It's **case-sensitive**: `"Q" == "q"` is `false`

### 6. Two exits → check the exit reason

With a `break`, the loop can now end in **two** ways:

| Reason | How | `guessNumber == secretNumber` |
|---|---|---|
| won 🎉 | the `while` condition became false | true |
| quit 🚪 | `break` | false |

After the loop, the code doesn't know **why** the loop ended. So check first:

```csharp
if (guessNumber == secretNumber)
{
    if (numberOfAttempts == 1)
        Console.WriteLine("🎯 First try! Amazing!");
    else
        Console.WriteLine($"🎉 Correct! You got it in {numberOfAttempts} attempts.");
}
```

The output of every path:

```
Your guess: abc
That's not a number. Try again.
Your guess: 500
Please guess between 1 and 100.
Your guess: 50
Too low!
Your guess: q
The number was 63.
```

```
Your guess: 43
🎉 Correct! You got it in 6 attempts.
```

---

## 🎯 Dart comparison

All of this is the same in Dart: `%` is the remainder, `||` and `&&` work the same, `continue` and `break` work the same, and strings are compared with `==`.

```dart
// Dart
if (input == 'q') break;                 // Dart strings can use single quotes
final guess = int.tryParse(input ?? '');
if (guess == null) continue;             // Dart's tryParse returns null on failure
```
```csharp
// C#
if (input == "q") break;                 // C# strings need double quotes
if (!int.TryParse(input, out guessNumber)) continue;   // C#'s TryParse returns false
```

Two small differences: Dart has `~/` for whole-number division (C# just uses `/` with two `int`s), and in Dart `'q'` is a string, but in C# `'q'` is a `char`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Thought `7 % 3` meant divide, or percent | `%` means percent in maths class | `%` is the **remainder**: `7 % 3` = 1 |
| Added the remainder to `sum` instead of `i` | Mixed up the yes/no test with the work | The remainder is only for the question. `sum += i` adds `i` |
| Said the last row (`6 < 7`) doesn't run | Forgot that `i++` comes after the check | The check sees 6, the body works with 7 |
| Used `break` for the range check → "Correct! You got it in 0 attempts" | `break` leaves the **whole** loop | Use `continue` to ask again |
| Printed `{input}` in "The number was …" → `The number was q.` | `input` is what the player typed | Use `{secretNumber}` |
| Deleted `break` because of **CS0162 Unreachable code detected** | The warning pointed at lines after `break` | Keep `break`, **move** the lines that come after it |
| Moved the "Correct!" code inside the loop | "Inside vs outside" the loop | Code that runs **once at the end** goes after the loop's `}` |
| `Q` said "That's not a number" | String comparison is case-sensitive | Accept only `q` for now (or check both later) |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| sweets left over | **modulo** / **remainder operator** (`%`) | "Use `i % 2 == 0` to check if it's even." |
| one true is enough | **logical OR** (`\|\|`) | "Use `\|\|` to reject values outside the range." |
| both must be true | **logical AND** (`&&`) | "`x >= 1 && x <= 100` means it's in range." |
| the right side isn't checked if the left is true | **short-circuit evaluation** | "`\|\|` short-circuits." |
| staircase of `if`s | **deeply nested code** | "The nesting is too deep, can you flatten it?" |
| security guard | **guard clause** + **early `continue`** | "Add a guard clause for invalid input so the happy path stays flat." |
| lines after `break` | **unreachable code** / **dead code** (CS0162) | "The compiler flagged dead code after the `break`." |
| why did the loop stop? | **exit reason** | "The loop has two exits, so check the exit reason before printing the result." |
| `"Q"` ≠ `"q"` | **case-sensitive comparison** | "The quit check is case-sensitive." |

---

## 📋 Summary

- `%` gives the **remainder**: `x % n == 0` means x is a multiple of n
- `||`: one true is enough. `&&`: both must be true. `>` excludes the edge, `>=` includes it
- **Guard clauses** throw out bad input first with `continue`, so the loop body stays flat. The order of the guards matters
- Compare text with `==` and double quotes. It's case-sensitive
- A `break` gives the loop a second exit. After the loop, **check the exit reason** before printing a result
- CS0162 = unreachable code: the lines after a `break` (or `continue`, `return`) in the same block never run

---

## 📝 Quiz

1. What is `10 % 4`? And `9 % 3`?
2. Which of `5`, `0`, `100`, `101` make `age < 1 || age > 100` true?
3. In the game, why must the `q` check come **before** the TryParse check?
4. What does this print?
   ```csharp
   for (int i = 1; i <= 5; i++)
   {
       if (i == 4) break;
       if (i == 2) continue;
       Console.WriteLine(i);
   }
   Console.WriteLine("done");
   ```
5. After a loop that has a `break` inside, why can't we just print "Correct!"?

<details>
<summary>Answers</summary>

1. `2` (10 sweets, 4 kids, 2 left over) and `0`.
2. `0` and `101`. `1` to `100` are in range, so both sides are false.
3. `q` is not a number. If TryParse ran first, it would print "That's not a number" and `continue`, and the `q` check would never be reached.
4. `1`, `3`, `done`. 2 is skipped by `continue`, the loop stops at 4 with `break`, and `done` runs after the loop.
5. The loop can end in two ways: the player won, or the player quit with `break`. Check the **exit reason** first (`guessNumber == secretNumber`), otherwise quitting also prints "Correct!".

</details>
