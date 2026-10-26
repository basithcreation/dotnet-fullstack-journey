# Chapter 2.2: Classes, objects and properties

> Learned: Sun 25 + Mon 26 Oct 2026 · Code: `lessons/phase-02/01-classes-objects`

---

## 🧸 LKG story

**The KPOST shipment form.** At the counter there's a pile of **blank shipment forms**. Every blank form has the same boxes: Name, Phone, Area, Weight. A blank form isn't a shipment yet. It's just the **design**.

When a customer comes, the clerk takes **one** blank form and **fills it in**: "Ali, 9999 1234, Hawalli, 2 kg". That filled form is one real shipment. The next customer gets **another** form, with their own values. Changing Ali's form doesn't change Sara's.

At the end of the day, all the filled forms go into **one folder**.

| Story | C# |
|---|---|
| the blank form (the design) | **class** |
| a filled form | **object** (also called an **instance**) |
| taking a new blank form | `new Product()` |
| a box on the form | **property** |
| the folder of filled forms | `List<Product>` |

🎬 **Animation idea:** a blank `Product` form with 3 empty boxes (Name, Price, Quantity). Press "new Product()" and a fresh copy slides out. Type into its boxes and drop it into the folder (`List<Product>`). Then press "foreach": a finger moves through the folder one form at a time, and a total counter adds `Price * Quantity`. A switch shows the bug version (`total = ...` instead of `total +=`), where the counter only remembers the last form.

---

## 💻 Real explanation

### A class with properties

```csharp
class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
```

- `class Student` is the **class**: the blueprint.
- `Name` and `Age` are **properties**. `{ get; set; }` means you can **read** (get) and **write** (set) them.
- `= ""` gives `Name` a starting value, so it's never `null`.
- `public` means code outside the class can use it. (Access modifiers come in a later chapter.)

⚠️ In `Program.cs`, the class goes at the **bottom**, after the top-level code. If you put it at the top, you get **CS8803: Top-level statements must precede namespace and type declarations.**

### Objects (instances)

```csharp
Student s1 = new Student();
s1.Name = "Ali";
s1.Age = 20;

Student s2 = new Student();
s2.Name = "Sara";
s2.Age = 22;

s1.Age = s1.Age + 1;
Console.WriteLine($"After birthday: {s1.Name} is {s1.Age}");
Console.WriteLine($"{s2.Name} is still {s2.Age}");
```
```
After birthday: Ali is 21
Sara is still 22
```

- `new Student()` creates **one new object**: one fresh form.
- The **dot** reads or writes a property: `s1.Name`.
- Each object has its **own** values. Changing `s1` doesn't touch `s2`.

### A list of objects

```csharp
List<Student> students = new List<Student>();   // an empty list (the folder)

Student s3 = new Student();   // one object (one form)
s3.Name = "Ali";
s3.Age = 20;
students.Add(s3);
// ... Sara (22) and Omar (25) the same way

int totalAge = 0;

foreach (Student s in students)
{
    Console.WriteLine($"{s.Name} | {s.Age}");
    totalAge = totalAge + s.Age;
}

Console.WriteLine($"Total: {students.Count}");
Console.WriteLine($"Total age: {totalAge}");
```
```
Ali | 20
Sara | 22
Omar | 25
Total: 3
Total age: 67
```

Inside the loop, `s` is the **current object**, so `s.Age` is that student's age. The loop runs **once per object** in the list (3 rounds).

### The exercise: a product list

```csharp
decimal totalPrice = 0;

foreach (Product p in products)
{
    decimal lineValue = p.Price * p.Quantity;   // this product only
    totalPrice += lineValue;                    // the running total
    Console.WriteLine($"{p.Name} | {p.Price} KD x {p.Quantity} = {lineValue} KD");
}

Console.WriteLine($"Products: {products.Count}");
Console.WriteLine($"Total value: {totalPrice} KD");

class Product
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
```
```
Pen | 0.250 KD x 10 = 2.500 KD
Notebook | 1.500 KD x 4 = 6.000 KD
Bag | 7.000 KD x 1 = 7.000 KD
Products: 3
Total value: 15.500 KD
```

**Two variables, two jobs:**
- `lineValue` is a **local variable inside the loop**. It's created fresh in every round.
- `totalPrice` is **declared before the loop**, so it keeps its value between rounds.

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `class Student { String name = ''; int age = 0; }` | `class Student { public string Name { get; set; } = ""; public int Age { get; set; } }` |
| `var s = Student();` (`new` is optional) | `Student s = new Student();` (`new` is needed) |
| field names in `camelCase` (`name`) | property names in `PascalCase` (`Name`) |
| fields are public unless they start with `_` | you write `public` yourself |
| `List<Student> students = [];` | `List<Student> students = new List<Student>();` |
| `for (var s in students)` | `foreach (Student s in students)` |

The idea is the same in both languages: a class is the blueprint, and each object has its own values.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| `totalPrice = p.Price * p.Quantity;` → total `7.000` (only the Bag) | `=` **replaces** the value each round, so only the last round stays | add to it: `totalPrice += ...` |
| `totalPrice += ...` and printed `totalPrice` in each line → `8.500`, `15.500` | one variable doing two jobs (line value + running total) | a local `lineValue` for the line, `totalPrice` for the sum |
| Check question: wrote only the new line `Omar \| 25` | forgot that `foreach` prints **every** object | write one output line for every `WriteLine` that runs |
| Quiz: said `new Product()` creates an empty list | mixed up the folder and the form | `new List<Product>()` = the empty list; `new Product()` = one object |

✅ Wins: the sum `20 + 22 = 42`, `42 + 25 = 67` written step by step; `Omar and Sara` (each object has its own values); CS8803 known; the re-check (list vs object) right.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| the blank form | **class** | "`Product` is the class." |
| a filled form | **object** / **instance** | "`p1` is an instance of `Product`." |
| take a new form | **instantiate** (`new`) | "Instantiate a `Product` and set its properties." |
| a box on the form | **property** | "Add a `Quantity` property." |
| the dot | **member access** | "Read it with `p.Price`." |
| a running total | **accumulator** | "The accumulator is overwritten, use `+=`." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| design a thing | `class Product { public decimal Price { get; set; } }` (at the bottom of the file) |
| make one | `Product p1 = new Product();` |
| fill a box | `p1.Price = 1.500m;` |
| a folder of them | `List<Product> products = new List<Product>();` + `products.Add(p1);` |
| go through all of them | `foreach (Product p in products) { ... p.Price ... }` |
| sum a property | `decimal total = 0;` before the loop, `total += p.Price;` inside |

---

## 📝 Quiz

1. In the shipment form story, what are the real terms for the blank form and a filled form?
2. What does `new Product()` create? And `new List<Product>()`?
3. Write the whole output:
   ```csharp
   Student a = new Student();
   a.Name = "Ali";
   Student b = new Student();
   b.Name = "Sara";
   a.Name = "Omar";
   Console.WriteLine($"{a.Name} and {b.Name}");
   ```
4. `total = p.Price;` inside a `foreach` gives only the last price. Write the fix.
5. What happens if you put `class Product { ... }` above the top-level code in `Program.cs`?

<details>
<summary>Answers</summary>

1. Blank form = **class**; filled form = **object** (**instance**).
2. `new Product()` = **one** new object. `new List<Product>()` = an **empty list** that can hold many.
3. `Omar and Sara` (each object has its own `Name`).
4. `total += p.Price;`
5. A compile error, **CS8803**: top-level statements must come before type declarations.

</details>
