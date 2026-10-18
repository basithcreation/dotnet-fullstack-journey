# Chapter 1.15: Methods, part 1 (void, parameters, return)

> Learned: Sun 18 Oct 2026 · Code: `lessons/phase-01/23-methods`, `lessons/phase-01/24-shipping-cost`

---

## 🧸 LKG story

**A method is "make tea".** Mum doesn't explain the boiling, the sugar and the milk every time. She says "make tea", and all the steps happen. "Make tea" is a **name** for a set of steps. Say the name three times, and all the steps happen three times.

🎬 **Animation idea:** a method box `PrintLabel` with its lines inside, and a list of calls next to it. Sliders set how many calls (1–5) and how many lines are in the body (1–4). Press "Run": a pointer jumps from each call into the box, runs every line (the terminal fills up), and jumps back. A counter at the end shows `calls × lines = total lines`.

**Parameters are empty cups. Arguments are what you pour in.** If you call "make tea **with 2 sugars**", the 2 goes into the method's `sugar` cup. Inside the method, you use the cup's **name** (`sugar`), not the name of the whole job.

🎬 **Animation idea:** the call `PrintReceipt("Salmiya", 2)` sits on top and the signature `void PrintReceipt(string city, double cost)` sits underneath. The arguments drop down into the matching parameter boxes. Below that, a pick: what goes in the `{ }`? Choosing `city` / `cost` prints `City: Salmiya` and `Shipping: 2 KD`. Choosing `PrintReceipt` prints `System.Action...`, and choosing the arguments in the wrong order shows a red CS1503.

**A return method is a brother sent to the shop.** A `void` method goes, does the job, and comes back with nothing. A method with a **return type** comes back **holding something**, like a juice or a number, and you can store it.

---

## 💻 Real explanation

### 1. A `void` method with one parameter

```csharp
PrintLabel("Salmiya");
PrintLabel("Jahra");
PrintLabel("Fahaheel");

void PrintLabel(string city)
{
    Console.WriteLine("----------");
    Console.WriteLine($"To: {city}");
}
```
```
----------
To: Salmiya
----------
To: Jahra
----------
To: Fahaheel
```

- You **define** the method once (at the bottom of `Program.cs`) and **call** it by name
- `void` means "does a job, gives nothing back"
- `string city` is a **parameter**: an input box. `"Salmiya"` is the **argument**: the value that goes into the box
- Every call runs the **whole method body**: 3 calls × 2 lines = **6 lines**, not 4
- C# method names use **PascalCase**: `PrintLabel`

### 2. A method that returns a value

```csharp
double total = AddDeliveryFee(4.0);
Console.WriteLine($"Total: {total} KD");
Console.WriteLine($"Big order: {AddDeliveryFee(10.0)} KD");

double AddDeliveryFee(double price)
{
    double fee = 1.5;
    return price + fee;
}
```
```
Total: 5.5 KD
Big order: 11.5 KD
```

- The **return type** (`double`) replaces `void`
- `return price + fee;` sends the result back to the line that called it, and the method stops there
- You can **store** the return value (`double total = ...`) or use it straight away inside `{ }`

### 3. More than one parameter

```csharp
void PrintStop(string driver, int stopNumber)
{
    Console.WriteLine($"{driver} → stop {stopNumber}");
}

PrintStop("Ali", 3);
PrintStop("Ravi", 12);
```
```
Ali → stop 3
Ravi → stop 12
```

Put commas between the parameters and give each one its own type. The arguments go in the **same order**: `PrintStop(3, "Ali")` is a compile error (**CS1503**).

### 4. One method, one job

```csharp
double salmiyaCost = CalculateShipping(4);
PrintReceipt("Salmiya", salmiyaCost);

double jahraCost = CalculateShipping(10);
PrintReceipt("Jahra", jahraCost);

double CalculateShipping(double weightKg)
{
    double fee = 0.5;            // 0.5 KD per kg
    return weightKg * fee;
}

void PrintReceipt(string city, double cost)
{
    Console.WriteLine($"City: {city}");
    Console.WriteLine($"Shipping: {cost} KD");
}
```
```
City: Salmiya
Shipping: 2 KD
City: Jahra
Shipping: 5 KD
```

- `CalculateShipping` turns a **weight** into a **price** (4 × 0.5 = 2). It never prints
- `PrintReceipt` only **shows** what it's given, using its own parameters `city` and `cost`
- At the top: calculate, store, then pass the result on. This is called **single responsibility**

How the values travel:

```
PrintReceipt( "Salmiya" , salmiyaCost )      ← the call (arguments)
                  ↓            ↓
void PrintReceipt(string city, double cost)  ← the signature (parameters)
```

---

## 🎯 Dart comparison

```dart
// Dart
void printLabel(String city) { print('To: $city'); }
double addDeliveryFee(double price) { return price + 1.5; }
```
```csharp
// C#
void PrintLabel(string city) { Console.WriteLine($"To: {city}"); }
double AddDeliveryFee(double price) { return price + 1.5; }
```

They're almost the same. The differences: C# uses **PascalCase** names (`PrintLabel`), lowercase `string`, and `Console.WriteLine` instead of `print`.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Predicted 4 lines for 3 `PrintLabel` calls | Thought the dashes print only once | Every call runs the **whole** body: 3 × 2 = 6 |
| `return weightKg + fee;` for "0.5 KD per kg" | "Per kg" means multiply, not add | `return weightKg * fee;` |
| Wrote `weightKg , fee` | Didn't know the multiply sign | `*` is multiply in C# and Dart (`+ - * /`) |
| `{CalculateShipping}` / `{PrintReceipt}` printed `System.Action...` | Wrote the **method name** inside `{ }` | Use the **parameter names**: `{city}`, `{cost}` |
| `PrintReceipt("Salmiya", 4)` + warning CS8321 | Passed the weight as the cost, so `CalculateShipping` was never called | Calculate first: `double cost = CalculateShipping(4);` then pass `cost` |
| `Totol` | Typo | Read the output before saying done |

✅ Win: asking "then what is the use of CalculateShipping?" was exactly the right question. It led to the "one method, one job" step.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| "make tea" | **method** | "Extract that repeated code into a method." |
| say the name | **call** / **invoke** | "Call `PrintReceipt` once per parcel." |
| the steps inside `{ }` | **method body** | "Every call executes the whole method body." |
| brings nothing back | **`void`** | "It's a void method, it only prints." |
| comes back holding something | **return value** / **return type** | "The method returns a `double`." |
| empty cup | **parameter** | "The method takes two parameters." |
| what you pour in | **argument** | "Pass the arguments in the right order." |
| first line of a method | **method signature** | "The signature is `double CalculateShipping(double weightKg)`." |
| one method, one job | **single responsibility** | "Keep calculation and printing in separate methods." |
| a method in Program.cs | **local function** (CS8321 = never used) | "The local function is never called." |

---

## 📋 Summary

- A method is a named block of code: define once, call many times. Each call runs the whole body
- `void` = no result; a return type + `return x;` = sends a value back and stops the method
- Parameters are the boxes in the signature; arguments fill them, in the same order
- Inside the method, use the **parameter names**
- One method, one job: calculate in one, print in another

---

## 📝 Quiz

1. What is the difference between a `void` method and a `double` method?
2. In `PrintStop("Ali", 3)`, which are the arguments? In `void PrintStop(string driver, int stopNumber)`, which are the parameters?
3. Inside `PrintReceipt(string city, double cost)`, what does `Console.WriteLine($"City: {city}");` print for the call `PrintReceipt("Jahra", 5)`?
4. What happens with `PrintStop(3, "Ali")`?
5. Why is it better to have `CalculateShipping` and `PrintReceipt` as two methods instead of one?

<details>
<summary>Answers</summary>

1. A `void` method does a job and gives nothing back. A `double` method must `return` a `double`, which the caller can store or use.
2. Arguments: `"Ali"` and `3`. Parameters: `driver` and `stopNumber`.
3. `City: Jahra`.
4. A compile error (CS1503): the first parameter needs a `string`, but it got an `int`.
5. Each method has one job (single responsibility). You can reuse the calculation without printing, and change the receipt without touching the maths.

</details>
