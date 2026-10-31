# Chapter 2.3: Constructors, `init`, object initializers and `required`

> Learned: Tue 27 + Thu 29 Oct 2026 (with a cold!) · Code: `lessons/phase-02/02-constructors`, `lessons/phase-02/03-init-required`

---

## 🧸 LKG story

**Back at the KPOST counter.** In Chapter 2.2, the clerk took a blank form and filled the boxes one by one. Now the counter gets some rules:

- **The stamping machine (constructor).** When a new form comes out of the machine, it is **already filled** with the details you gave it, and the machine says "New form created!". You can't get a form without going through the machine.
- **The printed tracking number (`init`).** The tracking number is **printed** on the form when it's made. After that, nobody can change it. The **weight** box is different: you can correct it if the parcel is re-weighed.
- **The red star ★ (`required`).** The **phone** box has a red star. The counter refuses the form until it's filled. Without the star, a forgotten box just stays empty, and nobody notices until later.

| Story | C# |
|---|---|
| the stamping machine | **constructor** (`public Parcel(...)`) |
| fill all the boxes at once, by name | **object initializer** (`new Courier { Name = "Ali" }`) |
| printed, can't change later | **init-only property** (`{ get; init; }`) |
| the red star ★ | **required member** (`required`) |

🎬 **Animation idea:** a Parcel form with 3 boxes: TrackingNo, Weight and Phone. Each box has a rule button that cycles through `set`, `init`, `required + init` and `required + set`. Tick which boxes you fill inside `new Parcel { ... }` and which ones you change later with `p.X = ...`. Press Build & run: the class code is shown, then either the output (with a warning when a box stayed silently empty) or the red compile error, **CS9035** for a missing star box or **CS8852** for changing a printed box.

---

## 💻 Real explanation

### 1. Constructor

A **constructor** is a special method that runs **when you write `new`**, once for each object.

- It has the **same name as the class**.
- It has **no return type**, not even `void`.

```csharp
Driver d1 = new Driver("Ali", "Hawalli");
Driver d2 = new Driver("Sara", "Salmiya");

Console.WriteLine($"{d1.Name} drives in {d1.Area}");
Console.WriteLine($"{d2.Name} drives in {d2.Area}");

class Driver
{
    public string Name { get; set; }
    public string Area { get; set; }

    public Driver(string name, string area)
    {
        Name = name;
        Area = area;
        Console.WriteLine($"New driver created: {name}");
    }
}
```
```
New driver created: Ali
New driver created: Sara
Ali drives in Hawalli
Sara drives in Salmiya
```

Why do both "New driver created" lines come **first**? Lines 1 and 2 call `new`, and `new` runs the constructor. The constructor prints its line. Only after that do lines 4 and 5 run.

Inside the constructor, `Name = name;` copies the **parameter** (`name`, lowercase) into the **property** (`Name`, uppercase).

### 2. `init`: set once, then locked

```csharp
Parcel p = new Parcel("KP1001", 2.5);
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");

p.Weight = 3.0;                     // OK: Weight has set
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");

class Parcel
{
    public string TrackingNo { get; init; }
    public double Weight { get; set; }

    public Parcel(string trackingNo, double weight)
    {
        TrackingNo = trackingNo;    // OK: we are inside the constructor
        Weight = weight;
    }
}
```
```
KP1001 weighs 2.5 kg
KP1001 weighs 3 kg
```

- `{ get; set; }`: read it any time, change it any time.
- `{ get; init; }`: read it any time, set it **only during creation** (in the constructor or in an object initializer).

Try `p.TrackingNo = "KP9999";` after creation, and C# **refuses to compile**:

> **CS8852**: Init-only property 'Parcel.TrackingNo' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor...

💡 A `double` drops zeros it doesn't need: `3.0` prints as `3`.

### 3. Object initializer: fill the boxes by name

The long way, one box per line (Chapter 2.2):

```csharp
Courier c = new Courier();
c.Name = "Ali";
c.Area = "Jahra";
```

The short way, an **object initializer**:

```csharp
Courier c = new Courier { Name = "Ali", Area = "Jahra" };
Console.WriteLine($"{c.Name} delivers in {c.Area}");

class Courier
{
    public string Name { get; set; } = "";
    public string Area { get; set; } = "";
}
```
```
Ali delivers in Jahra
```

The danger: you can **forget a box**. `new Courier { Name = "Omar" }` compiles fine, and `Area` silently stays `""`.

### 4. `required`: the red star

```csharp
Customer cu = new Customer { Name = "Fatima", Phone = "55512345" };
Console.WriteLine($"{cu.Name} | {cu.Phone}");

class Customer
{
    public required string Name { get; init; }
    public required string Phone { get; init; }
}
```
```
Fatima | 55512345
```

Forget the phone, `new Customer { Name = "Fatima" }`, and it **won't compile**:

> **CS9035**: Required member 'Customer.Phone' must be set in the object initializer or attribute constructor.

| | Forgot a box | What happens |
|---|---|---|
| `Courier` (no `required`) | `Area` | compiles, silently `""` 😬 |
| `Customer` (`required`) | `Phone` | **CS9035**, won't compile ✅ |

### 5. `required` and `init` are two separate rules

| Property | Must be set at creation? | Can change later? |
|---|---|---|
| `{ get; set; }` | no | yes |
| `{ get; init; }` | no | **no** (CS8852) |
| `required ... { get; init; }` | **yes** (CS9035) | **no** (CS8852) |
| `required ... { get; set; }` | **yes** (CS9035) | yes |

### The exercise: a KPOST van list

```csharp
Vehicle v1 = new Vehicle { PlateNo = "12-34567", Model = "Toyota Hiace", Mileage = 85000 };
Vehicle v2 = new Vehicle { PlateNo = "45-11223", Model = "Nissan Urvan", Mileage = 120000 };

v1.Mileage = v1.Mileage + 250;      // or: v1.Mileage += 250;
Console.WriteLine($"{v1.PlateNo} | {v1.Model} | {v1.Mileage} km");
Console.WriteLine($"{v2.PlateNo} | {v2.Model} | {v2.Mileage} km");

class Vehicle
{
    public required string PlateNo { get; init; }   // a plate never changes
    public required string Model { get; init; }
    public required int Mileage { get; set; }       // must be given, grows every day
}
```
```
12-34567 | Toyota Hiace | 85250 km
45-11223 | Nissan Urvan | 120000 km
```

`85000 + 250 = 85250`. C# does the sum; you don't type `85250` yourself.

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `Driver(this.name, this.area);` | `public Driver(string name, string area) { Name = name; Area = area; }` |
| `final String trackingNo;` | `public string TrackingNo { get; init; }` |
| named arguments: `Courier(name: 'Ali', area: 'Jahra')` | object initializer: `new Courier { Name = "Ali", Area = "Jahra" }` |
| `Customer({required this.phone})` | `public required string Phone { get; init; }` |
| a missing `required` argument is a compile error | a missing `required` member is **CS9035** |

The ideas are very close. Dart `final` ≈ C# `init`, and the `required` keyword means the same thing in both languages.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Typed the example without ` kg` → `KP1001 weighs 2.5` | copied the code but dropped the end of the line (3rd time a unit went missing) | compare **whole lines** with the expected output |
| Guessed `3.0` would print `3.0` | `double` drops trailing zeros | it prints `3` |
| Guessed `p.TrackingNo = "KP9999";` would work "because of init" | thought `init` means "can assign" | `init` = only **at creation** → **CS8852** |
| Said the editor "threw" an error | mixed up compile time and run time | it's a **compile error** (red underline); *throw* is for exceptions at run time |
| Quiz: "the constructor runs when calling the class" | too vague | it runs **when you write `new`**, once per object |
| Quiz: "the box is required" | the **class** isn't required | the **property `Label`** is required |
| Ran the code before writing a guess (twice) | skipped the guessing habit | write the guess first, then run |

✅ Wins: the vehicle exercise worked on the first try with whole lines; deleted the broken line instead of commenting it out; checked "files changed" on all 4 commits; quiz **4/5** (up from 2.5/5 in Chapter 2.2).

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| the stamping machine | **constructor** | "Pass the name and area through the constructor so a `Driver` can't be created empty." |
| printed, can't change | **init-only property** (`init`) | "Make `TrackingNo` init-only so nobody can change it after creation." |
| fill boxes by name | **object initializer** | "Use an object initializer instead of setting each property on its own line." |
| the red star ★ | **required member** (`required`) | "Mark `Phone` as required so nobody can create a customer without one." |
| changed a printed box | **CS8852** | "It doesn't compile, CS8852: you're assigning an init-only property outside the constructor." |
| forgot a star box | **CS9035** | "CS9035: `Phone` is required and the initializer doesn't set it." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| run code when an object is made | `public Driver(string name) { Name = name; }` |
| make an object with the constructor | `new Driver("Ali", "Hawalli")` |
| fill properties by name | `new Courier { Name = "Ali", Area = "Jahra" }` |
| lock a property after creation | `public string TrackingNo { get; init; }` |
| force a property to be filled | `public required string Phone { get; init; }` |
| must fill, but can change later | `public required int Mileage { get; set; }` |

---

## 📝 Quiz

1. Fill the blanks: a constructor has the same name as the ______, and it has no ______ type.
2. When does a constructor run?
3. A class has `public string Code { get; init; }`. After creating the object, you write `box.Code = "A";`. Does it compile? If not, which error code?
4. `class Box { public required string Label { get; init; } }`. Does `Box b = new Box();` compile? Why?
5. Write the whole output line:
   ```csharp
   Vehicle v = new Vehicle { PlateNo = "1", Model = "Hiace", Mileage = 100 };
   v.Mileage += 50;
   v.Mileage += 50;
   Console.WriteLine($"{v.Model}: {v.Mileage} km");
   ```

<details>
<summary>Answers</summary>

1. **class**, **return**.
2. When you write `new`, once for each object.
3. No. **CS8852**: an init-only property can only be set during creation.
4. No. **CS9035**: `Label` is a required member, and `new Box()` doesn't set it. Fix: `new Box { Label = "Fragile" }`.
5. `Hiace: 200 km` (`100 + 50 = 150`, `150 + 50 = 200`).

</details>
