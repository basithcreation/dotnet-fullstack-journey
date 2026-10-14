# Chapter 1.10: break and continue

> Learned: Wed 14 Oct 2026 · Code: `lessons/phase-01/17-break-continue`

---

## 🧸 LKG story

**`break` is the cinema.** You're watching a 2-hour movie, and after 30 minutes your manager calls: *"Come to the office now!"* You **walk out of the cinema immediately**. You don't watch the rest of the movie.

**`continue` is the playlist.** A song you don't like comes on. You press **"Next"**. That **one** song is skipped, but the **playlist keeps playing**.

🎬 **Animation idea:** a row of numbered boxes 1 to 10 on a conveyor belt, with a switch for `break` / `continue` and a slider for the "trigger" number. Press "Next step" and each box slides under a printer that stamps its number into the output. With `continue`, the trigger box gets a ⏭️ and slides past without a stamp, and the belt keeps going. With `break`, the belt stops at the trigger box with a 🚪, the remaining boxes turn grey, and "after the loop" prints.

---

## 💻 Real explanation

### 1. `break`: leave the loop now

`break` **exits the loop immediately**. The rest of the body is skipped, the condition isn't checked again, and the program continues at the **first line after the loop**.

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 4)
    {
        break;              // jump out NOW
    }
    Console.WriteLine(i);
}
Console.WriteLine("after the loop");
```
```
1
2
3
after the loop
```

5 to 10 never run. The loop doesn't **complete**, it is **exited early**.

You already met `break` in a `switch` (Chapter 1.4), where it ends a **case**. Inside a loop, it ends the **loop**.

Typical use: **searching**. Once you've found what you need, stop looking.

### 2. `continue`: skip this iteration

`continue` **skips the rest of the body for this iteration only** and jumps to the next one:
- in a `for` → it runs the iterator (`i++`), then checks the condition
- in a `while` / `do-while` → it goes straight to the condition check

```csharp
for (int i = 1; i <= 6; i++)
{
    if (i == 3)
    {
        continue;
    }
    Console.WriteLine(i);
}
Console.WriteLine("done");
```
```
1
2
4
5
6
done
```

The trace for `i = 3`:
```
i = 3 → if (i == 3) is true → continue
      → Console.WriteLine(i) is SKIPPED
      → i++ → i = 4 → the loop goes on
```

⚠️ In English, "continue" sounds like *"carry on normally"*. In C#, it means **"go to the next round now"**.

### 3. Side by side

| Keyword | Story | What stops | Same loop, trigger at `i == 2`, `i` from 1 to 5 |
|---|---|---|---|
| `break` | Leave the cinema | The **whole loop** | `1` |
| `continue` | Skip one song | Only **this iteration** | `1 3 4 5` |

**Memory trick:**
- `break` = **break out** of the loop (stops **all**)
- `continue` = **continue with the next** round (skips **one**)

---

## 🎯 Dart comparison

Exactly the same keywords and the same behaviour in Dart:

```dart
// Dart
for (var i = 1; i <= 6; i++) {
  if (i == 3) continue;
  if (i == 5) break;
  print(i);
}
// 1 2 4
```
```csharp
// C#
for (int i = 1; i <= 6; i++)
{
    if (i == 3) { continue; }
    if (i == 5) { break; }
    Console.WriteLine(i);
}
// 1 2 4
```

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Predicted `break` at `i == 4` prints `1 2 3 5 6 7 8 9 10` | Thought `break` skips only one value | `break` leaves the **whole** loop → `1 2 3` |
| Predicted `continue` at `i == 3` prints `1 2 3 4 5 6` | Read "continue" as the English word ("carry on, nothing special") | `continue` skips **the rest of this iteration** → 3 is not printed |
| Said "after the loop" prints "after the loop is completed" | With `break`, the loop is **exited early**, not completed | The program jumps to the first line after the loop |

(Funny detail: my `break` prediction was the exact output of `continue`.)

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| walk out of the cinema | **`break`** / **exit the loop early** | "We break out of the loop as soon as we find a match, no need to check the rest." |
| skip one song | **`continue`** / **skip to the next iteration** | "If the input is invalid, we `continue` to skip it and ask again." |
| `break`, `continue`, `return` | **jump statements** | "Avoid too many jump statements in one loop, it gets hard to follow." |
| stop searching when found | **early exit** | "Add an early exit once the item is found." |

---

## 📋 Summary

- `break` → leaves the **whole loop** now, and the program goes to the first line after the loop
- `continue` → skips **the rest of this iteration**, then the loop goes on (in a `for`, the iterator still runs)
- `break` also ends a `case` in a `switch`
- Same keywords and behaviour in Dart

---

## 📝 Quiz

1. What does this print?
   ```csharp
   for (int i = 1; i <= 5; i++)
   {
       if (i == 2) { break; }
       Console.WriteLine(i);
   }
   ```
2. And this?
   ```csharp
   for (int i = 1; i <= 5; i++)
   {
       if (i == 2) { continue; }
       Console.WriteLine(i);
   }
   ```
3. In a `for` loop, does `i++` still run after a `continue`?
4. Which keyword would you use to stop searching a list once you find the item?
5. What does this print?
   ```csharp
   int n = 0;
   while (n < 6)
   {
       n++;
       if (n % 2 == 0) { continue; }
       Console.Write($"{n} ");
   }
   ```
   (`n % 2 == 0` means "n is even".)

<details>
<summary>Answers</summary>

1. `1`. At `i == 2`, `break` leaves the loop.
2. `1 3 4 5`. Only 2 is skipped.
3. Yes. `continue` skips the rest of the **body**, then the iterator runs and the condition is checked.
4. `break` (an **early exit**).
5. `1 3 5`. The even numbers are skipped. Note that `n++` is **before** the `continue`. If it were after, `n` would get stuck at 2 → an infinite loop.

</details>
