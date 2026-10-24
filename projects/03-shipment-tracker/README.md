# 📦 Shipment Tracker

A console app for a courier office in C#. You can add shipments, list them, search by tracking number and mark them as delivered. Everything is kept in memory (it's gone when the app closes).

## How to run

    dotnet run

## Example

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
 1) Add 2) List 3) Search 4) Mark delivered q) Quit

Choose: q
Goodbye!
```

## What I practiced

- **4 parallel lists** (`numbers`, `receivers`, `statuses`, `createdTimes`): one shipment = the same index in all 4 lists
- **Auto-generated tracking numbers:** `$"KP{1001 + numbers.Count}"`
- `for` loop with an index to print the same row from all 4 lists (`foreach` has no index)
- `IndexOf` to find a tracking number; it returns `-1` when it's not found
- Fixed an **off-by-one** bug: `index <= 0` said the first shipment (index 0) was "not found"
- Cleaned input with `(Console.ReadLine() ?? "").Trim().ToUpper()`, so `kp1001` finds `KP1001`
- `DateTime.Now` as a timestamp, shown with `.ToString("dd MMM yyyy HH:mm")`
- A `FindIndex` method that **throws** an `ArgumentException` when the shipment isn't found, and a `try` / `catch` around the menu, so the app shows an error instead of crashing

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

## What I'd add next

(Ideas only, not built yet.)

- Reject an empty receiver name
- Use `FindIndex` in Search too, so the search code isn't written twice
- Replace the 4 lists with a `Shipment` class (Phase 2: OOP)
