# Chapter 2.6: Inheritance (`:`, `protected`, `: base(...)`)

> Learned: Sun 1 – Tue 3 Nov 2026 · Code: `lessons/phase-02/05-inheritance`

---

## 🧸 LKG story

**The KPOST van.** Before KPOST can use a new van, **traffic registers it first**: the van gets its plate number. Only after that does KPOST add its own information: "this van carries 50 parcels". A van is still a vehicle: it has everything every vehicle has (a plate), plus its own extra things.

The same goes for staff. Every KPOST **employee** has a name and a salary. A **driver** is an employee too, plus a van number. The salary is in a sealed envelope: HR and the driver's own team can open it, but a customer at the counter can't.

| Story | C# |
|---|---|
| "a driver **is an** employee" | **inheritance**: `class Driver : Employee` |
| the general one (employee, vehicle) | **base class** (parent) |
| the special one (driver, van) | **derived class** (child) |
| traffic registers the van first | the **base constructor** runs first |
| KPOST passes the plate to traffic | **`: base(plate)`** (constructor chaining) |
| the sealed salary envelope | **`protected`**: the class + its children only |

🎬 **Animation idea:** a van goes through two gates. Gate 1 is "Traffic (Vehicle)": it stamps the plate. Gate 2 is "KPOST (Van)": it loads the parcels. A switch removes `: base(plate)`, so the van reaches Gate 1 with no plate and gets the red **CS7036**. A second switch changes `Fee` between `private`, `protected` and `public`. Buttons try to use `Fee` from inside `Parcel`, inside `ExpressParcel` and from the top code, and each one turns green (works) or red (**CS0122**).

---

## 💻 Real explanation

### 1. `:` means "inherits from"

```csharp
Driver d = new Driver();
d.Name = "Ali";            // Name comes from Employee
d.VanNumber = "V-12";      // VanNumber is Driver's own
Console.WriteLine($"{d.Name} drives {d.VanNumber}");

class Employee
{
    public string Name { get; set; } = "";
}

class Driver : Employee
{
    public string VanNumber { get; set; } = "";
}
```
```
Ali drives V-12
```

The **is-a test**: "a driver *is an* employee" makes sense, so inheritance fits. "A van *is a* parcel" doesn't, so no inheritance there.

### 2. Inheritance goes one way

The child gets everything from the parent. The parent gets **nothing** from the child:

```csharp
Employee e = new Employee();
Console.WriteLine(e.VanNumber);
```
```
error CS1061: 'Employee' does not contain a definition for 'VanNumber' ...
```

### 3. `protected`: for the family only

```csharp
class Employee
{
    public string Name { get; set; } = "";
    protected decimal Salary { get; set; } = 400m;
}

class Driver : Employee
{
    public void ShowBonus()
    {
        decimal bonus = Salary / 10;      // ✅ a child can use protected
        Console.WriteLine($"{Name} gets a bonus of {bonus} KD");
    }
}
```
```
Ali gets a bonus of 40 KD
```

From the top code, `d.Salary` gives **CS0122** (inaccessible due to its protection level). If `Salary` were `private`, even `Driver` would get **CS0122**.

| Modifier | Who can use it |
|---|---|
| `public` | everyone |
| `private` | only the same class |
| `protected` | the same class + derived classes |
| `internal` | anywhere in the same project |

### 4. Base constructors: the parent is built first

```csharp
Van v = new("KW-1234", 50);
Console.WriteLine($"{v.Plate} | {v.MaxParcels} parcels");

class Vehicle
{
    public string Plate { get; }
    public Vehicle(string plate)
    {
        Plate = plate;
        Console.WriteLine($"Vehicle {plate} registered");
    }
}

class Van : Vehicle
{
    public int MaxParcels { get; }
    public Van(string plate, int maxParcels) : base(plate)
    {
        MaxParcels = maxParcels;
        Console.WriteLine($"Van can carry {maxParcels} parcels");
    }
}
```
```
Vehicle KW-1234 registered
Van can carry 50 parcels
KW-1234 | 50 parcels
```

`: base(plate)` passes the plate up to the `Vehicle` constructor, and that runs **before** the `Van` body. Remove it and you get:

```
error CS7036: There is no argument given that corresponds to the required parameter 'plate' of 'Vehicle.Vehicle(string)'
```

If the parent has a constructor with **no parameters**, C# calls it by itself, even without `: base()`:

```csharp
new Truck();

class Machine { public Machine() { Console.WriteLine("Machine ready"); } }
class Truck : Machine { public Truck() { Console.WriteLine("Truck ready"); } }
```
```
Machine ready
Truck ready
```

To give the parent a **fixed** value: `public BigBox() : base(100) { }`.

`new("KW-1234", 50)` is **target-typed `new`**: the type is already on the left (`Van v`), so you don't write it twice.

### 5. The exercise: an express parcel

```csharp
ExpressParcel e = new("KP3001", 1.5m);
e.ShowTotal();

class Parcel
{
    public string Number { get; }
    protected decimal Fee { get; } = 2m;

    public Parcel(string number)
    {
        Number = number;
        Console.WriteLine($"Parcel {number} created");
    }
}

class ExpressParcel : Parcel
{
    public decimal ExtraFee { get; }
    public ExpressParcel(string number, decimal extraFee) : base(number)
    {
        ExtraFee = extraFee;
    }
    public void ShowTotal()
    {
        decimal total = Fee + ExtraFee;
        Console.WriteLine($"Express {Number} | total {total} KD");
    }
}
```
```
Parcel KP3001 created
Express KP3001 | total 3.5 KD
```

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `class Driver extends Employee` | `class Driver : Employee` |
| `Van(String plate, this.maxParcels) : super(plate);` | `public Van(string plate, int maxParcels) : base(plate) { ... }` |
| `_salary` (private to the **file**) | `private` (the class) / `protected` (class + children) |

Dart has no `protected` keyword. C# has one.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| `ShowTotal(decimal total)` → CS7036 at `e.ShowTotal()` | the method calculates the total itself; nothing should come in | make `total` a **local variable** inside the method |
| `Parcel(string Number)` with no assignment → CS8618, empty number | the parameter had the same name as the property (**shadowing**) | camelCase parameter + `Number = number;` |
| `extraFee = ExtraFee;` → total 2 instead of 3.5 | `=` copies **right into left**; this was backwards | `ExtraFee = extraFee;` (property on the left) |
| An extra `using System.Security.Cryptography...` line | the editor added it from an autocomplete | delete unused `using` lines |
| Quiz: CS7036 for `e.VanNumber` | mixed up two errors | CS7036 = an **argument** is missing; CS1061 = the **member** doesn't exist |
| Quiz: "protected = inside the class only" | that is `private` | protected = class **+ derived classes** |

✅ Wins: predicted CS7036 when `: base(plate)` was removed; `: base(number)` right the first time; 3/3 inheritance predictions on 1 Nov.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| parent / child | **base class** / **derived class** | "`Driver` derives from `Employee`." |
| "a driver is an employee" | **is-a relationship** | "Does it pass the is-a test? Then inherit." |
| the family-only envelope | **`protected`** | "Make `Fee` protected so `ExpressParcel` can use it." |
| pass the plate to the parent | **constructor chaining** (`: base(...)`) | "The Van constructor chains to the base constructor." |
| the parent needs a value, nobody gave one | **CS7036** | "CS7036: the base class has no parameterless constructor." |
| the member doesn't exist | **CS1061** | "CS1061: `Employee` doesn't have `VanNumber`." |
| same name hides the property | **shadowing** | "The parameter shadows the property, rename it to camelCase." |
| `new(...)` without the type | **target-typed `new`** | "Use target-typed new, the type is on the left already." |
| visible in this project only | **`internal`** | "Make it internal, only this project needs it." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| a class that inherits | `class Driver : Employee { }` |
| let children use a member | `protected decimal Fee { get; }` |
| pass a value to the parent constructor | `public Van(string plate, int max) : base(plate) { }` |
| pass a fixed value | `public BigBox() : base(100) { }` |
| create without repeating the type | `Van v = new("KW-1234", 50);` |

---

## 📝 Quiz

1. In C#, what replaces Dart's `extends`, and what replaces `super`?
2. Write the whole output of the `Machine` / `Truck` example (no `: base()` is written).
3. `Employee e = new Employee(); Console.WriteLine(e.VanNumber);` Which error, and why?
4. `Fee` is `protected`. Can the top code use `e.Fee`? Name one place where `Fee` *can* be used.
5. `class Box { public Box(int size) { } }` and `class BigBox : Box { public BigBox() { } }`. Which error? Fix it so every `BigBox` has size 100.

<details>
<summary>Answers</summary>

1. `:` and `base`.
2. `Machine ready` then `Truck ready` (the parent constructor runs first, even when it's called automatically).
3. **CS1061**: inheritance goes one way, and `Employee` has no `VanNumber`.
4. No, **CS0122**. It can be used inside `Parcel` and inside `ExpressParcel` (for example in `ShowTotal`).
5. **CS7036**. Fix: `public BigBox() : base(100) { }`

</details>
