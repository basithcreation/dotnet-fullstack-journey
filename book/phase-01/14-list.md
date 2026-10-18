# Chapter 1.14: Lists, an array that can grow

> Learned: Sun 18 Oct 2026 · Code: `lessons/phase-01/21-list`, `lessons/phase-01/22-delivery-queue`

---

## 🧸 LKG story

**An array is an egg tray. A list is a shopping bag.** If you buy a tray for 4 eggs, it holds 4 eggs, no more and no less. A shopping bag is different: you keep putting things in (**Add**), you take things out (**Remove**), and at any moment you can ask "how many are inside?" (**Count**). The items in the bag still stand in a line, numbered from 0.

🎬 **Animation idea:** a delivery bag with parcel tags KP101 to KP104. Buttons: "Add parcel", "Deliver KP102" (Remove), "Deliver first" and "Reset". After each click, the parcels slide to close the gap, their index numbers (0, 1, 2…) update, a `Count` badge changes, and the matching C# line appears in a terminal (`parcels.Add("KP105");`, `parcels.Remove("KP102");`). A side note shows that the parcel at index 1 is now a different one.

---

## 💻 Real explanation

### 1. Create, add, count

```csharp
List<string> drivers = new List<string>();

drivers.Add("Ali");
drivers.Add("Ravi");
drivers.Add("Omar");
Console.WriteLine($"Drivers: {drivers.Count}");
```
```
Drivers: 3
```

- `List<string>` means "a list that holds only strings". The `<T>` part is the **type parameter**, so `List<T>` is a **generic** type. `List<int>` holds whole numbers, `List<double>` holds decimals
- It starts **empty** and grows with every `Add`
- Arrays use `.Length`; lists use **`.Count`**

### 2. Remove, index, foreach

```csharp
drivers.Remove("Ravi");
Console.WriteLine($"After remove: {drivers.Count}");
Console.WriteLine($"First driver: {drivers[0]}");

foreach (string driver in drivers)
{
    Console.WriteLine($"- {driver}");
}
```
```
After remove: 2
First driver: Ali
- Ali
- Omar
```

- `Remove("Ravi")` takes that item out, and everything after it **moves up one place**. Omar was at index 2; now he's at index 1
- `[0]` still means the first item, and the list is **zero-based** like an array
- `foreach` works exactly like it does with arrays

### 3. Read before you remove

In the delivery queue, the parcel at index 1 was delivered. Printing it **before** removing it gives the right ID:

```csharp
Console.WriteLine($"Delivered: {parcels[1]}");   // KP102
parcels.Remove("KP102");
Console.WriteLine($"Next parcel: {parcels[0]}");  // KP101
```

After the `Remove`, `parcels[1]` would be `KP103`.

### 4. Array or list?

| | Array `int[]` | List `List<int>` |
|---|---|---|
| Size | fixed when created | grows and shrinks |
| How many | `.Length` | `.Count` |
| Add / remove | ❌ | `.Add()` / `.Remove()` |
| Index | `[0]` … `[Length - 1]` | `[0]` … `[Count - 1]` |

**Rule:** use a list when the number of items **changes while the program runs**. Use an array when the size is fixed (7 days of the week, 12 months).

---

## 🎯 Dart comparison

```dart
// Dart
List<String> cities = [];
cities.add('Salmiya');
cities.remove('Salmiya');
print(cities.length);
for (var c in cities) { print(c); }
```
```csharp
// C#
List<string> cities = new List<string>();
cities.Add("Salmiya");
cities.Remove("Salmiya");
Console.WriteLine(cities.Count);
foreach (string c in cities) { Console.WriteLine(c); }
```

A Dart `List` is already growable, so C#'s `List<T>` will feel familiar. The differences are that C# method names start with a **capital letter** (`Add`, not `add`) and C# uses **`Count`** instead of `length`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| `First driver: {drivers.Count}` printed `2` | Copied the line above and didn't change the part inside `{ }` | Read the label: "First driver" asks for `drivers[0]` |
| Fixed the **wrong** line, so both lines were swapped | Changed "After remove" instead of "First driver" | Match each label to its code before saving |
| Output had 6 lines instead of 7 | Ran the program before saving the last line | Ctrl+S, then `dotnet run` |
| `$"Still waiting: 3: {parcels.Count}"` | A hand-typed `3` next to the real count | Only `{parcels.Count}`, so nothing is hard-coded |

✅ Wins: all three predictions were right, and reading `parcels[1]` before the `Remove` was a smart move.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| shopping bag | **`List<T>`** | "Use a `List<T>` when items get added or removed at runtime." |
| egg tray | **array** | "The size is fixed, so an array is fine here." |
| the `<string>` part | **type parameter** / **generic** | "It's a generic list of strings." |
| put in / take out | **`Add`** / **`Remove`** | "Remove the parcel once it's delivered." |
| how many in the bag | **count** | "Lists use `.Count`, arrays use `.Length`." |

---

## 📋 Summary

- `List<T>` is a generic, growable list: `new List<string>()`
- `.Add(x)` puts an item at the end, `.Remove(x)` takes it out, and later items move up
- `.Count` is the number of items (arrays use `.Length`)
- Indexes are zero-based: `[0]` to `[Count - 1]`
- Use a list when the number of items changes while the program runs

---

## 📝 Quiz

1. `List<int> stops` has 5, 8 and 2 added. What is `stops.Count`?
2. Arrays use `.Length`. What do lists use?
3. After `stops.Remove(8);`, what is `stops[1]`?
4. When should you use a `List<T>` and not an array?
5. What does `<int>` in `List<int>` mean?

<details>
<summary>Answers</summary>

1. `3`.
2. `.Count`.
3. `2`. The list is now 5, 2, so index 1 is 2.
4. When the number of items changes while the program runs (items get added or removed).
5. It's the **type parameter**: this list holds only `int` values. `List<T>` is a generic type.

</details>
