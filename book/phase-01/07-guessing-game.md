# Chapter 1.7: Validation loops and the Number Guessing Game

> Learned: Mon 12 Oct 2026 · Code: `lessons/phase-01/12-pin-lock`, `projects/01-number-guessing-game`

---

## 🧸 LKG story

**A validation loop is a door with a PIN pad.**

You stand at the door and type a PIN. The door keeps asking **until** the PIN is right.

- You type **letters** → the door beeps: "Digits only!" That try **doesn't count**, and it asks again.
- You type a **wrong number** → "Wrong PIN." That **counts** as a try, and it asks again.
- You type the **right number** → the door opens. 🚪

The door does **two checks, one inside the other**: first "is it a number at all?", and only then "is it the right number?"

**The guessing game is the same door with a twist.** Instead of "Wrong PIN", the door gives you a clue: "Too high!" or "Too low!"

🎬 **Animation idea:** a door with a PIN pad and a tally board. The child types `abc`: the pad flashes red, says "Digits only", and the tally does **not** move. They type `1111`: "Wrong PIN", and the tally goes up to 1. They type `4321`: the door swings open and the board says "Unlocked after 2 tries". A switch moves `tries++` **outside** the number check: now `abc` also adds a tally mark, and the total becomes 3.

---

## 💻 Real explanation

### 1. The input validation loop

An **input validation loop** keeps asking until the input is **valid** (a number) **and** correct. Inside it, there's a **nested `if`**: an `if` inside another `if`.

```csharp
int correctPin = 4321;
int pin = 0;      // starting value that makes the loop condition TRUE
int tries = 0;    // nothing counted yet

while (pin != correctPin)
{
    Console.Write("Enter PIN: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out pin))      // outer: is it a number?
    {
        tries++;                           // only real numbers count
        if (pin != correctPin)             // inner: is it wrong?
        {
            Console.WriteLine("Wrong PIN.");
        }
    }
    else
    {
        Console.WriteLine("Digits only, please.");
    }
}

Console.WriteLine($"Unlocked after {tries} tries.");
```

Output:
```
Enter PIN: abc
Digits only, please.
Enter PIN: 1111
Wrong PIN.
Enter PIN: 4321
Unlocked after 2 tries.
```

Why **2** tries and not 3? `abc` fails `TryParse`, so it goes to the `else`, and `tries++` never runs for it. Only `1111` and `4321` are counted.

Key points:
- `out pin` writes **straight into the loop's variable**, so the `while` check sees the new value next time.
- `tries++` sits **inside the outer `if`**, so bad input isn't counted.
- When the right PIN comes in, the inner `if` is false (nothing prints), the `while` check is false, and the loop ends.
- 🔍 When `TryParse` **fails**, it sets `pin` to `0`. That's safe here because the PIN is never 0, but always ask yourself: "what if the variable becomes 0?"

### 2. Where a line lives decides how many times it runs

C# runs the file **top to bottom**. A line **above** the loop runs **once**. A line **inside** the loop runs **every iteration**.

```csharp
int secretNumber = Random.Shared.Next(1, 101);   // above the loop → picked ONCE

while (guessNumber != secretNumber)
{
    // everything here runs again for every guess
}
```

- In **one game**, the secret stays the same for every guess.
- In the **next `dotnet run`**, the program starts fresh, so you get a new secret.

If the `Random` line goes **inside** the loop, it **overwrites** a variable on every round. On my first try, I wrote this:

```csharp
if (int.TryParse(input, out guessNumber))
{
    guessNumber = Random.Shared.Next(1, 101);   // ❌ overwrites the player's guess
}
```

Trace it with the input `42`:

| Line | `guessNumber` after it |
|---|---|
| `int.TryParse(input, out guessNumber)` | 42 (the player's guess) |
| `guessNumber = Random.Shared.Next(1, 101);` | 73 (random, **the 42 is lost**) |
| `while (guessNumber != secretNumber)` | `73 != 42` → true → keeps looping |

> The **computer** picks the **secret**. The **player** types the **guess**. `Random` never touches the guess.

🎬 **Animation idea:** the guessing game, playable. A switch moves the line `secretNumber = Random...` **above** the loop or **inside** it. Above: the secret hides behind a curtain and stays the same, and the clues lead you to it. Inside: every time you guess, the curtain shuffles and a new secret appears, so "Too high" and "Too low" stop making sense. A "middle guess" button shows the binary search trick: 50, then 25 or 75, and so on, finding any number in 7 guesses or fewer.

### 3. Three cases: too high, too low, correct

```csharp
if (int.TryParse(input, out guessNumber))
{
    numberOfAttempts++;

    if (guessNumber > secretNumber)
    {
        Console.WriteLine("Too high!");
    }
    else if (guessNumber < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
}
```

There are 3 cases, but "equal" prints **nothing** inside the loop: the loop simply ends, and the message after the loop prints. So there's no final `else`.

### 4. `if` / `else` = one path, not both

```csharp
if (numberOfAttempts == 1)
{
    Console.WriteLine("🎯 First try! Amazing!");
}
else
{
    Console.WriteLine($"🎉 Correct! You got it in {numberOfAttempts} attempts.");
}
```

Without the `else`, the 🎉 line is **outside** any branch, so it runs **every time**. On a first-try win, **both** lines printed. With `if` / `else`, you walk exactly **one** path.

### 5. Testing with a hard-coded secret

A random secret is hard to test, because you don't know the answer. So:

1. Start with `int secretNumber = 42;`
2. Test **every path**: letters, too high, too low, correct, first try.
3. **Then** switch to `Random.Shared.Next(1, 101)` and play for real.

Test plan with secret `42`:

| Input | Expected |
|---|---|
| `abc` | That's not a number. Try again. (not counted) |
| `50` | Too high! |
| `25` | Too low! |
| `42` | 🎉 Correct! You got it in 3 attempts. |
| `42` (as the first guess, in a new run) | 🎯 First try! Amazing! |

### 6. The full project

```csharp
Console.WriteLine("I'm thinking of a number between 1 and 100.");

int secretNumber = Random.Shared.Next(1, 101);
int guessNumber = 0;
int numberOfAttempts = 0;

while (guessNumber != secretNumber)
{
    Console.Write("Your guess: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out guessNumber))
    {
        numberOfAttempts++;
        if (guessNumber > secretNumber)
        {
            Console.WriteLine("Too high!");
        }
        else if (guessNumber < secretNumber)
        {
            Console.WriteLine("Too low!");
        }
    }
    else
    {
        Console.WriteLine("That's not a number. Try again.");
    }
}

if (numberOfAttempts == 1)
{
    Console.WriteLine("🎯 First try! Amazing!");
}
else
{
    Console.WriteLine($"🎉 Correct! You got it in {numberOfAttempts} attempts.");
}
```

A real game:
```
I'm thinking of a number between 1 and 100.
Your guess: 42
Too high!
Your guess: 10
Too low!
Your guess: 25
Too high!
Your guess: 20
Too high!
Your guess: 18
Too high!
Your guess: 15
Too high!
Your guess: 12
Too low!
Your guess: 14
🎉 Correct! You got it in 8 attempts.
```

🧠 **Binary search trick:** always guess the **middle** of what's left (50, then 25 or 75, ...). Each guess cuts the possibilities in half, so you find any number from 1 to 100 in **7 guesses or fewer**.

### 7. Clean code: names and formatting

- **Meaningful names:** the counter was first called `randomNumber`, but nothing about it was random. `numberOfAttempts` says what it **holds**. In VS Code, click a name and press **F2** to rename it everywhere at once.
- **Formatting rules:**
  - `}` and `else` go **together**, with no blank line between them (they're one statement).
  - The end of one block and the start of a new block get **one** blank line (for example, the game loop, then the result `if`).

### 8. The README

A **README.md** is the front page of a project on GitHub, written in **Markdown**: `#` for headings, `-` for bullets, three backticks for code blocks. Preview it in VS Code with **Ctrl+Shift+V**.

Write only what is **true**. My first draft said the secret was tested with 50 (it was 42) and that "the max is 100" (the max I pass is 101, and it's exclusive). An interviewer could ask about any line.

### 9. Git practice of the day

- `fatal: pathspec '...' did not match any files`: the path given to `git add` doesn't exist. When one path fails, Git stages **nothing**, so just fix it and try again.
- `git add .` stages **everything** in the folder. It's fine **only** when `git status` shows nothing but the files for this commit. Check `git status` before **and** after.
- `Your branch is ahead of 'origin/main' by 2 commits` = 2 **local commits** that are not on GitHub yet. `git push` sends them.
- A folder with only `obj` or `bin` inside is **build output**, not code. `.gitignore` already ignores it, and it's safe to delete.

---

## 🎯 Dart comparison

| | Dart | C# |
|---|---|---|
| Try to read a number | `int? n = int.tryParse(input);` (returns `null` if it fails) | `int.TryParse(input, out n)` (returns `bool`, the number goes into `n`) |
| Check if it worked | `if (n != null)` | `if (int.TryParse(...))` |
| When it fails | `n` is `null` | `n` is `0` |
| Random 1 to 100 | `Random().nextInt(100) + 1` | `Random.Shared.Next(1, 101)` |
| Pick once at the top | `final secret = ...;` | `int secretNumber = ...;` (above the loop) |
| Nested `if`, `else if` | same | same |

```dart
// Dart
final secret = Random().nextInt(100) + 1;
int? guess;
while (guess != secret) {
  guess = int.tryParse(stdin.readLineSync() ?? '');
  if (guess == null) { print("That's not a number."); continue; }
  // ...
}
```

---

## 🐞 Errors I actually hit

| Error / mistake | Why | Fix |
|---|---|---|
| `fatal: pathspec 'lessons/phase-01/atomic' did not match any files` | Typed the word "atomic" into a blank meant for a **folder name** | Use the real folder names (`10-random`, `11-roll-until-six`) |
| `git add` with one folder twice, another folder missing | Typed `11-roll-until-six` twice and forgot `10-random` | `git status` showed `10-random/` still **untracked** ✅, so I added it before committing |
| Extra folder `11-ro11l-until-six` with only `obj` inside | A typo created a **stray build folder** | `Remove-Item -Recurse -Force` (read the path twice before Enter) |
| Practice code typed into the **project's** `Program.cs` | Wrong file open | Cut it out (the project file must only hold the game), paste it into the lesson folder |
| Changed `tries = 0` to `1`, then `2`, when asked "why is it 2?" | Thought "explain why" meant "it's wrong". It wasn't! | Don't change code until you know **why** it does what it does. Trace first |
| `guessNumber = Random.Shared.Next(1, 101);` inside the loop | `Random` **overwrote** the player's guess, so typing `42` didn't stop the loop | The player types the guess, `Random` only picks the secret, once, above the loop |
| Two variables for one guess (`guessNumber` and `inputNumber`) | The `while` checked one, `out` wrote into the other | One variable: `out guessNumber` |
| Counter called `randomNumber` | The name didn't match what it holds | Renamed with **F2** to `numberOfAttempts` |
| First-try win printed **two** lines | The 🎉 line was outside any `else`, so it always ran | Put it inside `else` |
| Only tested one path of the bonus | "It works for 2 attempts" ≠ "it works for 1 attempt" | **Test every path** |
| ` I'm thinking...` printed with a space in front | A space inside the quotes | Delete it: `"I'm thinking..."` |
| README said "tested with 50" and "max is 100" | Not true (it was 42, and the max passed is 101) | Write only what's accurate |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| door that keeps asking | **input validation loop** | "Wrap the `TryParse` in a validation loop." |
| an `if` inside an `if` | **nested `if`** | "The range check is a nested `if` inside the parse check." |
| bad input not counted | **rejected input** / **invalid input** | "Invalid input is rejected and doesn't count as an attempt." |
| the random line wiped my guess | **overwrite** a variable | "The random call was overwriting the user's guess." |
| picked once at the top | **initialized once**, before the loop | "The secret is initialized once, so it stays constant for the whole game." |
| fixed number for testing | **hard-coded** test value | "I hard-coded the secret to 42 to test the logic." |
| try every road | **test every path / branch** | "Did you test the first-try branch?" |
| good names | **meaningful variable names** | "Rename `randomNumber`, it's not random." |
| F2 | **Rename Symbol**, a **refactoring** | "Use Rename Symbol so every reference changes." |
| neat blank lines | **formatting** / **code style** | "`else` goes on the line right after the `}`." |
| guess the middle | **binary search** | "Binary search finds it in 7 tries or fewer." |
| project front page | **README** (written in **Markdown**) | "Add a README with how to run it." |
| Git couldn't find my path | **pathspec** error | "The add failed, my pathspec had a typo." |
| leftover `obj` folder | **build output** / **stray build folder** | "That's just build output, it's gitignored." |
| `git add .` | **stage all changes** | "I staged everything because the working tree only had this change." |
| saved on my PC, not GitHub | **local commits**, **ahead of the remote** | "I'm 2 commits ahead, let me push." |

---

## 📋 Summary

- **Input validation loop:** `while` + `TryParse` + a **nested `if`**. Bad input goes to the `else` and isn't counted
- Put the counter **inside** the success branch, and **count it, then show it**
- A line **above** the loop runs **once**. A line **inside** the loop runs **every iteration**
- The secret is picked **once**. The guess comes from the **player**. Never let `Random` overwrite input
- `if` / `else` = **one** path. A line after an `if` with no `else` **always** runs
- Test with a **hard-coded** value, test **every** path, then switch to random
- **Meaningful names** (F2 to rename) and clean **formatting**
- README: honest, accurate, with a real example run

---

## 📝 Quiz

1. You type `abc`, `7`, `9` into the PIN lock (correct PIN `9`). What's `tries` at the end, and why?
2. What goes wrong if you put `int secretNumber = Random.Shared.Next(1, 101);` **inside** the `while` loop?
3. Why does the guessing loop not need a final `else` for "correct"?
4. This prints **two** lines on a first-try win. Why?
   ```csharp
   if (numberOfAttempts == 1)
   {
       Console.WriteLine("First try!");
   }
   Console.WriteLine($"Correct in {numberOfAttempts} attempts.");
   ```
5. The `TryParse` fails and sets `guessNumber` to `0`. Why is that safe in this game? When would it **not** be safe?

<details>
<summary>Answers</summary>

1. **2**. `abc` fails `TryParse`, goes to the `else`, and `tries++` never runs for it. `7` and `9` are counted.
2. A new secret is picked on **every** guess, so the clues ("too high", "too low") are about a number that keeps changing. (Declaring it inside also puts it **out of scope** for the `while (...)` check, which gives **CS0103**.)
3. When the guess equals the secret, nothing needs to print **inside** the loop: the `while` check becomes false, the loop ends, and the success message **after** the loop prints.
4. The second `Console.WriteLine` is not inside an `else`, so it runs every time, even after "First try!". Put it in an `else`.
5. The secret is from 1 to 100, so it's **never 0**, and a failed parse can never accidentally "win". It would **not** be safe if 0 could be a correct answer: then typing `abc` would end the loop.

</details>
