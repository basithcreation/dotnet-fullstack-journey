# Chapter 1.17: `ref` and `out` (and the Try pattern)

> Learned: Mon 19 Oct 2026 · Code: `lessons/phase-01/23-methods`, `lessons/phase-01/27-parcel-fee`

---

## 🧸 LKG story

**Pass by value is a photocopy.** You give your friend a photocopy of your homework. Your friend scribbles on it. Your original stays clean.

**`ref` is the original.** This time you hand over your **original** homework. Whatever your friend writes, you see it too.

🎬 **Animation idea:** a homework sheet that says `myPoints = 5`. A switch picks "photocopy (no ref)" or "original (ref)". Press "Call AddBonus": a sheet slides into the method, gets `+10` written on it, and comes back. With the photocopy, the copy says 15 and is thrown away, so the original still says 5. With `ref`, the original itself now says 15.

**`out` is an empty box.** You hand someone an empty box and say "put the answer in here". It doesn't matter what was in it before. But they **must** put something in before they leave, at **every** door.

🎬 **Animation idea:** `TryGetFee(weight, out fee)` with a weight slider from −5 to 20 kg. The code lights up the path it takes, the `fee` box fills up, and the `if` prints "Fee: ... KD" or "Invalid weight". A switch "forget `fee = 0` on the bad path" turns the build red with CS0177.

---

## 💻 Real explanation

### 1. Pass by value (the default)

```csharp
void AddBonus(int points)
{
    points = points + 10;
    Console.WriteLine($"Inside: {points}");
}

int myPoints = 5;
AddBonus(myPoints);
Console.WriteLine($"Outside: {myPoints}");
```
```
Inside: 15
Outside: 5
```

The method gets a **copy** of the value. It changes the copy; the caller's `myPoints` stays 5.

### 2. `ref`: pass by reference

```csharp
void AddBonus(ref int points)      // ref here
{
    points = points + 10;
}

int myPoints = 5;
AddBonus(ref myPoints);            // and ref here
Console.WriteLine($"Outside: {myPoints}");
```
```
Outside: 15
```

- `ref` goes in **both** places: the parameter and the call
- The variable must **already have a value** before the call

### 3. `out`: send back an extra result

```csharp
bool SplitPrice(double total, out double tax)
{
    tax = total * 0.1;      // the method MUST fill it
    return total > 0;
}

bool ok = SplitPrice(50, out double myTax);   // declared right in the call
Console.WriteLine($"{ok} {myTax}");
```
```
True 5
```

- The **`return`** gives one result (`ok`). The **`out`** gives another (`myTax`). They are **two separate results**
- Experiment: change it to `return total > 51;` and the output is `False 5`. The `out` value is still filled

| | `ref` | `out` |
|---|---|---|
| Caller must set a value first? | ✅ yes | ❌ no |
| Method must set a value? | ❌ no | ✅ yes |
| Used for | changing the caller's variable | sending back an extra result |

### 4. You already knew `out`: `TryParse`

```csharp
if (int.TryParse(input, out int number))
```

`TryParse` **returns** `bool` (did it work?) and gives the number back through **`out`**. This is the **Try pattern**.

### 5. Every `return` needs the `out` filled first

```csharp
bool TryGetFee(double weight, out double fee)
{
    if (weight <= 0)
    {
        fee = 0;            // filled before this return
        return false;
    }
    fee = weight * 0.5;     // and before this one
    return true;
}

if (TryGetFee(4, out double fee1))
{
    Console.WriteLine($"Fee: {fee1} KD");
}
else
{
    Console.WriteLine("Invalid weight");
}

if (TryGetFee(-2, out double fee2))
{
    Console.WriteLine($"Fee: {fee2} KD");
}
else
{
    Console.WriteLine("Invalid weight");
}
```
```
Fee: 2 KD
Invalid weight
```

- Forget `fee = 0;` on the bad path → **CS0177**: the out parameter must be assigned before control leaves the method
- `true` means "**it worked**", just like `TryParse`
- Each call needs a **new name** for its `out` variable (`fee1`, `fee2`)

---

## 🎯 Dart comparison

Dart has **no `ref` and no `out`** for numbers. In Dart you'd **return** the new value, or return two values together:

```dart
// Dart 3: return two values as a record
(bool, double) tryGetFee(double weight) =>
    weight <= 0 ? (false, 0) : (true, weight * 0.5);
```

In C# the Try pattern with `out` is the classic way, and you'll see it everywhere in .NET (`int.TryParse`, `Dictionary.TryGetValue`).

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Predicted `50 5`, real output `True 5` | Worked out `true` correctly, then didn't use it; the line prints `{ok}`, not the total | For each `{ }`, ask "which variable, which value?" |
| `bool TryGetFee(double weight out double fee)` | Missing comma | Parameters are separated by commas |
| `return weight <= 0;` → "Invalid weight" for 4 | Backwards: it returned `true` for a **bad** weight | `true` = it worked. Use two paths: bad → `false`, good → `true` |
| −2 kg gave `Fee: -1 KD` | No bad-weight path, so it always did `weight * 0.5` | Add `if (weight <= 0) { fee = 0; return false; }` |
| `fee = 0.5;` on the bad path | Hidden bug: the output only says "Invalid weight", so the wrong fee never shows | Read the code, not only the output. The rule says `0` |
| Pasted code in chat that didn't match the file | Typed it from memory | Paste what is really in the file |

✅ Wins: predicted pass-by-value and `ref` correctly; **experimented** on my own (`total > 51`) and saw that `out` is filled even when the method returns `false`.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| photocopy | **pass by value** | "`int` is passed by value, so the method only changes its copy." |
| the original | **pass by reference** (`ref`) | "Pass it by `ref` so the method changes the original." |
| empty box | **`out` parameter** | "`TryParse` gives the number back through an out parameter." |
| fill it at every door | **definite assignment** (CS0177) | "CS0177: the out parameter isn't assigned on every path." |
| Try + bool + out | **Try pattern** | "Use the Try pattern instead of throwing for bad input." |
| looks right, value wrong | **silent bug** | "The output looks fine but `fee` is 0.5, that's a silent bug." |

---

## 📋 Summary

- By default a method gets a **copy** of an `int` / `double` (pass by value)
- `ref` (in both places) lets the method change the caller's variable; the variable needs a value first
- `out` sends back an extra result; the method must fill it before **every** `return`
- Try pattern: return `bool` "did it work?" + the result through `out`, like `int.TryParse`

---

## 📝 Quiz

1. Without `ref`, a method adds 10 to its `int` parameter. Does the caller's variable change? Why?
2. Where do you write `ref`: in the method, in the call, or both?
3. Which one needs a value **before** the call, `ref` or `out`?
4. What does CS0177 mean?
5. In the Try pattern, what does the `bool` return value mean, and where does the actual result come out?

<details>
<summary>Answers</summary>

1. No. The method got a copy (pass by value).
2. Both: `void AddBonus(ref int points)` and `AddBonus(ref myPoints)`.
3. `ref`. With `out`, the method fills it.
4. An `out` parameter wasn't assigned before a `return` (on some path).
5. `true` = it worked, `false` = bad input. The result comes out through the `out` parameter.

</details>
