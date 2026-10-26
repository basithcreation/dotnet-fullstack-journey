# Chapter 1.26: Debugging (breakpoints, step over, step into)

> Learned: Sun 25 Oct 2026 · Code: `projects/03-shipment-tracker` (VS Code + C# Dev Kit)

---

## 🧸 LKG story

**The CCTV replay at the sorting hub.** A parcel went to the wrong shelf. Shouting "where did it go wrong?" doesn't help. So the supervisor plays the CCTV recording and **pauses** it at the moment the parcel enters the belt. Then they move forward **one frame at a time**, looking at the parcel's label each time. At one frame the label says the wrong area, and that's the bug.

The debugger is that CCTV replay for your code. You **pause** on a line, move **one line at a time**, and look at the values in the boxes.

🎬 **Animation idea:** the `FindIndex` code with a red dot on one line. Buttons F5, F10 and F11 move a yellow arrow. A side panel shows `number`, `found` and `index`. The values appear only **after** the yellow line moves past them. A toggle swaps in the buggy `<= 0` check, so you can watch `index = 0` turn into "not found".

---

## 💻 Real explanation

Before debugging, the only tool was `Console.WriteLine` everywhere. A **debugger** pauses the running program so you can look inside it.

| Key | Name | What it does |
|---|---|---|
| **F9** | toggle **breakpoint** | puts a red dot on a line: "pause here" |
| **F5** | **start debugging** | runs the program until it hits a breakpoint (pick **C#** the first time) |
| **F5** (while paused) | **continue** | runs on to the **next** breakpoint, or to the end |
| **F10** | **step over** | runs the yellow line and moves to the next line. A method call runs completely, without going inside it |
| **F11** | **step into** | if the yellow line calls **your** method, go **inside** it |
| **Shift+F11** | **step out** | finish this method and go back to the caller |
| **Shift+F5** | **stop debugging** | end the run |

⚠️ **The yellow line has NOT run yet.** It's the **next** line to run. If the yellow line is `int index = ...`, then `index` still has its old value (or `0`). Press F10 once, and then look.

**Where to look at values:**
- **Hover** the mouse over a variable
- The **Variables** panel (top left) shows every local variable
- The **Watch** panel: type your own expression, like `numbers.Count` or `index == -1`

### The bug I found with it

We put the old bug back in the Shipment Tracker for one minute:

```csharp
int index = numbers.IndexOf(searchNumber);
if (index <= 0)   // the bug: index 0 is a real index
{
    Console.WriteLine($"Shipment {searchNumber} not found");
}
```

Breakpoint on the `IndexOf` line, F5, search `KP1001`, F10 once:

```
index = 0
```

Then F10 again: the yellow line jumped **into** the "not found" block. `0 <= 0` is `True`. Seeing `index = 0` on screen made the off-by-one obvious. The fix is back to `if (index < 0)`.

---

## 🎯 Dart comparison

| Flutter / Dart | C# in VS Code |
|---|---|
| `print()` / `debugPrint()` everywhere | still works, but the debugger is faster |
| breakpoints in VS Code / Android Studio | the same red dots, F9 |
| F10 / F11 step over / into | the same keys |
| hot reload | no hot reload in a console app; Shift+F5, fix, F5 again |
| Flutter DevTools | the Variables + Watch panels |

Good news: if you've ever debugged a Flutter app in VS Code, the keys are the **same**.

---

## 🐞 Mistakes I actually made

| Mistake | Why | Fix |
|---|---|---|
| Quiz: thought the yellow line had already run | It "looks" selected, so it feels done | The yellow line is the **next** line. Press F10, then read the value |
| Quiz: didn't know what F5 does while paused | F5 starts the run, so it seems to "restart" | While paused, F5 = **continue** to the next breakpoint |

✅ Wins: set the breakpoint, stepped with F10/F11, and found the planted `<= 0` bug by reading `index = 0`.

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| a red stop dot | **breakpoint** | "Put a breakpoint on the IndexOf line." |
| the yellow line | **current line / execution point** | "The yellow line hasn't run yet." |
| one line forward | **step over** | "Step over it and check `index`." |
| walk into the method | **step into** | "Step into `FindIndex`." |
| run to the next red dot | **continue** | "Continue, it'll stop at the next breakpoint." |
| look at a box | **inspect a variable** / **watch** | "Add `numbers.Count` to the watch." |

---

## 📋 Summary

| I want to... | Press |
|---|---|
| pause on a line | F9 on that line, then F5 |
| run one line | F10 |
| go inside my method | F11 |
| run on to the next red dot | F5 |
| stop | Shift+F5 |
| see a value | hover / Variables / Watch |

---

## 📝 Quiz

1. The yellow line is `int index = numbers.IndexOf("KP1001");`. Has `index` got its new value yet?
2. You're paused at a breakpoint. What does F5 do now?
3. What's the difference between F10 and F11 on a line that calls `FindIndex(...)`?
4. Where can you see the value of `numbers.Count` while paused? (2 places)
5. Why is a debugger better than adding 10 `Console.WriteLine` lines?

<details>
<summary>Answers</summary>

1. No. The yellow line has **not** run yet. Press F10, then read `index`.
2. **Continue**: run until the next breakpoint (or the end).
3. F10 runs `FindIndex` completely and stops on the next line. F11 goes **inside** `FindIndex`.
4. Hover over it, or type it in the **Watch** panel (the Variables panel shows `numbers`; open it to see `Count`).
5. You don't change the code, and you can see every variable at any line. Then you don't have to remove the `WriteLine` lines afterwards.

</details>
