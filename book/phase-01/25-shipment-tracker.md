# Chapter 1.25: Project 03 Shipment Tracker (parallel lists, `IndexOf`, and a method that throws)

> Built: Sat 24 Oct 2026 · Code: `projects/03-shipment-tracker` · The last project of Phase 1

---

## 🧸 LKG story

**Four notebooks on one desk.** The courier office keeps 4 notebooks: tracking numbers, receiver names, statuses and dates. One shipment is written on **the same line number** in all 4 notebooks. To find Sara's parcel, you look up her tracking number in the first notebook, see it's on line 1, then read line 1 in the other 3 notebooks.

It works, but it's fragile: if someone forgets to write in one notebook, every line after it is wrong. (Phase 2 fixes this with a **class**: one card per shipment with all 4 facts on it.)

🎬 **Animation idea:** 4 notebooks side by side. Press "Add" and a new row appears in all 4 at the same index, with an auto-generated `KP100x` number. Type a tracking number in the search box: a finger runs down the first notebook (`IndexOf`), stops at the index (or shows `-1`), and the same row lights up in the other 3. A switch changes the check from `index == -1` to `index <= 0`, so you can watch the first shipment wrongly say "not found".

---

## 💻 What the app does

```
=== KPOST Shipment Tracker ===
 1) Add 2) List 3) Search 4) Mark delivered q) Quit

Choose: 1
Receiver name: Omar
Added KP1001
 1) Add 2) List 3) Search 4) Mark delivered q) Quit

Choose: 4
Tracking number: kp1001
KP1001 marked as delivered
 1) Add 2) List 3) Search 4) Mark delivered q) Quit

Choose: 2
KP1001 | Omar | Delivered | 24 Oct 2026 20:52
 1) Add 2) List 3) Search 4) Mark delivered q) Quit

Choose: 4
Tracking number: kp5555
Error: Shipment KP5555 not found
```

93 lines, using every Phase 1 tool: a `while` loop, `switch`, `List<T>`, a `for` loop with an index, a method, string helpers, `??`, `DateTime`, and `throw` + `try` / `catch`.

### Step 1: 4 lists and the menu

```csharp
List<string> numbers = new List<string>();
List<string> receivers = new List<string>();
List<string> statuses = new List<string>();
List<DateTime> createdTimes = new List<DateTime>();
```

- `List<string> numbers;` only **declares** the name. With no `= new List<string>()` there is no list behind it, and the first `Add` fails with **CS0165: Use of unassigned local variable**. The yellow warning **CS0168: declared but never used** was the early hint
- The pattern: `TYPE name = new TYPE();` (the type is written twice)

The menu choice is cleaned in one line:

```csharp
string choice = (Console.ReadLine() ?? "").Trim().ToLower();
```

`Console.ReadLine()` returns a `string?`, `?? ""` turns null into an empty string, then `Trim` and `ToLower`, so `Q` works like `q`. After `?? ""` it can never be null, so the type is `string`, not `string?`.

### Step 2: add, with an auto-generated ID

```csharp
string number = $"KP{1001 + numbers.Count}";
```

| Shipments already saved | `numbers.Count` | New number |
|---|---|---|
| none | 0 | KP1001 |
| 1 | 1 | KP1002 |

Then one `Add` per list, so the new shipment gets the same index everywhere. The time comes from `DateTime.Now`.

### Step 3: list, with `for` (not `foreach`)

```csharp
for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine($"{numbers[i]} | {receivers[i]} | {statuses[i]} | {createdTimes[i].ToString("dd MMM yyyy HH:mm")}");
}
```

We need the **same index** in all 4 lists, so we need `i`, and `foreach` has no index. Rule: **need the index → `for`**.

My first version was `for (int i = numbers.Count; i <= 2; i++)` with `[0]` inside. A trace showed 3 problems: start at **0**, stop at **`numbers.Count`** (not a fixed `2`), and use **`[i]`** (not `[0]`).

### Step 4: search with `IndexOf`

```csharp
List<string> fruits = new List<string>();
fruits.Add("apple");
fruits.Add("mango");
Console.WriteLine(fruits.IndexOf("mango"));   // 1
Console.WriteLine(fruits.IndexOf("grape"));   // -1
```

`IndexOf` gives the index, or **`-1`** when it's not there (`-1` can never be a real index). It's case-sensitive, so the input is cleaned with `Trim().ToUpper()`, and `kp1002` finds `KP1002`.

**The off-by-one bug:** I first wrote `if (index <= 0)` for "not found". The test with KP1002 passed, but a test with **KP1001** (index 0) said "not found". Index 0 is a valid index! Fix: `index < 0` (or, clearer, `index == -1`). Always test the **first** and the **last** item.

### Step 5: mark delivered, with a method that throws

"Mark delivered" needs the same search again, so the search moved into a method:

```csharp
static int FindIndex(List<string> list, string number)
{
    int found = list.IndexOf(number);
    if (found == -1)
    {
        throw new ArgumentException($"Shipment {number} not found");
    }
    return found;
}
```

- A `static` method can't see the lists at the top of the file, so the list is **passed in as a parameter**
- The `switch` is wrapped in `try` / `catch (ArgumentException ex)`, so a wrong number prints `Error: ...` and the menu carries on instead of crashing
- All the `case` blocks share **one scope**, so case 4 uses new names (`deliverNumber`, `deliverIndex`). Reusing `index` from case 3 would be **CS0128**

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `List<String> numbers = [];` | `List<string> numbers = new List<string>();` |
| `numbers.indexOf('KP1001')` → `-1` if missing | `numbers.IndexOf("KP1001")` → `-1` if missing |
| `stdin.readLineSync() ?? ''` | `Console.ReadLine() ?? ""` |
| `for (var i = 0; i < list.length; i++)` | `for (int i = 0; i < list.Count; i++)` |

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| `List<string> numbers;` with no `new` | Declared the name only | `= new List<string>();` (warning CS0168 was the hint) |
| `new {""}` | Didn't know what goes after `new` | The type again + `()`: `new List<string>()` |
| `string? choice` after `?? ""` | Copied the `?` from `ReadLine` | It can't be null any more, so `string` |
| Forgot to print `Added KP1001` | Missed one task out of four | Compare the output with the expected output line by line |
| `for (int i = numbers.Count; i <= 2; i++)` + `[0]` | Start, stop and row were all fixed values | `i = 0`, `i < numbers.Count`, `[i]` |
| `if (index <= 0)` | Off-by-one: 0 is a real index | `index == -1` (or `< 0`) |
| Committed the README but not `Program.cs` | Didn't check the "files changed" number | Read the commit summary: is it the number I expected? |

✅ Wins: tested on my own and fixed the out-of-range crash; found the `<= 0` bug with one test; `FindIndex` + `try` / `catch` worked first time; the app never crashes on a wrong number.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| 4 notebooks, same line | **parallel lists** (or arrays) | "Parallel lists are fragile, let's make a `Shipment` class." |
| KP1001, KP1002, ... | **auto-generated ID** | "The tracking number is auto-generated from the count." |
| name only, no list yet | **declared but not initialized** | "You declared it but never initialized it, add `new List<string>()`." |
| `-1` = not there | **sentinel value** | "`IndexOf` returns the sentinel -1 when the item isn't found." |
| wrong by one at the edge | **off-by-one error** | "Classic off-by-one, index 0 is valid." |
| the answer I want to see | **expected output** vs **actual output** | "The actual output is missing the 'Added' line." |
| test the first and last | **edge cases** / **boundary values** | "Test the edge cases: the first and the last shipment." |

---

## 📋 Summary

| Need | Tool |
|---|---|
| store many shipments | 4 `List<T>`s, one shipment = one index |
| a new tracking number | `$"KP{1001 + numbers.Count}"` |
| print every row from all 4 lists | `for` with `i` |
| find a tracking number | `IndexOf` → index or `-1` |
| the same search in two places | a method (`FindIndex`) |
| a wrong number shouldn't crash the app | the method throws, the loop catches |

---

## 📝 Quiz

1. Why does the List menu use `for` instead of `foreach`?
2. What does `IndexOf` return when the item isn't in the list?
3. Why was `if (index <= 0)` a bug? Which test found it?
4. `List<string> numbers;` then `numbers.Add("KP1001");`. What's wrong?
5. Why are 4 parallel lists fragile?

<details>
<summary>Answers</summary>

1. We need the same index `i` in all 4 lists, and `foreach` has no index.
2. `-1`
3. Index 0 is a real index (the first shipment), so the first shipment was reported "not found". Searching for KP1001 found it.
4. The list was only declared, never created. It needs `= new List<string>();` (otherwise error CS0165).
5. One shipment is spread over 4 lists. If one `Add` is forgotten or one list is sorted, the indexes no longer line up and the data gets mixed up. A class keeps all the facts of one shipment together.

</details>
