# Chapter 1.13: Arrays and foreach

> Learned: Sat 17 Oct 2026 · Code: `lessons/phase-01/19-arrays`, `lessons/phase-01/20-parcel-weights`

---

## 🧸 LKG story

**An array is one shelf with numbered slots.** Until now, one variable was one box with one value. A courier with 5 parcels would need `parcel1`, `parcel2`, `parcel3`... An array is **one name** for a whole shelf. The slots are numbered from **0**, so a shelf with 3 slots has slots 0, 1 and 2. Ask for slot 3 and the shelf falls over: the program crashes.

🎬 **Animation idea:** a shelf with parcels labelled 12, 7 and 30 kg, and slot numbers 0, 1, 2 underneath. Type an index: the matching parcel lights up and `weights[i]` shows its value. Type 3 (or -1): the shelf shakes and a red `IndexOutOfRangeException` sign drops down. A `Length` badge always shows 3, and an arrow points at the last slot: `Length - 1`.

**`foreach` is a postman walking along the shelf.** He picks up each parcel in turn, from the first to the last, without ever reading the slot numbers. He carries two things: a **running total** (he adds every parcel's weight) and a **tally sheet** (one mark for each heavy parcel). He only announces the results after the last parcel, outside the shelf.

🎬 **Animation idea:** the postman steps along 5 parcels (2.5, 12, 0.8, 15.5, 7). Each step shows `parcelWeight`, the new `total`, and whether the heavy check is true. Pick what the `if` checks: `parcelWeight > 10` gives 2 heavy parcels; `total > 10` (the bug) wrongly marks 0.8 and 7 as heavy and ends with 4.

---

## 💻 Real explanation

### 1. Creating and reading an array

```csharp
int[] weights = { 12, 7, 30 };   // 3 slots: index 0, 1, 2

Console.WriteLine(weights[0]);       // first
Console.WriteLine(weights[2]);       // last
Console.WriteLine(weights.Length);   // how many slots

weights[1] = 9;                      // change slot 1
Console.WriteLine(weights[1]);
```
```
12
30
3
9
```

- An array holds **many values of the same type** (`int[]`, `double[]`, `string[]`)
- Its **size is fixed** when it's created. There's no "add" (that's `List<T>`, next chapter)
- The index goes from `0` to **`Length - 1`**. 5 slots → last index 4

### 2. Out of range = crash

```csharp
Console.WriteLine(weights[3]);
```
```
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
```

`double / 0` quietly gave `∞`, but arrays are strict: a wrong index **throws an exception** and stops the program. C# also does the maths inside `[ ]` first: `weights[0 + 1 + 2 + 3 + 4]` is `weights[10]`, which crashes too.

### 3. `foreach`: visit every element

```csharp
string[] cities = { "Hawalli", "Salmiya", "Farwaniya" };

foreach (string city in cities)
{
    Console.WriteLine($"Delivering to {city}");
}
```
```
Delivering to Hawalli
Delivering to Salmiya
Delivering to Farwaniya
```

Each round, `city` holds the **next element**. There's no index, so it can't go out of range, and it stops by itself after the last one.

### 4. foreach + an accumulator + a counter

```csharp
double[] weights = { 2.5, 12, 0.8, 15.5, 7 };

double total = 0;      // the adder: declared before the loop
int heavyCount = 0;    // the counter: declared before the loop

foreach (double parcelWeight in weights)
{
    total = total + parcelWeight;

    if (parcelWeight > 10)
    {
        heavyCount++;
    }
}

Console.WriteLine($"Total weight: {total} kg");
Console.WriteLine($"Heavy parcels (over 10 kg): {heavyCount}");
```
```
Total weight: 37.8 kg
Heavy parcels (over 10 kg): 2
```

| round | `parcelWeight` | `total` | `parcelWeight > 10`? | `heavyCount` |
|---|---|---|---|---|
| 1 | 2.5 | 2.5 | no | 0 |
| 2 | 12 | 14.5 | yes | 1 |
| 3 | 0.8 | 15.3 | no | 1 |
| 4 | 15.5 | 30.8 | yes | 2 |
| 5 | 7 | 37.8 | no | 2 |

Three rules:
1. Boxes that **collect** (total, count) are declared **before** the loop, or they'd restart at 0 every round
2. The check is about **this** parcel (`parcelWeight`), not the running `total`
3. The results are printed **after** the loop, once

---

## 🎯 Dart comparison

```dart
// Dart
final cities = ['Hawalli', 'Salmiya', 'Farwaniya'];   // a growable List
cities.add('Jahra');                                    // OK in Dart
for (final city in cities) { print('Delivering to $city'); }
```
```csharp
// C#
string[] cities = { "Hawalli", "Salmiya", "Farwaniya" };   // a fixed-size array
// cities.Add("Jahra");  ← doesn't exist: arrays can't grow
foreach (string city in cities) { Console.WriteLine($"Delivering to {city}"); }
```

`foreach (x in list)` is Dart's `for (var x in list)`. The big difference: a Dart `List` can grow, but a C# **array** can't. C#'s growable list is `List<T>`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Predicted only the city names | Forgot the text in the `WriteLine` | Predict the **whole** line: `Delivering to Hawalli` |
| Printed a hard-coded `"Heavy parcels: 2"` inside the loop | Wrote the expected answer instead of computing it | Count with `heavyCount++` and print `{heavyCount}` after the loop |
| Named the loop box `totalWeight` | It holds **one** parcel each round, not the total | `parcelWeight`. Arrays get plural names: `weights` |
| `total = weight[0 + 1 + 2 + 3 + 4];` → `IndexOutOfRangeException` | The maths runs first: `weight[10]` | In a `foreach`, use the loop box: `total = total + parcelWeight` |
| `if (total > 10)` → 4 heavy parcels instead of 2 | Checked the running total, not this parcel | `if (parcelWeight > 10)` |

✅ Win: both results were printed **after** the loop. The Day 8 / Day 9 "inside vs outside the loop" mistake didn't happen.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| shelf | **array** | "Store the weights in a `double[]` array." |
| slot number | **index** (zero-based) | "Index 0 is the first element." |
| one parcel on the shelf | **element** | "The array has 5 elements." |
| how many slots | **length** (`.Length`) | "Loop until `Length - 1`." |
| asking for a slot that isn't there | **index out of range** / **out of bounds** | "That throws an IndexOutOfRangeException." |
| a runtime crash | **exception** | "The exception is unhandled, so the app stops." |
| the postman walk | **iterate** / **loop over** with `foreach` | "Iterate over the parcels with a foreach." |
| running total | **accumulator** | "Declare the accumulator before the loop." |
| tally | **counter** | "Increment the counter for each heavy parcel." |
| fake fixed answer | **hard-coded value** | "Don't hard-code the count, compute it." |

---

## 📋 Summary

- An array (`int[]`, `double[]`, `string[]`) is one variable with many slots of the same type, fixed in size
- Indexes go from `0` to `Length - 1`. Outside that range → `IndexOutOfRangeException`
- `foreach (type item in array)` visits every element in order, with no index and no crash
- Collect with boxes declared **before** the loop; print the results **after** it
- Inside the loop, check the current element, not the running total

---

## 📝 Quiz

1. An array has `Length` 5. What is its last index?
2. `int[] a = { 4, 8, 15 };` What do `a[1]` and `a.Length` print?
3. What happens with `a[3]`?
4. Why must `total` be declared **before** the `foreach`, not inside it?
5. In the parcel loop, why is `if (total > 10)` wrong?

<details>
<summary>Answers</summary>

1. `4` (`Length - 1`).
2. `8` (index 1 is the second element) and `3`.
3. The program crashes with `IndexOutOfRangeException`: the last index is 2.
4. Inside the loop, `double total = 0;` would run every round and reset it to 0, and it couldn't be printed after the loop either (scope).
5. `total` is the running sum, which passes 10 after the second parcel, so every later parcel looks "heavy" (4 instead of 2). The question is about each parcel: `parcelWeight > 10`.

</details>
