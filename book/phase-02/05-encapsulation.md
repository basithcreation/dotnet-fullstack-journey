# Chapter 2.5: Access modifiers and encapsulation (`public`, `private set`, safe doors)

> Learned: Sat 31 Oct 2026 · Code: `lessons/phase-02/04-encapsulation`

---

## 🧸 LKG story

**The courier's locked cash box.** Every KPOST courier collects cash-on-delivery money in a **locked box**. The courier can't open it and write any number they like. There's only a **slot** on top: you put money in, and the box checks it first. Anyone can **look** at the total on the little screen, but only the box itself can **change** it. To take money out, you ask the box, and it answers **yes** or **no**.

| Story | C# |
|---|---|
| the locked inside | **`private`**: only code inside the class can use it |
| the screen anyone can read | **`public`**: any code can use it |
| read the screen, but not write on it | **`{ get; private set; }`** |
| the slot that checks the money | a public method with a **validation** (`Deposit`) |
| "can I take 5 KD?" → yes / no | a method that returns **`bool`** (`Withdraw`) |
| the whole idea | **encapsulation** |

🎬 **Animation idea:** a cash box with a balance screen. Buttons: "Deposit 20.5", "Deposit -500", "Withdraw 5", "Withdraw 100" and "box.Balance = -500 (from outside)". A switch flips the setter between `set` and `private set`. With `set`, the outside line works and the screen shows a broken -500 KD. With `private set`, it shows the red **CS0272** error, and only the doors with rules can change the balance.

---

## 💻 Real explanation

### 1. The problem: a public setter lets anyone break the data

```csharp
CashBox box = new CashBox();
box.Balance = 20.5m;
Console.WriteLine($"Balance: {box.Balance} KD");

box.Balance = -500;
Console.WriteLine($"Balance: {box.Balance} KD");

class CashBox
{
    public decimal Balance { get; set; }
}
```
```
Balance: 20.5 KD
Balance: -500 KD
```

A cash box at -500 KD makes no sense, but nothing stopped it. (`20.5m`: the `m` makes the number a `decimal`, the type for money.)

### 2. Access modifiers

| Modifier | Who can use it |
|---|---|
| `public` | any code |
| `private` | only code **inside the same class** |
| `protected` | the class and its children (comes with inheritance) |
| `internal` | code in the same project |

A property can have a **different modifier on its setter**: `{ get; private set; }` = anyone can read it, only the class can change it.

### 3. The fix: lock the setter and add doors with rules

```csharp
CashBox box = new CashBox();
box.Deposit(20.5m);
Console.WriteLine($"Balance: {box.Balance} KD");

box.Deposit(-500);
Console.WriteLine($"Balance: {box.Balance} KD");

class CashBox
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit must be more than 0");
            return;
        }
        Balance = Balance + amount;
    }
}
```
```
Balance: 20.5 KD
Deposit must be more than 0
Balance: 20.5 KD
```

The `return;` is a **guard clause**: a bad value leaves the method early, before the balance changes.

Trying to write from outside now fails to compile:

```csharp
box.Balance = -500;
```
```
error CS0272: The property or indexer 'CashBox.Balance' cannot be used in this context because the set accessor is inaccessible
```

### 4. A door that answers yes or no

```csharp
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            return false;
        }
        Balance = Balance - amount;
        return true;
    }
```
```csharp
if (box.Withdraw(5))   { Console.WriteLine($"Paid 5 KD. Balance: {box.Balance} KD"); }
else                   { Console.WriteLine("Withdraw failed"); }

if (box.Withdraw(100)) { Console.WriteLine($"Paid 100 KD. Balance: {box.Balance} KD"); }
else                   { Console.WriteLine("Withdraw failed"); }
```
```
Paid 5 KD. Balance: 15.5 KD
Withdraw failed
```

For `Withdraw(100)`, write out both sides of the `||`: `100 <= 0` is **false**; `100 > 15.5` is **true**. `false || true` = **true**, so it returns `false`.

### 5. The exercise: a protected `Parcel`

```csharp
class Parcel
{
    public required string Number { get; init; }
    public double Weight { get; private set; }
    public string Status { get; private set; } = "In transit";

    public bool SetWeight(double kg)
    {
        if (kg <= 0 || kg > 30)
        {
            return false;
        }
        Weight = kg;
        return true;
    }

    public bool MarkDelivered()
    {
        if (Status == "Delivered")
        {
            return false;
        }
        Status = "Delivered";
        return true;
    }
}
```
```
KP2001 | 0 kg | In transit
Weight set: 2.5 kg
Weight rejected: 50 kg
Delivered!
Already delivered
KP2001 | 2.5 kg | Delivered
```

**Why "rejected: 50" can't print `parcel.Weight`:** `SetWeight(50)` returned `false` before `Weight = kg;`, so `Weight` is still **2.5**. The lock worked, so the message must show the number you **tried**.

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `double _balance = 0;` (underscore = private) | `private decimal balance;` (a keyword) |
| `double get balance => _balance;` (public getter only) | `public decimal Balance { get; private set; }` |
| `void deposit(double amount) { if (amount <= 0) return; _balance += amount; }` | `public void Deposit(decimal amount) { ... }` |

Same idea, different spelling: Dart uses an **underscore**, C# uses the **`private` keyword**.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Named the method `Deposite`, message `more then 0` | spelling; a method name is part of the class's public API | **F2** (rename symbol) renames every use; "more **than**" for comparing |
| `Number { get; private init; }` | locked it so tightly that even the initializer couldn't fill it | `required` + `init` |
| `Weight = Weight + kg;` | added like an accumulator | setting a value **replaces** it: `Weight = kg;` (2.5 then 3 gave 5.5 instead of 3) |
| Printed the words `"Number \| Weight kg \| Status"` | no `$` and no `{ }` | `$"{parcel.Number} \| {parcel.Weight} kg \| {parcel.Status}"` |
| Dropped ` kg` (4th time a unit went missing) | | compare whole lines with the expected output |
| Left an old `parcel.MarkDelivered();` line | the silent call ran first, so the `if` printed "Already delivered" | delete it; one `if` block per call |
| Couldn't finish `100 > 20.5 - 5` | mental maths | write it out: `20.5 - 5 = 15.5`, check with `15.5 + 5 = 20.5` |

✅ Wins: whole-line guesses for both cash box runs; `private set` on both properties and a correct `MarkDelivered` without help; understood why a silent call changed the output.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| the locked inside | **`private`** | "Make that field private, nothing outside needs it." |
| open to everyone | **`public`** | "Only the methods are public, the data isn't." |
| read but not write | **private setter** (`{ get; private set; }`) | "`Balance` has a private setter, so it only changes through `Deposit`." |
| the doors of the class | **public API** / **public surface** | "Keep the public API small." |
| check before saving | **validation** | "`SetWeight` validates the range before saving." |
| the whole idea | **encapsulation** | "Encapsulation means the class protects its own data." |
| writing a locked setter | **CS0272** | "CS0272: the setter is inaccessible, use the method." |
| F2 | **rename symbol** | "Use F2 so every reference is renamed." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| anyone can read, only the class can change | `public decimal Balance { get; private set; }` |
| change through a door with a rule | `public void Deposit(decimal amount) { if (amount <= 0) return; ... }` |
| a door that says yes/no | `public bool Withdraw(decimal amount) { ... return true; }` |
| use the yes/no | `if (box.Withdraw(5)) { ... } else { ... }` |
| a `decimal` number | `20.5m` |

---

## 📝 Quiz

1. What is the difference between `public` and `private`?
2. A class has `public int Count { get; private set; }`. Outside the class you write `c.Count = 5;`. Does it compile? If not, which error code?
3. What is encapsulation, in one sentence?
4. `SetWeight(40)` with the rule `kg <= 0 || kg > 30`. Write out both sides of the `||`, then say what it returns.
5. Write the whole output:
   ```csharp
   CashBox b = new CashBox();
   b.Deposit(10m);
   b.Withdraw(4m);
   b.Withdraw(20m);
   Console.WriteLine($"Balance: {b.Balance} KD");
   ```

<details>
<summary>Answers</summary>

1. `public`: any code can use it. `private`: only code inside the same class.
2. No. **CS0272**: the setter is private (inaccessible from outside).
3. The class hides its data and only lets it change through its own methods, which check the rules.
4. `40 <= 0` is false; `40 > 30` is true. `false || true` = true, so it returns **`false`** (rejected).
5. `Balance: 6 KD` (`10 - 4 = 6`; 20 is more than 6, so that withdraw is refused).

</details>
