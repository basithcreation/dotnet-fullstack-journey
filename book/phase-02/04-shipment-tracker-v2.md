# Chapter 2.4: Shipment Tracker v2 (one list of objects, a find method, reference types)

> Built: Sat 31 Oct 2026 · Code: `projects/03-shipment-tracker` · Built on the branch `feature/shipment-class`, then merged into `main`

---

## 🧸 LKG story

**Four notebooks vs one folder of forms.** In v1 (Chapter 1.25), the office kept **4 notebooks**: one for tracking numbers, one for names, one for statuses, one for times. Shipment KP1002 was "page 2" in every notebook. If one notebook got a page out of order, every shipment after it was wrong.

In v2 the office uses **one shipment form per parcel**, and all the forms sit in **one folder**. Each form carries all its own boxes. To find a shipment, the clerk flips through the folder, form by form, and hands you **the real form**, not a photocopy. If you write "Delivered" on it, the form in the folder now says "Delivered".

| Story | C# |
|---|---|
| 4 notebooks, same page number | **parallel lists** (v1) |
| one shipment form | a `Shipment` **class** / one **object** |
| the folder of forms | `List<Shipment>` |
| flip through the folder | a **linear search** with `foreach` |
| hands you the real form, not a copy | **reference type**: the variable points to the same object |

🎬 **Animation idea:** a folder with 3 shipment forms (KP1001, KP1002, KP1003). Pick a number to search for and press Search: a pointer moves form by form, showing `false` or `true` for each one. On a match it says "return: leave the method", and the remaining forms are never checked. With no match it reaches the end and shows the red `throw`. Then press "Mark delivered": the found form changes in the folder, because the variable points to the same form.

---

## 💻 Real explanation

### 1. The class

```csharp
class Shipment
{
    public required string Number { get; init; }
    public required string Receiver { get; init; }
    public string Status { get; set; } = "In transit";
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}
```

- `Number` and `Receiver`: must be given at creation (`required`), then locked (`init`)
- `Status`: `set`, because it changes to "Delivered" later
- **Default values** (`= "In transit"`, `= DateTime.Now`) fill themselves in, so "Add" only gives the number and the name

### 2. Add: fill a form and put it in the folder

```csharp
List<Shipment> shipments = new List<Shipment>();

string number = $"KP{1001 + shipments.Count}";
string receiver = "Ali";
Shipment s = new Shipment { Number = number, Receiver = receiver };
shipments.Add(s);
```

### 3. List: `foreach` instead of `for`

v1 needed `for (int i = 0; ...)`, because `i` was the page number in all 4 notebooks. Now each object has all its boxes, so `foreach` is enough:

```csharp
foreach (Shipment shipment in shipments)
{
    Console.WriteLine($"{shipment.Number} | {shipment.Receiver} | {shipment.Status}");
}
```
```
KP1001 | Ali | In transit
KP1002 | Sara | In transit
```

**Why `shipment`, not `s`?** All the `case` blocks in one `switch` share **one scope**. Case 1 already had a variable `s`, so a second `s` would clash.

### 4. One find method for Search and Mark delivered

```csharp
static Shipment FindShipment(List<Shipment> list, string number)
{
    foreach (Shipment shipment in list)
    {
        if (shipment.Number == number)
        {
            return shipment;
        }
    }
    throw new ArgumentException($"Shipment {number} not found");
}
```

- The **return type** is a class: the method gives back a whole `Shipment`
- `return` inside the loop stops the loop **and** leaves the method straight away
- The `throw` is **after** the loop, so it only runs when no shipment matched

Trace: searching **KP1002** in KP1001, KP1002, KP1003:

| Round | `shipment.Number` | `== "KP1002"`? | What happens |
|---|---|---|---|
| 1 | KP1001 | false | next round |
| 2 | KP1002 | true | `return shipment` → leave the method |
| 3 | (never runs) | | |

### 5. Reference types: you get the real form

```csharp
Shipment toDeliver = FindShipment(shipments, "KP1001");
toDeliver.Status = "Delivered";
```

`toDeliver` is not a copy. It **points to** the same object that is inside the list. So the list now shows:

```
KP1001 | Ali | Delivered
```

A class is a **reference type**: the variable holds a "pointer" to the object, not the object itself.

### 6. The branch workflow

```
git switch -c feature/shipment-class
(6 small commits, one per step)
git switch main
git merge feature/shipment-class     → Fast-forward
git push
git branch -d feature/shipment-class
```

`Fast-forward` means `main` hadn't changed since the branch was made, so Git just moved `main` forward to the last commit.

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `List<Shipment> shipments = [];` | `List<Shipment> shipments = new List<Shipment>();` |
| `for (final s in shipments) { }` | `foreach (Shipment s in shipments) { }` |
| `Shipment find(...) { ... throw ArgumentError(...); }` | `static Shipment FindShipment(...) { ... throw new ArgumentException(...); }` |
| class objects are references | class objects are **reference types** too |

Dart and C# behave the same here: when you pass or return an object, both point to the same object.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Class named `Shipmwnt` | a typo, and the build still passed (any name is valid) | read names carefully; the next step would have failed |
| `CreatedAt` lost `= DateTime.Now` | dropped the end of the line | without a default it shows `01 Jan 0001` |
| `git add Program.cs` from the root folder (3 times) | the path is relative to the folder you're in | commit from the root with the full path: `git add projects/03-shipment-tracker/Program.cs` |
| Old case 1 left as `//` comments | the commenting-out habit | delete it, Git keeps the old version |
| `throw` **inside** the `foreach` → **CS0161** "not all code paths return a value" | the throw ran on round 1, and an empty list reached the end with no return | move the `throw` below the loop's `}` |
| Pasted `{found.Number}` into `default:` → **CS0165** "use of unassigned local variable" | `found` only gets a value in case 3 | put `default` back to `"Unknown choice"` |
| Skipped steps in a list: the `4 → kp1001` input, the `3` before `KP9999`, `switch` + `merge` before `push` | read the list too fast | do the steps in order, one at a time |

✅ Wins: all the blanks were right first time (`required`/`init`/`set`, the initializer, `FindShipment(shipments, ...)`, `toDeliver.Status`); a perfect trace of `return` inside the loop; no dead code left; 84 clean lines (from 93); the full branch workflow.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| 4 notebooks → 1 folder | **replace parallel lists with a list of objects** | "We replaced the parallel lists with a single `List<Shipment>`." |
| one method for both cases | **extract a helper method** | "I extracted the lookup into a helper so both cases reuse it." |
| flip form by form | **linear search** | "It's a linear search, fine for a small list." |
| you get the real form | **reference type** | "Classes are reference types, so updating the returned object updates the one in the list." |
| a path with no return | **CS0161** | "CS0161: the method can reach the end without returning." |
| a variable with no value yet | **CS0165** | "`found` is unassigned on the default path." |
| `main` just moves forward | **fast-forward merge** | "It was a fast-forward, no merge commit." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| a list of objects | `List<Shipment> shipments = new List<Shipment>();` |
| add an object | `shipments.Add(new Shipment { Number = n, Receiver = r });` |
| loop over objects | `foreach (Shipment s in shipments) { ... s.Number ... }` |
| find one object or fail | `return` inside the loop, `throw` after it |
| change the found object | `found.Status = "Delivered";` (it changes in the list too) |

---

## 📝 Quiz

1. Why is `foreach` enough in v2, when v1 needed `for` with `i`?
2. A method's last line is `throw`, after a `foreach` that has `return` inside. Searching for the **1st** item: how many rounds run?
3. What does CS0161 mean?
4. `Shipment a = FindShipment(list, "KP1001"); a.Status = "Delivered";`. Does the shipment **inside the list** change? Why?
5. What does `Fast-forward` mean in a merge?

<details>
<summary>Answers</summary>

1. Each object carries all its own boxes, so you don't need a page number to look in 4 lists.
2. **1 round**: it matches, and `return` leaves the method.
3. "Not all code paths return a value": some path reaches the end of the method without `return` or `throw`.
4. **Yes.** A class is a reference type, so `a` points to the same object as the list.
5. `main` had no new commits, so Git just moved `main` forward to the branch's last commit.

</details>
