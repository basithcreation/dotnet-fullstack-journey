# Chapter 1.19: Optional and named parameters

> Learned: Wed 21 Oct 2026 · Code: `lessons/phase-01/30-delivery-days`

---

## 🧸 LKG story

**The tea shop.** At the tea shop, tea comes with **1 spoon of sugar** unless you ask for more. You can just say "Tea for Ali" and you get 1 spoon. Or you say "Tea for Sara, 3 spoons."

That is an **optional parameter**: the method has a **default value**, and the caller only gives a value when they want something different.

**Saying the label.** You can also say "**sugar:** 2, **name:** Omar". Because you said the label, the order doesn't matter. That is a **named argument**.

🎬 **Animation idea:** the method `PrintDelivery(string city, int days = 2)` has two slots: `city` and `days` (with a grey "2" already sitting in it). You pick a call. The arguments fly into the slots: by **position** (first value → first slot) or by **label** (`days: 5` flies straight to the `days` slot, even when it is written first). An empty `days` slot keeps the grey default. A wrong call (`days` without a `city`) flashes red with the error code.

---

## 💻 Real explanation

### 1. Optional parameter = a parameter with a default value

```csharp
Shop.PrintReceipt("Ali");
Shop.PrintReceipt("Sara", 3);

static class Shop
{
    public static void PrintReceipt(string name, int copies = 1)
    {
        Console.WriteLine($"Receipt for {name}: {copies} copy");
    }
}
```
```
Receipt for Ali: 1 copy
Receipt for Sara: 3 copy
```

- `int copies = 1` means: "if nobody passes `copies`, use `1`"
- `name` has no default, so it is a **required parameter**
- The default value is written in the **method header** (line 1 of the method)

### 2. Named arguments = pass a value by its parameter name

```csharp
Shop.PrintReceipt(copies: 2, name: "Omar");
```
```
Receipt for Omar: 2 copy
```

- `copies:` and `name:` are the **parameter names** from the method header
- C# matches each value by its **name**, so the order doesn't matter
- Normal arguments are **positional arguments**: matched by their **place** (first value → first parameter)
- Named arguments are written at the **call site** (the line that calls the method)

### 3. Rule: optional parameters come LAST

```csharp
public static void PrintReceipt(int copies = 1, string name)   // ❌
```
```
error CS1737: Optional parameters must appear after all required parameters
```

Why: in `PrintReceipt("Omar")`, C# fills parameters from the left. If the optional `copies` came first, C# couldn't tell where `"Omar"` should go.

Valid (one required, then two optional):

```csharp
public static void SendSms(string phone, string text = "Your parcel is ready", int tries = 3)
```

### 4. You still must pass every required parameter

```csharp
public static void Pack(string item, int boxes = 1) { ... }

Store.Pack();   // ❌
```
```
error CS7036: There is no argument given that corresponds to the required parameter 'item' of 'Store.Pack(string, int)'
```

### 5. My exercise: delivery days

```csharp
Courier.PrintDelivery("Jahra");
Courier.PrintDelivery("Salmiya", 1);
Courier.PrintDelivery(days: 5, city: "Hawalli");

static class Courier
{
    public static void PrintDelivery(string city, int days = 2)
    {
        Console.WriteLine($"Delivery to {city} in {days} days");
    }
}
```
```
Delivery to Jahra in 2 days
Delivery to Salmiya in 1 days
Delivery to Hawalli in 5 days
```

1. Only the city → `days` uses its default `2`
2. Positional → `1` replaces the default
3. Named → order reversed, still correct

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `void printReceipt(String name, [int copies = 1])` | `void PrintReceipt(string name, int copies = 1)` |
| `void printReceipt({required String name, int copies = 1})` | the **same** C# method, the caller just writes names |
| Named params are decided by the **function** (`{ }`) | Named args are decided by the **caller** |
| `printReceipt(name: 'Omar', copies: 2)` | `PrintReceipt(name: "Omar", copies: 2)` |

In C# you don't mark anything special in the method. **Any** parameter can be passed by name.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Quiz: only said `item` is required | Forgot the other half of the question | Also say: `boxes` is optional, default `1` |
| Quiz: mixed up where the default and the name go | Didn't know the words "method header" and "call site" | Default → **method header**. Name → **call** |
| Predicted `Deliver to...`, code printed `Delivery to...` | Predicted from the task text, not from my own code | Read the exact text in the quotes before predicting |
| Typed the first example into an old exercise (`29-box-fee`) | Wanted a quick place to try it | Fine, but don't commit it; `git restore <file>` brings the committed version back |

✅ Wins: predicted the default (`1 copy`) and the named-argument line right; understood by myself that named arguments don't need the order; exercise 30 correct on all 3 calls on the first try.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| "1 sugar unless you ask" | **optional parameter** / **default value** | "Make `days` optional with a default of 2." |
| must always be passed | **required parameter** | "`city` is required, so it comes first." |
| optional before required | **CS1737** | "Optional parameters go last, that's CS1737." |
| forgot a required one | **CS7036** | "`Pack()` gives CS7036, `item` is required." |
| matched by its place | **positional argument** | "Positional arguments follow the parameter order." |
| "sugar: 2" with a label | **named argument** | "Pass `days` as a named argument so it's readable." |
| line 1 of the method | **method header** | "The default lives in the method header." |
| the line that uses it | **call site** | "At the call site we pass `city:`." |

---

## 📋 Summary

| Rule | Example |
|---|---|
| Default value in the header | `int days = 2` |
| Leave it out → default is used | `PrintDelivery("Jahra")` → 2 days |
| Pass it → default is replaced | `PrintDelivery("Salmiya", 1)` |
| Named argument → any order | `PrintDelivery(days: 5, city: "Hawalli")` |
| Optional parameters go **last** | otherwise CS1737 |
| Required parameters must be passed | `Pack()` → CS7036 |

---

## 📝 Quiz

1. In `Pack(string item, int boxes = 1)`, which parameter is required, which is optional, and what is the default?
2. Is `void Pay(double amount = 5, string user)` valid? Why?
3. What does `Store.Pack(boxes: 4, item: "Shoes");` print (`$"{item}: {boxes} box"`)?
4. Where is a default value written, and where is a named argument written?
5. What happens with `Store.Pack();`?

<details>
<summary>Answers</summary>

1. `item` is required; `boxes` is optional with default `1`.
2. No. CS1737: optional parameters must come after all required ones.
3. `Shoes: 4 box`. Named arguments are matched by name, not order.
4. Default value → in the **method header**. Named argument → in the **call**.
5. Compile error CS7036: the required parameter `item` has no argument.

</details>
