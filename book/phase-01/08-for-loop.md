# Chapter 1.8: The for loop

> Learned: Tue 13 Oct 2026 · Code: `lessons/phase-01/13-for-loop`, `14-times-table`

---

## 🧸 LKG story

**The teacher says: "Run around the playground 5 times."**

You count on your fingers:

1. **Start:** one finger up. You do this **once**, before the first lap.
2. **Check:** "Is my count 5 or less?" Yes → run a lap.
3. **After each lap:** put up one more finger.
4. Check again… When the check says **no**, you stop.

A `while` loop is "keep going **until something happens**". You don't know how many rounds it will take (like guessing a secret number).
A `for` loop is "do it **this many times**". You **know the count** before you start.

**The piggy bank:** to add up all your pocket money, you need **one** piggy bank that sits on the shelf for the whole week. If you buy a **new, empty** piggy bank every day, you'll never save anything. The piggy bank must be ready **before** the week starts.

🎬 **Animation idea:** a running track with a lap counter and three dials: Start, Check and Step. Press "Next step" and the matching part of the `for` line lights up in order: start (only once), check, body (the runner does a lap and the number prints), step, check… A check counter shows that the condition is checked one time more than the body runs. Changing `<=` to `<` shows an off-by-one: one lap goes missing.

---

## 💻 Real explanation

### 1. The `for` loop

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Lap {i}");
}
```

The `( )` holds **3 parts**, separated by `;`:

| Part | Code | When it runs | Real term |
|---|---|---|---|
| ① Start | `int i = 1` | **once**, before everything | **initializer** |
| ② Check | `i <= 5` | **before every** iteration | **condition** |
| ③ Step | `i++` | **after every** iteration | **iterator** |

**The order:** ① → ② → body → ③ → ② → body → ③ → ② … until ② is `false`.

`i` is the **loop counter** (or **loop variable**). By habit it's called `i` (for "index").

⚠️ Two words that look alike:
- **iteration** = **one trip** around the loop
- **iterator** = the **step part** (`i++`)

### 2. A `for` is a `while` with everything on one line

These two do exactly the same thing:

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Lap {i}");
}
```

```csharp
int i = 1;               // ① initializer
while (i <= 5)           // ② condition
{
    Console.WriteLine($"Lap {i}");
    i++;                 // ③ iterator
}
```

`for` keeps the 3 counter parts **together**, so it's harder to forget `i++` (in a `while`, forgetting it means an **infinite loop**).

**When to use which:**

| You know the count before you start? | Use | Example I built |
|---|---|---|
| Yes ("10 rows", "5 laps") | `for` | Times Table |
| No ("until the guess is right") | `while` | Number Guessing Game |

### 3. Counting down and other steps

The iterator doesn't have to be `i++`:

```csharp
for (int i = 5; i >= 1; i--)
{
    Console.WriteLine(i);
}
Console.WriteLine("🚀 Liftoff!");
```
```
5
4
3
2
1
🚀 Liftoff!
```

```csharp
for (int i = 2; i <= 10; i += 3)
{
    Console.Write($"{i} ");
}
```
```
2 5 8
```

### 4. Tracing: the body runs **before** the iterator

The **first** time the body runs, `i` still has its **initializer** value. That's why the code above prints **2** first, not 5.

| `i` at the check | `i <= 10`? | Prints | `i` after `i += 3` |
|---|---|---|---|
| 2 | true | `2` | 5 |
| 5 | true | `5` | 8 |
| 8 | true | `8` | 11 |
| 11 | **false** | nothing, the loop exits | – |

Count the checks: the body ran **3** times, and the condition was checked **4** times.

> A loop with **N** iterations checks its condition **N + 1** times. The extra check is the `false` one that ends the loop.

**The most common style** starts at **0** and uses `<`:

```csharp
for (int i = 0; i < 3; i++)   // i = 0, 1, 2 → runs 3 times
{
    Console.WriteLine("Hi");
}
```

You'll see this one everywhere once we reach arrays (they start counting at 0).

### 5. Off-by-one: `<` vs `<=`

```csharp
for (int i = 10; i > 4; i -= 2)  { Console.Write($"{i} "); }   // 10 8 6
for (int i = 10; i >= 4; i -= 2) { Console.Write($"{i} "); }   // 10 8 6 4
```

`4 > 4` is **false**, so 4 is **not** printed. `4 >= 4` is **true**, so it is.
A loop that runs **one time too many or too few** has an **off-by-one error**. `<` vs `<=` (or `>` vs `>=`) decides it.

### 6. Scope: `i` dies at the `}`

```csharp
for (int i = 1; i <= 3; i++)
{
    Console.WriteLine(i);
}
Console.WriteLine(i);   // ❌ CS0103: The name 'i' does not exist in the current context
```

A variable lives only inside the `{ }` (or the `for ( )`) where it was **declared**. That's its **scope**.

### 7. The accumulator: adding things up

To add things up in a loop, you need a variable that is **declared before** the loop and **updated inside** it.

```csharp
int total = 0;             // the piggy bank: declared BEFORE the loop

for (int i = 1; i <= 4; i++)
{
    total += i;            // same as: total = total + i
}

Console.WriteLine($"Total: {total}");
```
```
Total: 10
```

Trace it as **old total + i**. Each row starts from the row above:

| `i` | `total` before | `total + i` | `total` after |
|---|---|---|---|
| 1 | 0 | 0 + 1 | 1 |
| 2 | 1 | 1 + 2 | 3 |
| 3 | 3 | 3 + 3 | 6 |
| 4 | 6 | 6 + 4 | 10 |

`total` is called an **accumulator**. `+=` is the **compound assignment operator**.

⚠️ `total += 1` and `total += i` look alike, but they're very different:
- `total += 1` adds **one** each time → **counts** the iterations (1, 2, 3, 4 → **4**)
- `total += i` adds **the counter** → **sums** them (1, 3, 6, 10 → **10**)

**Why "before the loop"?** Two reasons:

```csharp
for (int i = 1; i <= 4; i++)
{
    int total = 0;     // ❌ a NEW empty piggy bank every iteration
    total += i;
}
Console.WriteLine($"Total: {total}");   // ❌ CS0103: total doesn't exist out here
```

1. It **resets to 0** on every iteration, so it can never grow.
2. It **dies at the `}`**, so you can't print it after the loop (**CS0103**).

🎬 **Animation idea:** a piggy bank on a shelf and a coin chute. Each iteration a coin with the value of `i` drops in, and the total under the bank grows: 1, 3, 6, 10. A switch moves `int total = 0;` inside the loop: now a brand-new empty piggy bank appears every round, the old one vanishes, and at the end the print line turns red with "CS0103: The name 'total' does not exist". A second switch changes `+= i` to `+= 1`, and the coins all become 1s, so the total only counts the laps.

### 8. Full example: Times Table (with a guard clause)

```csharp
Console.Write("Which times table? ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int number))
{
    Console.WriteLine("That's not a number.");
    return;
}

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
Which times table? 7
7 x 1 = 7
7 x 2 = 14
...
7 x 10 = 70
Sum of all answers: 385
```
```
Which times table? hello
That's not a number.
```

Two new things in it:

- **`!`** is the **logical NOT operator**: it flips `true` ↔ `false`. `TryParse` returns `false` for `hello`, and `!` turns that into `true`, so the error block runs.
- **`return;`** ends the program right there. This is an **early return**. An `if` at the top that checks for bad input and returns early is called a **guard clause**. Without the `return`, the program would print the error **and then** carry on with `number = 0`, printing `0 x 1 = 0` … `Sum of all answers: 0`.

Note that `answer` is declared **inside** the loop, and that's fine: it's only needed for one iteration. `sum` is declared **outside**, because it must survive all 10.

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| `for` loop | `for (int i = 1; i <= 5; i++) { ... }` | **exactly the same** |
| `var` counter | `for (var i = 0; i < 3; i++)` | `for (var i = 0; i < 3; i++)` |
| Print inside | `print('Lap $i');` | `Console.WriteLine($"Lap {i}");` |
| `+=`, `-=`, `++`, `--` | yes | yes |
| `!` (NOT) | `if (!isValid)` | `if (!isValid)` |
| Guard clause | `if (number == null) { print('Not a number'); return; }` | `if (!int.TryParse(...)) { ...; return; }` |
| Loop variable after the loop | out of scope | out of scope (**CS0103**) |

```dart
// Dart
for (int i = 5; i >= 1; i--) {
  print(i);
}
print('🚀 Liftoff!');
```
```csharp
// C#
for (int i = 5; i >= 1; i--)
{
    Console.WriteLine(i);
}
Console.WriteLine("🚀 Liftoff!");
```

---

## 🐞 Errors I actually hit

| Error / mistake | Why | Fix |
|---|---|---|
| Expected `Total: 10`, got `Total: 4` | Typed `total += 1` (the number one) instead of `total += i` (the letter i) | `+= i` to **sum**; `+= 1` only **counts** |
| **CS0103** "The name 'total' does not exist in the current context" | `int total = 0;` was moved **inside** the loop, so it died at the `}` | Declare the accumulator **before** the loop |
| Times Table: no "Sum of all answers" line, but I said "done" | The sum was **calculated** but never **printed** | Add the `WriteLine` **after** the loop's `}`. "Done" = my output matches the **expected** output line by line |
| `That is not a number` → `This is not a number` | Retyped the spec's text instead of copying it | **Copy-paste** exact text from the spec: `That's not a number.` |
| Quiz: thought `for (int i = 0; i < 3; i++)` prints 2 times | Forgot that `i = 0` is also a trip | 0, 1, 2 = **3** times (4 checks) |
| Quiz: thought `for (int i = 2; ...; i += 3)` prints 5 first | Thought the iterator runs first | The **body runs before the iterator**: the first value is the **initializer** (2) |
| Trace said "4 > 4 false, stop" but my answer still listed 4 | Wrote the output from memory, not from the table's print column | The output = **only** the rows where the body ran |
| Called `i++` the "iteration" | **Iteration** = one trip; **iterator** = the step part | ① initializer, ② condition, ③ **iterator** |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| run this many times | **`for` loop** / counting loop | "We know the count up front, so use a `for` loop." |
| ① start | **initializer** | "The initializer runs only once." |
| ② check | **condition** | "The condition is checked before every iteration." |
| ③ step | **iterator** | "The iterator is `i += 3`, so it skips." |
| one trip around | **iteration** | "On the third iteration, `i` is 8." |
| `i` | **loop counter** / **loop variable** | "Don't use the loop counter after the loop, it's out of scope." |
| the piggy bank | **accumulator** | "Initialize the accumulator before the loop, otherwise it resets on every iteration." |
| `+=` | **compound assignment operator** | "Use `sum += answer` instead of `sum = sum + answer`." |
| one too many / too few | **off-by-one error** | "`4 > 4` is false, so it's an off-by-one, use `>=`." |
| where a variable lives | **scope** | "CS0103 means it's out of scope, declare it before the block." |
| `!` | **logical NOT operator** | "`!` negates the TryParse result." |
| bad input check at the top + `return` | **guard clause** + **early return** | "Add a guard clause, so the happy path isn't nested in an `else`." |
| the extra false check | the **final evaluation** of the condition | "The condition is evaluated once more than the body runs." |

---

## 📋 Summary

- `for (initializer; condition; iterator) { body }`
- Order: initializer (**once**) → condition → **body** → iterator → condition → …
- The first body run uses the **initializer** value
- N iterations = **N + 1** condition checks
- `for` when you **know the count**, `while` when you loop **until** something happens
- `<` vs `<=` decides the last value: watch for **off-by-one**
- The loop variable dies at the `}` (**scope**, **CS0103**)
- **Accumulator:** declare **before** the loop, update **inside**, print **after**
- `+= i` sums, `+= 1` counts
- **Guard clause:** `if (!int.TryParse(...)) { ...; return; }` at the top

---

## 📝 Quiz

1. Name the 3 parts of `for ( ___ ; ___ ; ___ )` with their real terms. Which one runs only once?
2. How many times does this print `Hi`, and how many times is the condition checked?
   ```csharp
   for (int i = 0; i < 4; i++) { Console.WriteLine("Hi"); }
   ```
3. What does this print?
   ```csharp
   for (int i = 1; i < 10; i += 4) { Console.Write($"{i} "); }
   ```
4. What's wrong here? Name the error and give two reasons it's a bad idea.
   ```csharp
   for (int i = 1; i <= 3; i++) { int sum = 0; sum += i; }
   Console.WriteLine(sum);
   ```
5. In the Times Table, what would happen with input `hello` if you deleted the `return;`?

<details>
<summary>Answers</summary>

1. **Initializer**, **condition**, **iterator**. The initializer runs only once.
2. `i` = 0, 1, 2, 3 → **4** times `Hi`, and **5** checks (the 5th, `4 < 4`, is false).
3. `1 5 9`. The next value, 13, fails `13 < 10`.
4. `sum` is declared **inside** the loop. **CS0103**: `sum` doesn't exist after the `}`. And even without the error, it would **reset to 0** on every iteration. Declare it before the loop.
5. It would print `That's not a number.` and then keep going with `number = 0`: `0 x 1 = 0` … `0 x 10 = 0`, `Sum of all answers: 0`.

</details>
