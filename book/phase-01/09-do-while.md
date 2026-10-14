# Chapter 1.9: do-while, the loop that runs at least once

> Learned: Wed 14 Oct 2026 · Code: `lessons/phase-01/15-do-while`, `16-times-table-v2`

---

## 🧸 LKG story

**The restaurant waiter.**

At a restaurant, the waiter **serves your first plate**, and only **then** asks: *"Do you want more?"*

- Yes → another plate, then he asks again
- No → he stops

You always get **at least one plate**, because the question comes **after** the food.

A `while` loop is a different waiter. He stands at the **door** and asks *"Do you want food?"* before you even sit down. If you say no, you get **zero** plates.

🎬 **Animation idea:** two waiters side by side. The "while" waiter stands at the door with a question bubble *before* the table, and the "do-while" waiter carries a plate straight to the table and asks *after* it lands. A switch sets the answer to "no" from the start: the while table stays empty (0 plates), the do-while table gets exactly 1 plate. A counter under each table shows how many times the body ran.

---

## 💻 Real explanation

### 1. The shape

```csharp
do
{
    // body
} while (condition);   // ← this semicolon is REQUIRED
```

- The **body runs first**, and the **condition is checked at the bottom**.
- So the body always runs **at least once**.
- `while` is a **pre-test loop**: it checks first, so it can run **0** times.
- `do-while` is a **post-test loop**: it checks after, so it runs **1 or more** times.

⚠️ The `;` after `while (...)`:
- In a `do-while`, it's **required**. That line is the **end** of the loop.
- In a normal `while`, a `;` after `while (...)` is the **CS0642** bug: it becomes an empty loop body (Chapter 1.6).

### 2. while vs do-while, side by side

```csharp
int x = 10;

while (x < 5)
{
    Console.WriteLine("while ran");
}

do
{
    Console.WriteLine("do-while ran");
} while (x < 5);

Console.WriteLine("end");
```
```
do-while ran
end
```

`10 < 5` is false both times. The `while` checks **before** the body, so the body never runs. The `do-while` runs the body, **then** checks, then stops.

**Which one to pick:**

| Can the loop need to run **zero** times? | Use | Example |
|---|---|---|
| Yes (e.g. a list of orders that might be empty) | `while` | Print today's orders: no orders → print nothing |
| No, it must run at least once | `do-while` | Show a menu; ask the user for input |

### 3. The scope trap: declare before `do`

The condition sits **outside** the `{ }`, after the closing brace. A variable born **inside** the braces dies at the `}`, so the condition can't see it:

```csharp
do
{
    Console.Write("Type yes: ");
    string? answer = Console.ReadLine();   // born inside { }
} while (answer != "yes");                 // ❌ CS0103: The name 'answer' does not exist
```

**Fix:** **declare** the variable **before** the `do`, and only **assign** it inside:

```csharp
string? answer;                    // declared outside
do
{
    Console.Write("Type yes: ");
    answer = Console.ReadLine();   // assigned inside (no "string?" here)
} while (answer != "yes");         // ✅ can see it
Console.WriteLine("Thanks!");
```
```
Type yes: no
Type yes: no
Type yes: yes
Thanks!
```

Two words that sound alike:
- **declare** = create the box: `string? answer;`
- **initialize** = give the box its **first** value: `string? answer = "";`

### 4. No more dummy values

In the PIN lock (`12-pin-lock`), the `while` version needed a fake starting value:

```csharp
int pin = 0;                  // 0 is a dummy, only there so the first check can run
while (pin != correctPin) { ... }
```

With `do-while`, the body runs first and gives the variable a **real** value **before** the first check. No dummy needed.

### 5. A `bool` flag

`int.TryParse` **returns** `true` or `false`. You can save that answer in a `bool` variable and use it later:

```csharp
bool isAdult = age >= 18;                       // true or false, saved
bool ok = int.TryParse("abc", out int value);   // ok = false
```

A `bool` variable that remembers yes/no is called a **flag**.

**Name the flag honestly.** Its name must say what `true` means:
- ✅ `ok = int.TryParse(...)` → `true` means "the input is OK"
- ❌ `ok = !int.TryParse(...)` → `true` means "the input is **bad**", but the name says "ok". Anyone reading `if (ok)` will think of the good case.

And `if (ok == true)` is the same as `if (ok)`. The `== true` adds nothing.

### 6. Full example: Times Table v2 (ask until valid)

Version 1 (Chapter 1.8) **quit** on bad input with `return;`. Version 2 **asks again** until it gets a number:

```csharp
string? input;
int number;
bool ok;

do
{
    Console.Write("Which times table? ");
    input = Console.ReadLine();
    ok = int.TryParse(input, out number);
    if (!ok)
    {
        Console.WriteLine("That's not a number.");
    }
} while (!ok);

int sum = 0;
for (int i = 1; i <= 10; i++)
{
    int answer = number * i;
    Console.WriteLine($"{number} x {i} = {answer}");
    sum += answer;
}
Console.WriteLine($"Sum of all answers: {sum}");
```
```
Which times table? abc
That's not a number.
Which times table? hi
That's not a number.
Which times table? 7
7 x 1 = 7
7 x 2 = 14
...
7 x 10 = 70
Sum of all answers: 385
```

Read the loop out loud: *"save whether it's ok; if not ok, complain; keep asking while not ok."*

Notes:
- `int number;` has **no** `= 0`. `out number` gives it a real value.
- `out number`, not `out int number`: `number` is already declared above, so we don't declare it again.
- TryParse is called **once** per iteration. The flag remembers the result, so the `if` and the `while` don't call it again.

🎬 **Animation idea:** a door with a keypad. The student types anything into a text box and presses Enter. A small "ok" light shows the flag: green for a number, red otherwise. On red, a speech bubble says "That's not a number." and the arrow loops back up to "Which times table?". On green, the arrow goes down past `while (!ok)` and the first rows of the times table print.

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| do-while | `do { ... } while (x < 5);` | **exactly the same** |
| `;` at the end | required | required |
| Variable in the condition | must be declared before `do` | must be declared before `do` (**CS0103** otherwise) |
| Parse a number | `int? n = int.tryParse(input);` → `null` if bad | `bool ok = int.TryParse(input, out int n);` → `false` if bad |

```dart
// Dart
int? number;
do {
  stdout.write('Which times table? ');
  number = int.tryParse(stdin.readLineSync() ?? '');
  if (number == null) print("That's not a number.");
} while (number == null);
```

Dart's `tryParse` returns **null** for bad input. C#'s `TryParse` returns a **bool** and puts the number in the `out` variable.

---

## 🐞 Errors I actually hit

| Error / mistake | Why | Fix |
|---|---|---|
| Output was only `end` (no "do-while ran") | Typed `while (x < 5)` at the **start** of the second loop instead of `do`, so it was a pre-test loop | A do-while **starts with `do`** |
| **CS0103** "The name 'answer' does not exist in the current context" at `(19,10)` | `answer` was declared **inside** the `{ }`, and the `while (...)` line is outside | Declare before `do`, assign inside. `(19,10)` = line 19, column 10 |
| `using System.Formats.Asn1;` appeared at the top | Accepted an auto-complete suggestion by mistake | Delete unused `using` lines |
| "That's not a number." printed **once, after** the valid number | I put `{ Console.WriteLine(...); }` **after** `} while (...);`. The `;` ends the loop, so that `{ }` was a **standalone block** that ran once at the end | Everything that repeats goes **between `do {` and `}`**. Nothing comes after `while (...);` |
| `ok = number;` | `ok` is a `bool`, `number` is an `int`. You can't put a number in a yes/no box (it would be **CS0029**) | `ok = int.TryParse(input, out number);` |
| `ok = !int.TryParse(...)` + `if (ok == true)` + TryParse again in the `while` | It worked, but the flag's name lied, `== true` was extra, and TryParse ran twice | `ok = int.TryParse(...)`, `if (!ok)`, `while (!ok)` |
| Quiz: called "declare it at the top" "initialize it" | Declare = create the box; initialize = first value | Declare before `do`, assign inside |
| Quiz: said `while (x < 5);` before a `{ }` is an error | It's a **warning** (CS0642), and it compiles | False → the `{ }` runs once on its own; true → infinite loop, the app hangs |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| serve first, ask after | **`do-while` loop** | "Use a do-while here, because we have to ask the user at least once." |
| check first | **pre-test loop** (`while`, `for`) | "A while is pre-test, so it can run zero times." |
| check after | **post-test loop** (`do-while`) | "A do-while is post-test, so the body runs at least once." |
| create the box | **declare** a variable | "Declare `cmd` before the `do` so the condition can see it." |
| give the first value | **initialize** a variable | "You don't need to initialize it, `out` assigns it." |
| fake starting value | **dummy value** / **placeholder value** | "With a do-while you don't need a dummy value." |
| a yes/no box | **flag** (a `bool` variable) | "Store the TryParse result in a flag, then use it in the loop condition." |
| ask until the input is good | **input validation loop** (the "ask until valid" pattern) | "Wrap the prompt in a do-while validation loop." |
| `{ }` not attached to anything | **standalone block** | "That's a standalone block, it's not part of the loop." |
| a `using` line nobody needs | **unused using directive** | "Remove the unused using, the analyzer flags it." |

---

## 📋 Summary

- `do { body } while (condition);`: the body runs first, the check is at the bottom
- Runs **at least once** (post-test). A `while` can run **zero** times (pre-test)
- The `;` at the end is **required**
- Variables used in the condition must be **declared before `do`**, otherwise **CS0103**
- Nothing that should repeat goes after `while (...);`
- **Flag:** `bool ok = int.TryParse(...)`. Name it after what `true` means. Use `if (!ok)`, not `if (ok == false)`
- Use `do-while` for "ask until valid" and menus. Use `while` when zero runs is possible

---

## 📝 Quiz

1. How many times does the body run, and what does it print?
   ```csharp
   int n = 5;
   do
   {
       Console.WriteLine(n);
       n++;
   } while (n < 3);
   ```
2. What does this print?
   ```csharp
   int k = 1;
   do
   {
       k *= 2;
   } while (k < 10);
   Console.WriteLine(k);
   ```
3. This doesn't compile. Give the error code and the fix.
   ```csharp
   do
   {
       Console.Write("Command: ");
       string? cmd = Console.ReadLine();
   } while (cmd != "exit");
   ```
4. `while` or `do-while`? (a) Show a menu until the user picks "Quit". (b) Print every order in a list that might be empty.
5. What's the difference between `} while (x < 5);` at the end of a do-while and `while (x < 5);` at the start of a normal while?

<details>
<summary>Answers</summary>

1. **Once**. It prints `5`. The body runs first, then `6 < 3` is false.
2. `16`. k goes 2 (true), 4 (true), 8 (true), 16 (false → stop). The loop stops only **after** k passes the limit, because the check is at the bottom.
3. **CS0103**: `cmd` is declared inside the `{ }`, so the `while` line can't see it. Declare `string? cmd;` before `do`, and write `cmd = Console.ReadLine();` inside.
4. (a) `do-while`: the menu must show at least once. (b) `while`: with zero orders it must print nothing. A do-while would try to print an order before checking.
5. In a do-while, that line **ends** the loop and the `;` is required. In a normal while, the `;` becomes an empty body (warning **CS0642**): if the condition is false, the `{ }` below runs once on its own; if it's true, it's an infinite loop and the app hangs.

</details>
