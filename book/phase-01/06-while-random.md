# Chapter 1.6: while loops and Random

> Learned: Sun 11 Oct 2026 · Code: `lessons/phase-01/09-while-loop`, `10-random`, `11-rool-until-six`

---

## 🧸 LKG story

**A `while` loop is mom saying: "While the plate is not empty, keep eating."**

- You look at the plate. Food is still there? Take one bite.
- Look again. Still food? Another bite.
- Look again. Empty! **Stop**, and go play.

Mom checks **before every bite**. If the plate was already empty at the start, you eat **zero** bites.

And if you never actually take a bite, the plate never gets empty, and you sit there **forever**. That's an infinite loop.

**`Random` is a lucky-draw box** with balls numbered 1 to 6 inside. Close your eyes and pull one out: you can't know which number comes next. But you **do** know it's always between 1 and 6.

🎬 **Animation idea:** a plate with 3 cookies and a "check" light. Each round the light asks "bites > 0?", turns green, a bite disappears, and the counter goes down. At 0 the light turns red and the child runs off to play. A switch adds a stray `;` after the `while`: now the child just stares at the plate, the round counter spins faster and faster, and the screen says "the program hangs, press Ctrl+C".

---

## 💻 Real explanation

### 1. The `while` loop

A **`while` loop** repeats its body **as long as a condition is `true`**.

```csharp
while (condition)
{
    // body: runs again and again while the condition is true
}
```

- The condition is checked **before each round**. One round is called an **iteration**.
- When the condition becomes `false`, C# jumps past the `}` and continues with the next line.
- Something inside the body **must change** the condition. Otherwise the loop never stops: an **infinite loop**.

```csharp
int bites = 3;

while (bites > 0)
{
    Console.WriteLine($"Eating... {bites} bites left");
    bites--;   // bites = bites - 1
}

Console.WriteLine("Plate empty! Go play");
```

Output:
```
Eating... 3 bites left
Eating... 2 bites left
Eating... 1 bites left
Plate empty! Go play
```

### 2. Tracing a loop (dry run)

**Tracing** means following the code step by step on paper, like the computer does.

| Round | `bites` at the check | `bites > 0`? | Prints | `bites` after `bites--` |
|---|---|---|---|---|
| 1 | 3 | true | Eating... 3 bites left | 2 |
| 2 | 2 | true | Eating... 2 bites left | 1 |
| 3 | 1 | true | Eating... 1 bites left | 0 |
| 4 | 0 | **false** | nothing, the body is skipped | – |

"Eating... 0" never prints: when `bites` is 0, the check `0 > 0` is false, so the loop stops **before** the body runs. "Plate empty!" is **outside** the loop, so it prints exactly once.

### 3. Zero iterations

```csharp
int bites = 0;
while (bites > 0) { ... }        // the first check is 0 > 0 → false
```
Output: only `Plate empty! Go play`.

> A `while` loop checks **first**. If the condition is false at the start, the body runs **zero times**.

### 4. `Random`: random numbers

```csharp
int dice = Random.Shared.Next(1, 7);   // 1, 2, 3, 4, 5 or 6
```

| Part | Meaning |
|---|---|
| `Random` | a **class** in .NET that makes random numbers |
| `Random.Shared` | a ready-made generator that .NET gives you (no need to create one) |
| `.Next(min, max)` | a **method** that returns a random `int` |
| `min` | **included** (inclusive lower bound) |
| `max` | **excluded** (exclusive upper bound) |

⚠️ `Next(1, 7)` gives 1 to **6**, never 7. For 1 to 100, write `Next(1, 101)`.
🧠 Memory trick: **"the max is the door, you stop before the door."** 🚪

The output is **non-deterministic**: it changes every run. But you can still predict the **shape** of the output:

```csharp
int rolls = 1;
while (rolls <= 3)
{
    int dice = Random.Shared.Next(1, 7);
    Console.WriteLine($"Roll {rolls}: you got {dice}");
    rolls++;
}
```
Three real runs:
```
Roll 1: you got 1      Roll 1: you got 4      Roll 1: you got 1
Roll 2: you got 5      Roll 2: you got 6      Roll 2: you got 6
Roll 3: you got 5      Roll 3: you got 4      Roll 3: you got 5
```
What is always true: exactly 3 lines, labels 1-2-3, every number between 1 and 6, and repeats are possible (5, 5).

### 5. Loop **until** something happens (sentinel loop)

Sometimes you don't know how many rounds you need. You keep going **until** something happens.

```csharp
string? answer = "";                      // 1. declare BEFORE the loop, with a starting value

while (answer != "yes")                   // 2. keep going while it's NOT what we want
{
    Console.Write("Are you ready? (yes/no): ");
    answer = Console.ReadLine();          // 3. update INSIDE the loop
}

Console.WriteLine("Let's go");
```
```
Are you ready? (yes/no): no
Are you ready? (yes/no): Yes
Are you ready? (yes/no): YES
Are you ready? (yes/no): yes
Let's go
```
`"YES" != "yes"` is true, because string comparison is **case-sensitive**, so the loop runs again.

Three rules:
1. **Declare before the loop.** The condition is outside the `{ }`, so it can only see variables declared outside (**scope**).
2. **The starting value must make the condition true**, so the loop runs at least once.
3. **Update inside the loop**, or it's an infinite loop.

### 6. Full example: Roll Until Six

```csharp
int rolls = 0;     // zero rolls before we start
int dice = 7;      // not 6, so the loop runs at least once (a real dice never gives 7)

while (dice != 6)
{
    rolls++;                               // count first...
    dice = Random.Shared.Next(1, 7);       // no "int" here: dice is already declared
    Console.WriteLine($"Roll {rolls}: {dice}");   // ...then print
}

if (rolls == 1)
{
    Console.WriteLine("Lucky! First try!");
}
else
{
    Console.WriteLine($"🎉 Got a 6 after {rolls} rolls!");
}
```
```
Roll 1: 5
Roll 2: 3
Roll 3: 1
Roll 4: 3
Roll 5: 5
Roll 6: 4
Roll 7: 1
Roll 8: 6
🎉 Got a 6 after 8 rolls!
```
And once, with no tricks at all:
```
Roll 1: 6
Lucky! First try!
```

**Testing a random program:** a first-try 6 only happens about 1 time in 6. To test that branch on purpose, **temporarily hard-code** the value: `Random.Shared.Next(6, 7)` always gives 6. Test, then **revert** it.

🎬 **Animation idea:** a dice table with a roll button and a tally board. A switch moves `rolls++` to **after** the print: now the labels start at "Roll 0" or the final total is one too high, and a red arrow points at the mismatch between the last roll label and the 🎉 number. Move it back, and the two numbers line up with a green tick. A "force a 6" button shows the hard-code testing trick.

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| `while` loop | `while (i <= 3) { ... }` | **exactly the same** |
| Stray `;` after `while (...)` | empty loop body too | empty loop body + warning **CS0642** |
| Random number | `import 'dart:math';` then `Random().nextInt(6) + 1` | `Random.Shared.Next(1, 7)`, no import, no `+1` |
| Max excluded? | yes, `nextInt(6)` gives 0–5 | yes, `Next(1, 7)` gives 1–6 |
| String compare | case-sensitive | case-sensitive |

```dart
// Dart
import 'dart:math';
int dice = Random().nextInt(6) + 1;   // 1..6
```
```csharp
// C#
int dice = Random.Shared.Next(1, 7);  // 1..6
```

---

## 🐞 Errors I actually hit

| Error / mistake | Why | Fix |
|---|---|---|
| **CS0117** "'Console' does not contain a definition for 'Writeline'" | C# is **case-sensitive**: `Writeline` ≠ `WriteLine` | Capital **L**: `WriteLine` |
| **CS0642** "Possible mistaken empty statement", then the program **hung** | `while (bites > 0) ;` The `;` became the loop body (do nothing), so `bites` never changed → **infinite loop** | Never put `;` after `while (...)`, `if (...)`, `switch (...)`. Press **Ctrl+C** to stop a hung program |
| Same CS0642, now at `(4,5)` | **Moved** the `;` to the next line instead of deleting it. C# ignores lines and spaces | **Delete** it, so `{` comes right after `)` |
| Edited but ran the old code | Didn't save (white dot ● on the tab) | **Ctrl+S** before `dotnet run` |
| Loop ran exactly 5 times, not "until a 6" | `while (rolls <= 5)`: the loop was controlled by the counter, not the dice | `while (dice != 6)` |
| `dice` declared inside the loop | The `while (...)` check is outside the `{ }`, so it can't see it (it would be **CS0103**) | Declare `dice` **before** the loop; inside, write `dice = ...` without `int` |
| `"Got a {}"` printed literally | No `$` and no variable inside `{ }` | `$"Got a 6 after {rolls} rolls!"` |
| **Off-by-one**: 2 rolls but "after 3 rolls" (or labels starting at "Roll 0") | `rolls++` ran **after** the print | Start at `rolls = 0` and **increment before** the print |
| Quiz: thought `x = 5; while (x < 3)` prints 4, 5 | Forgot the **first check**: `5 < 3` is false | Zero iterations: only the line after the loop prints |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| merry-go-round | **loop** | "Wrap that in a loop instead of copying it 3 times." |
| one round | **iteration** | "On the third iteration, `bites` is 1." |
| the check at the top | **loop condition** | "The loop condition is never false, so it hangs." |
| the code inside `{ }` | **loop body** | "Move `rolls++` to the top of the loop body." |
| never stops | **infinite loop**; the app **hangs** | "The app hung because of an infinite loop." |
| the lonely `;` | **empty statement** / **stray semicolon** | "There's a stray semicolon after the `while`." |
| body never runs | **zero iterations** | "If the list is empty, the loop runs zero iterations." |
| loop until "yes" | **sentinel loop** / loop until a condition is met | "Use a sentinel loop until the user types yes." |
| the variable the loop checks | **loop control variable** | "`dice` is the loop control variable." |
| add 1 / take away 1 | **increment** `++` / **decrement** `--` | "Increment the counter before you print it." |
| counter one too big | **off-by-one error** | "It's an off-by-one error: I incremented after printing." |
| lucky-draw box | **random number generator** (`Random`) | "Use `Random.Shared`, don't create a new `Random` each time." |
| `min` / `max` of `Next` | **inclusive lower bound** / **exclusive upper bound** | "`Next(1, 101)` returns 1 to 100, the upper bound is exclusive." |
| different every run | **non-deterministic** | "Random output is non-deterministic, so test the range, not the exact value." |
| capitals count | **case-sensitive** | "String comparison is case-sensitive by default." |
| force the dice to 6 | **hard-code** a value to test an **edge case**, then **revert** | "I hard-coded 6 to test the first-try branch." |
| follow the code on paper | **tracing** / **dry run** | "Let's trace the loop with `bites = 3`." |

---

## 📋 Summary

- `while (condition) { body }`: the condition is checked **before** every iteration
- If it's false at the start, the body runs **zero** times
- Something in the body **must** change the condition, or you get an **infinite loop** (Ctrl+C to stop)
- **Never** put `;` right after `while (...)` (CS0642)
- `Random.Shared.Next(min, max)`: `min` included, `max` **excluded**
- Sentinel loop: declare **before** the loop, a starting value that makes the condition **true**, update **inside**
- Counters: **increment before** you use the value, or you get an **off-by-one** error
- Test random code by **hard-coding** the value for a moment, then revert

---

## 📝 Quiz

1. What does this print? Why?
   ```csharp
   int x = 5;
   while (x < 3) { Console.WriteLine(x); x++; }
   Console.WriteLine("End");
   ```
2. You want a random number from 1 to 10. `Next(1, 10)` or `Next(1, 11)`? What's wrong with the other one?
3. This program hangs. What's the bug, and what's its real name?
   ```csharp
   int count = 1;
   while (count <= 3) { Console.WriteLine(count); }
   ```
4. What's wrong here, and which build error do you expect?
   ```csharp
   while (dice != 6) { int dice = Random.Shared.Next(1, 7); }
   ```
5. Your counter said "3 rolls" when there were only 2. Explain it to your team lead in one sentence.

<details>
<summary>Answers</summary>

1. Only `End`. The first check is `5 < 3` → false, so the body runs **zero** times.
2. `Next(1, 11)`. The max is **exclusive**, so `Next(1, 10)` only gives 1 to 9.
3. `count` never changes (no `count++`), so `1 <= 3` is true forever: an **infinite loop**.
4. `dice` is declared **inside** the loop, but the `while (dice != 6)` check is **outside** the `{ }`. It's out of scope: **CS0103** "The name 'dice' does not exist in the current context". Declare it before the loop.
5. "It was an **off-by-one error**: I incremented the counter after printing, so the total was one too high. I fixed it by incrementing before the print."

</details>
