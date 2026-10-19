# Chapter 1.16: Methods, part 2 (bool methods, else, a method that calls a method)

> Learned: Mon 19 Oct 2026 · Code: `lessons/phase-01/23-methods`, `lessons/phase-01/25-heavy-parcel`, `lessons/phase-01/26-delivery-vehicle`

---

## 🧸 LKG story

**A `bool` method is a guard at the gate who only says "yes" or "no".** You show the guard a parcel, the guard checks the scale, and answers: "Heavy? Yes." The guard doesn't load the van. The guard only answers the question.

🎬 **Animation idea:** a parcel on a scale with a slider for its weight (0–20 kg). A switch picks the rule: `weight > 10` or `weight >= 10`. The code lights up the path it takes (`return true;` or `return false;`), and a van or a bike drives in. Stop exactly on 10 kg and flip the switch to see the **boundary value** change its answer.

**A method that calls a method is a cashier using a calculator.** The manager asks the cashier for a bill. The cashier asks the calculator for the total, then prints the bill. The manager only talks to the cashier.

**`else` has no question of its own.** It is the "otherwise" door. If you write a question after it, or close it with `;`, the door falls off, and the room behind it is open to everyone.

🎬 **Animation idea:** two versions of the code side by side: the correct `else { ... }` and the broken `else IsHeavy(4.5); { ... }`. A slider sets the parcel weight. In the correct version, only one block lights up. In the broken one, the `{ }` block lights up **every time**, even for 50 kg, and prints "bike" for a heavy parcel.

---

## 💻 Real explanation

### 1. Read the first line carefully

```csharp
double   AddDeliveryFee   (double price)
return    method name      parameter
type                       (type + name)
```

- The `double` **before the name** is the **return type**: what the method **gives back**
- The `double` **inside `( )`** is the **parameter type**: what the method **accepts**
- The **parameter** is the **name**, `price`. `double` is only its type

### 2. A method that returns `bool`

```csharp
bool IsAdult(int age)
{
    if (age >= 18)
    {
        return true;
    }
    return false;
}

Console.WriteLine(IsAdult(25));
Console.WriteLine(IsAdult(12));
```
```
True
False
```

- `return` **stops the method right away**. For 25, `return true;` runs and `return false;` is never reached
- C# prints `True` / `False` with a capital letter. In code you still write lowercase `true` / `false`

A shorter way pros write the same method, because `age >= 18` already *is* `true` or `false`:

```csharp
bool IsAdult(int age)
{
    return age >= 18;
}
```

### 3. Call a `bool` method inside an `if`

```csharp
if (IsAdult(15))
{
    Console.WriteLine("Can drive");
}
else
{
    Console.WriteLine("Too young");
}
```
```
Too young
```

C# runs `IsAdult(15)` first, gets `false`, and then the `if` checks that `false`.

### 4. Every check needs its own `if` / `else` pair

```csharp
bool IsHeavy(double weight)
{
    if (weight > 10)
    {
        return true;
    }
    return false;
}

if (IsHeavy(12))
{
    Console.WriteLine("12 kg: van");
}
else
{
    Console.WriteLine("12 kg: bike");
}
// ...the same pair again for 4.5 and for 10
```
```
12 kg: van
4.5 kg: bike
10 kg: bike
```

- The `10` inside `IsHeavy` is the **threshold** (the limit). `weight` is the parcel **being checked**
- `10 > 10` is **false**, so exactly 10 kg goes by bike. That edge is called the **boundary value**. Testers always check it
- `else` takes **no condition** and **no `;`**

### 5. A method that calls another method

```csharp
double AddTax(double price)
{
    return price + 2;
}

void PrintBill(string item, double price)
{
    double total = AddTax(price);     // calls the other method
    Console.WriteLine($"{item}: {total} KD");
}

PrintBill("Shoes", 10);
PrintBill("Bag", 5);
```
```
Shoes: 12 KD
Bag: 7 KD
```

The flow: `PrintBill("Shoes", 10)` → `price` is 10 → `AddTax(10)` returns 12 → `total` is 12 → print.

### 6. Methods remove repetition

Exercise 25 needed three big `if` / `else` blocks. With a method that calls `IsHeavy`, it's three one-line calls:

```csharp
void PrintVehicle(double weight)
{
    if (IsHeavy(weight))
    {
        Console.WriteLine($"{weight} kg: van");
    }
    else
    {
        Console.WriteLine($"{weight} kg: bike");
    }
}

PrintVehicle(12);
PrintVehicle(4.5);
PrintVehicle(10);
```
```
12 kg: van
4.5 kg: bike
10 kg: bike
```

- `PrintVehicle` passes its own parameter on: `IsHeavy(weight)`
- Both methods have a parameter called `weight`. They are **two separate variables**, each living only inside its own method's `{ }` (its **scope**)
- The threshold lives in **one place**. Change `10` to `15` in `IsHeavy`, and every caller follows

---

## 🎯 Dart comparison

```dart
// Dart
bool isHeavy(double weight) => weight > 10;

void printVehicle(double weight) {
  if (isHeavy(weight)) {
    print('$weight kg: van');
  } else {
    print('$weight kg: bike');
  }
}
```
```csharp
// C#
bool IsHeavy(double weight) => weight > 10;   // the same arrow style works in C#!

void PrintVehicle(double weight)
{
    if (IsHeavy(weight)) Console.WriteLine($"{weight} kg: van");
    else Console.WriteLine($"{weight} kg: bike");
}
```

Same idea. Dart prints `true`; C# prints `True`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Said `double` in `double AddDeliveryFee(...)` means "accepts only double" | Mixed up the two `double`s on line 1 | Before the name = **return type**. Inside `( )` = **parameter type** |
| Said the parameter is `double` | `double` is only the type | The parameter is the **name**: `price` |
| Only 1 line printed (`12 kg: van`) | No `else`, so `false` printed nothing | Add `else { ... }` for the "bike" line |
| Wrote `else` first, then **deleted** it | Wasn't sure it was right | When unsure, **keep it and run it** |
| `else IsHeavy(4.5);` then `{ ... }` | `else` takes no condition; the `;` ended it, so the block ran **always** | Each parcel gets its own `if (...) { } else { }` |
| `AddTxt` instead of `AddTax` | Typo (it still worked, because it was the same both times) | Names are for humans, so spell them carefully |
| Output `Shoes: 12`, no `KD` | Left ` KD` out of the string | Compare the line with the example |
| No prediction before running exercise 25 | Rushed | Predict all lines first |

✅ Wins: predicted the boundary (10 → bike) with the reason (`>` not `>=`); asked "what is the base weight?", which led to the word **threshold**; exercise 26 was perfect on the first try, with full-line predictions.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| the `double` before the name | **return type** | "AddDeliveryFee returns a double." |
| the `double` inside `( )` | **parameter type** | "It takes the price as a double parameter." |
| the yes/no guard | **`bool` method** / **predicate** | "`IsHeavy` is a predicate, call it in the `if` condition." |
| the limit | **threshold** | "The heavy threshold is 10 kg." |
| the exact edge | **boundary value** | "Test the boundary value: is exactly 10 heavy?" |
| cashier uses a calculator | **calling a method from a method** | "`PrintVehicle` calls `IsHeavy`." |
| the door fell off | **empty statement** after `else ...;` | "That `;` makes it an empty statement, so the block always runs." |

---

## 📋 Summary

- Line 1 of a method: **return type**, name, then parameters (type + **name**)
- A `bool` method answers yes/no; `return` stops the method right away
- Call a `bool` method straight inside `if (...)`
- `else` has no condition and no `;`
- A method can call another method and use its return value
- Keep the threshold in one method so one change updates every caller

---

## 📝 Quiz

1. In `bool IsHeavy(double weight)`, what is the return type, and what is the parameter?
2. What does `IsAdult(12)` return, and does the line `return false;` run for `IsAdult(25)`?
3. Why did `else IsHeavy(4.5); { Console.WriteLine("4.5 kg: bike"); }` print "bike" even though it was wrong?
4. With `weight > 10`, is 10 kg heavy? What about with `weight >= 10`?
5. Predict: `PrintBill("Bag", 5);` when `AddTax` returns `price + 2`.

<details>
<summary>Answers</summary>

1. Return type: `bool`. Parameter: `weight` (its type is `double`).
2. `false`. No: `return true;` runs first and stops the method.
3. `else` can't take a condition. The `;` ended the `else`, so the `{ }` became a standalone block that **always** runs.
4. `10 > 10` is false → not heavy. `10 >= 10` is true → heavy.
5. `Bag: 7 KD`.

</details>
