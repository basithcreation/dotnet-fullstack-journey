# 📦 Shipment Tracker

A console app for a courier office in C#. You can add shipments, list them, search by tracking number and mark them as delivered. Everything is kept in memory (it's gone when the app closes).

**Version 2** (Phase 2, OOP): each shipment is now one `Shipment` object instead of the same index in 4 separate lists.

## How to run

    dotnet run

## Example

```
=== KPOST Shipment Tracker ===

1) Add 2) List 3) Search 4) Mark delivered q) Quit
Choose: 1
Receiver name: Ali
Added KP1001

1) Add 2) List 3) Search 4) Mark delivered q) Quit
Choose: 4
Tracking number: kp1001
KP1001 marked as delivered

1) Add 2) List 3) Search 4) Mark delivered q) Quit
Choose: 2
KP1001 | Ali | Delivered | 31 Oct 2026 16:27

1) Add 2) List 3) Search 4) Mark delivered q) Quit
Choose: 3
Tracking number: kp9999
Error: Shipment KP9999 not found

1) Add 2) List 3) Search 4) Mark delivered q) Quit
Choose: q
Goodbye!
```

## What I practiced in v2

- A **`Shipment` class** with properties. `Number` and `Receiver` are `required` + `init` (must be given at creation, then locked). `Status` keeps `set` because it changes to "Delivered"
- **Default values** in the class (`Status = "In transit"`, `CreatedAt = DateTime.Now`), so "Add" doesn't have to set them
- An **object initializer**: `new Shipment { Number = number, Receiver = receiver }`
- **One `List<Shipment>`** instead of 4 parallel lists, and a `foreach` instead of a `for` with an index
- A **`FindShipment` method** that returns a whole object, used by both Search and Mark delivered (no repeated code)
- `return` inside a loop (it leaves the method straight away), and a `throw` after the loop for "not found"
- **Classes are reference types:** changing `Status` on the object `FindShipment` returns also changes the one in the list
- Worked on a **feature branch** (`feature/shipment-class`), with one commit per step

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

## From v1 (Phase 1)

- Auto-generated tracking numbers: `$"KP{1001 + shipments.Count}"`
- Cleaned input with `(Console.ReadLine() ?? "").Trim().ToUpper()`, so `kp1001` finds `KP1001`
- `DateTime.Now` as a timestamp, shown with `.ToString("dd MMM yyyy HH:mm")`
- A `try` / `catch` around the menu, so a "not found" shows an error instead of crashing the app
- v1 used 4 parallel lists and `IndexOf`. Git history has the old version

## What I'd add next

(Ideas only, not built yet.)

- Reject an empty receiver name
- Save shipments to a file or a database, so they're still there after the app closes
