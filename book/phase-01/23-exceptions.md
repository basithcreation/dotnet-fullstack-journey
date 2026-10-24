# Chapter 1.23: Exceptions (`try`, `catch`, `finally`, `throw`)

> Learned: Sat 24 Oct 2026 · Code: `lessons/phase-01/33-try-catch`

---

## 🧸 LKG story

**The driver with a backup plan.** A driver tries to deliver a parcel, but the door is locked. A bad driver panics and **quits the whole route**. A good driver has a backup plan: "If the door is locked, leave a note and go to the next house."

- `try` = try to deliver
- `catch` = if something goes wrong, do the backup plan
- `finally` = whatever happens, **always** return the van keys at the end
- `throw` = the driver **raises a hand**: "I can't deliver this one, the address is wrong. STOP!"

🎬 **Animation idea:** a code block with a `try`, two `catch` blocks and a `finally`. Pick an input (a good number, `"abc"`, a bad index) and press Step. A cursor walks line by line; when an exception happens it **jumps** over the rest of the `try`, checks each `catch` from top to bottom, enters the first one that matches, then always visits `finally`.

---

## 💻 Real explanation

An **exception** is an error that happens while the program is **running** (at **runtime**), not when it compiles. If nobody catches it, the program **crashes**:

```csharp
int x = int.Parse("abc");
```
```
Unhandled exception. System.FormatException: The input string 'abc' was not in a correct format.
```

`int.TryParse` avoids this for numbers. But many things have no Try version (files, servers, databases). For those we use `try` / `catch`.

### 1. `try` / `catch`

```csharp
Console.WriteLine("Start");
try
{
    int boxes = int.Parse("abc");
    Console.WriteLine($"Boxes: {boxes}");
}
catch (FormatException)
{
    Console.WriteLine("That is not a number");
}
Console.WriteLine("End");
```
```
Start
That is not a number
End
```

🔑 When an exception happens inside `try`, C# **jumps straight to `catch`**. The rest of the `try` is **skipped**, so `Boxes:` never prints. After the `catch`, the program carries on (`End`).

### 2. Several `catch` blocks, `Exception ex` and `finally`

```csharp
int[] shelves = { 10, 20, 30 };
try
{
    Console.WriteLine(shelves[5]);
    Console.WriteLine("Found it");
}
catch (FormatException)
{
    Console.WriteLine("Bad number");
}
catch (Exception ex)
{
    Console.WriteLine($"Problem: {ex.Message}");
}
finally
{
    Console.WriteLine("Shelf check done");
}
```
```
Problem: Index was outside the bounds of the array.
Shelf check done
```

- There are many kinds of exception: `FormatException`, `IndexOutOfRangeException`, `NullReferenceException`, `DivideByZeroException`, ...
- `Exception` is the **parent** of all of them, so `catch (Exception ex)` catches **any** exception
- `ex` holds the details. `ex.Message` is the human sentence
- C# checks the `catch` blocks **top to bottom** and runs only the **first** that matches. So: **specific first, `Exception` last**. The other order doesn't even compile:
  `error CS0160: A previous catch clause already catches all exceptions of this or of a super type ('Exception')`
- `finally` runs **always**, with or without an exception. Real apps close files and database connections there

### 3. `throw`: raise your own exception

C# thinks `-3` is a fine number. But a parcel can't weigh -3 kg. Only **you** know that rule, so you **throw**:

```csharp
try
{
    Console.WriteLine(GetFee(2));
    Console.WriteLine(GetFee(-3));
    Console.WriteLine(GetFee(5));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

static double GetFee(double kg)
{
    if (kg <= 0)
    {
        throw new ArgumentException("Weight must be more than 0");
    }
    return kg * 1.5;
}
```
```
3
Error: Weight must be more than 0
```

- `throw` stops the method right there (like `return`) and sends the problem up to the caller
- `new ArgumentException("...")` creates the exception. `ArgumentException` means "the value you passed me is bad"
- `GetFee(5)` never runs: the jump to `catch` skipped it

**Why not `return 0;`?** Because `0` looks like a **real** fee. The program carries on with 0 KD, nobody notices, and the company loses money: a **hidden bug**. `throw` makes the problem loud and stops it early. Team phrase: **fail fast**.

### 4. `ex` vs `ex.Message`

```csharp
Console.WriteLine($"Error: {ex}");          // type + message + stack trace
Console.WriteLine($"Error: {ex.Message}");  // only the message
```
```
Error: System.ArgumentException: Need at least 1 driver
   at Program.<<Main>$>g__BoxesPerDriver|0_0(Int32 boxes, Int32 drivers) in ...\Program.cs:line 87
   at Program.<Main>$(String[] args) in ...\Program.cs:line 65
Error: Need at least 1 driver
```

The "at ... line 87" part is the **stack trace**: the list of methods the program was in, with line numbers (read it bottom to top). It's gold for developers, but never show it to users: it's ugly and it leaks your file paths. **Log the full exception, show the user only the message.**

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `try { } on FormatException { }` | `try { } catch (FormatException) { }` |
| `catch (e) { print(e); }` | `catch (Exception ex) { Console.WriteLine(ex.Message); }` |
| `finally { }` | `finally { }` |
| `throw ArgumentError('...');` | `throw new ArgumentException("...");` (with `new`) |
| `FormatException` from `int.parse` | `FormatException` from `int.Parse` |

The structure is the same. Dart uses `on Type`, C# uses `catch (Type)`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Guessed only `That is not a number` | Forgot the lines outside `try` | Predict **every** line: `Start`, ..., `End` |
| Guessed `Weight must be more then 0` | Missed the `Error: ` part | Predict the whole line |
| Typed `more then 0` | `then` (next) vs `than` (comparing) | `more than 0`. Users read error messages |
| Printed `{ex}` → a stack trace on screen | `ex` is the whole object | `{ex.Message}`. Found it myself in test run 3 |
| Named the result `totalBoxesAssigned` | It holds one driver's boxes, not the total | Names must say what's inside: `boxesEach` |
| Quiz: "`throw` is better than `return 0` because of the message" | Missed the main reason | `0` looks like a real answer → hidden bug. **Fail fast** |

✅ Wins: understood "the rest of the `try` is skipped" straight away; explained why the 2nd `catch` ran; `drivers <= 0` blocks negative numbers too; tested all 3 paths; quiz 4.5/5.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| a problem while running | **exception** (a **runtime** error) | "`int.Parse` throws a `FormatException` on bad input." |
| the backup plan | **catch** / **handle** an exception | "We handle that exception, so the app doesn't crash." |
| the crash | **unhandled exception** | "It crashed with an unhandled exception." |
| always return the keys | **`finally`** block | "Put the cleanup in a `finally` block." |
| the parent of all problems | **base class `Exception`** | "Catch the specific exception first, `Exception` last." |
| raise a hand | **throw** an exception | "The method throws an `ArgumentException` on invalid input." |
| check the input first | **validate** the input | "Validate the weight and fail fast." |
| stop early, loudly | **fail fast** | "Don't return 0, fail fast so the bug can't hide." |
| the "at ... line" list | **stack trace** | "Log the stack trace, show the user only the message." |

---

## 📋 Summary

| Keyword | Runs when | Remember |
|---|---|---|
| `try` | always (until an exception) | the rest of `try` is skipped after an exception |
| `catch (SomeException)` | the exception matches | checked top to bottom; specific first, `Exception` last (CS0160) |
| `catch (Exception ex)` | any exception | `ex.Message` = the human sentence |
| `finally` | always | cleanup |
| `throw new ArgumentException("...")` | you decide the input is bad | stops the method like `return` |

---

## 📝 Quiz

1. What's the output?
   ```csharp
   try { Console.WriteLine("A"); int n = int.Parse("x"); Console.WriteLine("B"); }
   catch (FormatException) { Console.WriteLine("C"); }
   Console.WriteLine("D");
   ```
2. What's wrong with putting `catch (Exception ex)` **before** `catch (FormatException)`?
3. No exception happens. Does `finally` run?
4. A method gets `kg = -5`. Why is `throw new ArgumentException(...)` better than `return 0;`?
5. Which property gives only the friendly text, without the stack trace: `ex.___`?

<details>
<summary>Answers</summary>

1. `A`, `C`, `D` (each on its own line). `B` is skipped.
2. `Exception` catches everything, so the `FormatException` block could never run. C# refuses to compile it: CS0160.
3. Yes, `finally` always runs.
4. `0` looks like a real fee, so the bug hides and the program carries on with a wrong value. `throw` makes the problem loud and stops it early (fail fast).
5. `ex.Message`

</details>
