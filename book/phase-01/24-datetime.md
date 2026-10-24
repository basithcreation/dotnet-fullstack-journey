# Chapter 1.24: `DateTime` and `TimeSpan`

> Learned: Sat 24 Oct 2026 · Code: `lessons/phase-01/34-datetime`

---

## 🧸 LKG story

**The date stamp and the calendar.** Every parcel gets a **date stamp** when it's sent: "24 Oct 2026, 2:30 PM". KPOST promises "delivered in 3 days", so someone counts 3 days forward on the **calendar**. When the parcel arrives, someone counts the days **between** the two stamps.

`DateTime` is the stamp + the calendar. `TimeSpan` is the "how long between" answer.

🎬 **Animation idea:** a calendar page with a stamp on 24 Oct 2026. A slider says "AddDays(n)". As you slide, a second stamp moves forward day by day, the weekday name changes, and a ruler between the two stamps shows the `TimeSpan` (`.Days`). A format box (`dd MMM yyyy HH:mm`) shows how the same date looks with different format letters.

---

## 💻 Real explanation

```csharp
DateTime sent = new DateTime(2026, 10, 24, 14, 30, 0);
Console.WriteLine(sent.ToString("dd MMM yyyy HH:mm"));

DateTime due = sent.AddDays(3);
Console.WriteLine(due.ToString("dd MMM yyyy"));
Console.WriteLine(due.DayOfWeek);

TimeSpan wait = due - sent;
Console.WriteLine(wait.Days);
Console.WriteLine(DateTime.Now);
```
```
24 Oct 2026 14:30
27 Oct 2026
Tuesday
3
10/24/2026 5:34:04 PM
```

| Code | Meaning |
|---|---|
| `new DateTime(2026, 10, 24, 14, 30, 0)` | a fixed date: year, month, day, hour, minute, second |
| `DateTime.Now` | the date and time on this PC right now (a property, no `()`) |
| `.AddDays(3)` | a **new** date, 3 days later. `DateTime` is **immutable**, like a string: keep it with `due = due.AddDays(3);` |
| `.ToString("dd MMM yyyy")` | turn the date into text with a **format string** |
| `.DayOfWeek` | `Monday`, `Tuesday`, ... |
| `due - sent` | the gap between two dates: a **`TimeSpan`** (not a string, not an int) |
| `wait.Days` | the number of whole days in the gap (just the number, no word "days") |

### Format letters

| Letter | Means | 24 Oct 2026, 14:30 → |
|---|---|---|
| `dd` | day | `24` |
| `MM` | month as a number | `10` |
| `MMM` | month as a short name | `Oct` |
| `yyyy` | year | `2026` |
| `HH` | hour (24-hour clock) | `14` |
| `mm` | **minutes** (small m!) | `30` |

⚠️ `MM` = month, `mm` = minutes. Mixing them up is a classic bug.

**Why a format string?** Without one, the date uses the PC's **culture** (region settings). This PC is `en-US`, so `DateTime.Now` printed month first: `10/24/2026`. In Kuwait people read that as day/month and get confused. `"dd MMM yyyy"` looks the same on every PC.

**The year rolls over by itself:**

```csharp
DateTime d = new DateTime(2026, 12, 31);
Console.WriteLine(d.AddDays(1).ToString("dd MMM yyyy"));
```
```
01 Jan 2027
```

---

## 🎯 Dart comparison

| Dart | C# |
|---|---|
| `DateTime.now()` | `DateTime.Now` (property, no `()`) |
| `DateTime(2026, 10, 24)` | `new DateTime(2026, 10, 24)` |
| `date.add(Duration(days: 3))` | `date.AddDays(3)` |
| `Duration` | `TimeSpan` |
| `due.difference(sent).inDays` | `(due - sent).Days` |
| `DateFormat('dd MMM yyyy').format(d)` (the `intl` package) | `d.ToString("dd MMM yyyy")` (built in) |

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Guessed `3 days` for `wait.Days` | Thought it adds the word | `.Days` is just the number: `3` |
| Quiz: said `due - sent` gives a `string` | Didn't know the type name yet | It's a **`TimeSpan`**, like Dart's `Duration` |
| Quiz: "immutable" with no fix | Short answer | `sent.AddDays(2);` alone does nothing. Fix: `sent = sent.AddDays(2);` |

✅ Wins: all 5 lines of the example right; `01 Jan 2027` year rollover right; `MM` vs `mm` right; quiz 4/5.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| the date stamp | **timestamp** | "Save a timestamp when the shipment is created." |
| how long between | **`TimeSpan`** | "Subtract the dates to get a TimeSpan." |
| the letters `dd MMM yyyy` | **format string** | "Use a format string so it looks the same on every PC." |
| region settings | **culture** (`en-US`, `ar-KW`) | "The server culture is en-US, so the date printed month first." |
| a new date, the old one stays | **immutable** | "`DateTime` is immutable, assign the result of `AddDays`." |

---

## 📋 Summary

| I want... | Write |
|---|---|
| now | `DateTime.Now` |
| a fixed date | `new DateTime(2026, 10, 24)` |
| 3 days later | `date.AddDays(3)` (keep it with `=`) |
| nice text | `date.ToString("dd MMM yyyy HH:mm")` |
| the weekday | `date.DayOfWeek` |
| days between | `(due - sent).Days` |

---

## 📝 Quiz

1. In a format string, what's the difference between `MM` and `mm`?
2. Does `sent` change after `sent.AddDays(2);`? Why?
3. What does `new DateTime(2026, 12, 31).AddDays(1).ToString("dd MMM yyyy")` give?
4. `due - sent` gives you what type?
5. How do you get the current date and time?

<details>
<summary>Answers</summary>

1. `MM` = month (`10`), `mm` = minutes (`30`).
2. No. `DateTime` is immutable: `AddDays` returns a new date that nobody keeps. Fix: `sent = sent.AddDays(2);`
3. `01 Jan 2027`
4. `TimeSpan`
5. `DateTime.Now`

</details>
