# Chapter 1.18: Method overloading (one name, many parameter lists)

> Learned: Tue 20 Oct 2026 · Code: `lessons/phase-01/28-print-label`, `lessons/phase-01/29-box-fee`

---

## 🧸 LKG story

**One "Send" button, different jobs.** At the KPOST counter there is one "Send" button. You can hand over **one parcel**, or **a parcel and a box count**. The staff looks at **what you hand over** and does the right job. You don't need a different button for each case.

That is overloading: **one method name**, and C# looks at **what you pass in** to decide which version runs.

🎬 **Animation idea:** a counter with two doors, both labelled `GetFee`. Door 1 accepts `(int boxes)` and Door 2 accepts `(int boxes, string city)`. You pick the arguments (`4`, or `4` + `"Jahra"`, or `4` + `"Hawalli"`) and press "Call". The arguments slide toward the door whose shape matches and light it up. Door 2 then calls Door 1 for the box fee and adds 3 KD for Jahra.

---

## 💻 Real explanation

### 1. Overloading = the same name, different parameters

```csharp
Labels.PrintLabel("Hawalli");
Labels.PrintLabel("Salmiya", 3);

static class Labels
{
    public static void PrintLabel(string city)
    {
        Console.WriteLine($"Delivery to {city}");
    }

    public static void PrintLabel(string city, int boxes)
    {
        Console.WriteLine($"Delivery {boxes} boxes to {city}");
    }
}
```
```
Delivery to Hawalli
Delivery 3 boxes to Salmiya
```

- The two methods differ in the **number** of parameters (1 vs 2)
- The name + the parameter list is called the **method signature**. Overloads need **different signatures**
- C# picks the overload that **matches the arguments**. This is called **overload resolution**. It does **not** pick by the order in the file

### 2. Overloads need a class (not top-level local functions)

In a file with no class (**top-level statements**), a method like `PrintLabel` is really a **local function**, and **local functions can't be overloaded**:

```
error CS0128: A local variable or function named 'PrintLabel' is already defined in this scope
error CS1501: No overload for method 'PrintLabel' takes 2 arguments
```

Fix: put the methods in a **`static class`**, write `public static` in front of each one, and call them as `Labels.PrintLabel(...)`. (Classes come properly in Phase 2.)

### 3. A different TYPE also counts

```csharp
Prices.Show(5);
Prices.Show(2.75);

static class Prices
{
    public static void Show(int amount)
    {
        Console.WriteLine($"Whole price: {amount} KD");
    }

    public static void Show(double amount)
    {
        Console.WriteLine($"Exact price: {amount} KD");
    }
}
```
```
Whole price: 5 KD
Exact price: 2.75 KD
```

`5` is an `int`, so C# calls `Show(int)`. `2.75` (and `7.0`) has a decimal point, so it's a `double` and C# calls `Show(double)`.

### 4. The return type does NOT count

```csharp
public static int Get(int x) { return x; }
public static double Get(int x) { return x; }   // ❌
```
```
error CS0111: Type 'Bad' already defines a member called 'Get' with the same parameter types
```

Both have the parameters `(int x)`. When you call `Get(3)`, C# can't tell which one you mean, because the **call looks the same**. Overloads must differ in **parameters** (count or types).

### 5. One overload can call another (DRY)

```csharp
Console.WriteLine(Fees.GetFee(4));
Console.WriteLine(Fees.GetFee(4, "Jahra"));
Console.WriteLine(Fees.GetFee(4, "Hawalli"));

static class Fees
{
    public static int GetFee(int boxes)
    {
        int fee = boxes * 2;
        return fee;
    }

    public static int GetFee(int boxes, string city)
    {
        int fee = GetFee(boxes);      // 1 argument → calls the first overload
        if (city == "Jahra")
        {
            return fee + 3;
        }
        else
        {
            return fee;
        }
    }
}
```
```
8
11
8
```

Trace of `GetFee(4, "Jahra")`:
1. 2 arguments, so **overload 2** runs first
2. `GetFee(boxes)` has 1 argument, so it calls **overload 1**, which returns `4 * 2 =` `8`
3. Back in overload 2: the city is Jahra, so it returns `8 + 3 =` `11`

`* 2` lives in **one place only**. If the price per box changes, you change one line.

---

## 🎯 Dart comparison

Dart has **no overloading**. Two functions can't share a name, so in Dart you would use two names or optional parameters:

```dart
int getFee(int boxes, [String? city]) {
  final fee = boxes * 2;
  return city == 'Jahra' ? fee + 3 : fee;
}
```

C# has both overloading **and** optional parameters (next chapter).

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| CS0128 + CS1501 on two `PrintLabel` methods | The first example (Claude's mistake) had no class, so they were local functions, which can't be overloaded | Put the methods in a `static class` with `public static` |
| Called it a "runtime error" | The program never started; the compiler stopped it | That's a **compile-time error** |
| Typed `Lables` (3 times) | It still ran because the spelling matched everywhere | Use **F2 rename** to fix every place at once |
| `boxes = boxes * 2;` | The variable called `boxes` then held a fee in KD: the name lies | Use a new local: `int fee = boxes * 2;` |
| `boxes * 2` written in both overloads | Duplicated logic | Overload 2 calls `GetFee(boxes)` |
| Quiz: "overloads must have the same return type" | Backwards | The return type is **ignored**; only the parameters count |
| Quiz: "it runs from top to bottom" | Thought C# picks by order in the file | C# picks the overload that **matches the arguments** |

✅ Wins: predicted the two `PrintLabel` lines and `Whole price: 10 KD` with the reason (`10` is an `int`); all paths of exercise 29 correct on the first try, with the `else` kept.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| same button, different jobs | **method overloading** | "`GetFee` has two overloads." |
| name + parameter list | **method signature** | "Two overloads can't have the same signature." |
| C# picks the matching one | **overload resolution** | "Overload resolution picked `Show(double)`." |
| only return type differs | **CS0111** | "Return type doesn't count, that's CS0111." |
| methods with no class | **local functions** | "Local functions can't be overloaded." |
| changing the parameter box | **reassigning a parameter** | "Don't reassign `boxes`, use a local `fee`." |
| same code twice | **duplicated logic / DRY** | "Call the other overload instead of repeating it." |
| didn't build | **compile-time error** | "It's a compile-time error, not a runtime one." |

---

## 📋 Summary

| Rule | Example |
|---|---|
| Same name, different **number** of parameters | `PrintLabel(city)` / `PrintLabel(city, boxes)` |
| Same name, different **types** | `Show(int)` / `Show(double)` |
| Return type alone ❌ | `int Get(int)` / `double Get(int)` → CS0111 |
| C# picks by **matching arguments** | `Show(7.0)` → `Show(double)` |
| Overloads go in a class | `static class Fees { public static int GetFee(...) }` |
| One overload can call another | `int fee = GetFee(boxes);` |

---

## 📝 Quiz

1. What is method overloading, in one sentence?
2. Can `int Total(int a, int b)` and `double Total(int a, int b)` live in the same class? Why?
3. Which overload does `Prices.Show(7.0)` call?
4. Why did two `PrintLabel` methods with no class give CS0128?
5. In `GetFee(4, "Jahra")`, which overload runs first, and which one does it call?

<details>
<summary>Answers</summary>

1. Several methods with the same name but different parameters (count or types); C# picks one by the arguments.
2. No. Their parameters are the same, and the return type doesn't count (CS0111).
3. `Show(double)`, because `7.0` has a decimal point.
4. Without a class they are local functions, and local functions can't be overloaded.
5. Overload 2 (two arguments) runs first; it calls overload 1 (`GetFee(boxes)`) for the box fee.

</details>
