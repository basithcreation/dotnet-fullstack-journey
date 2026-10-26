# Learning Progress Log

Newest day at the top. Claude reads this at the start of each new chat to continue from the right place.

---

## ▶️ Next session starts here

- **Tue 27 Oct (office PC, duty 10 AM–10 PM for 2 weeks, study in free gaps).** Start with a 3-question **warm-up** on Mon's weak spots: (1) class vs object/instance in the shipment form story, (2) what `new Product()` creates vs `new List<Product>()`, (3) a whole-output prediction with a `foreach` over 3 objects (they wrote only the newest line on Mon). Then **constructors, `init`, `required`** (the rest of the ROADMAP box "Classes, objects, constructors, properties"; tick it after this) → then **Shipment Tracker v2** on a branch (`feature/shipment-class`): the 4 parallel lists become one `List<Shipment>`. Give the expected output for the project steps
- **Phase 2 plan (moved 1 day, 26 Oct; with 10–10 duty only gaps are free, so go by topics, not dates):** constructors/`init`/`required` + Tracker v2 → access modifiers + encapsulation → inheritance, `virtual`/`override`, polymorphism → abstraction, `abstract` class vs `interface`, `static`, `sealed` → `enum`, `record`, `struct` vs `class` → SOLID (~45 min) → **Project 04 Library Management** on a branch + the 4 pillars out loud in 2 min. Inheritance and abstraction are the hardest; 2 sessions each is OK. Phase 2 will spill into the first days of Nov, and that's fine
- **Home laptop setup check is still not done.** Do it in the first 15 min of **Fri 30 Oct**: `git pull`, `dotnet --version` = 10.x, `dotnet run` in `projects/03-shipment-tracker`, `git config user.name` / `user.email`
- **Small leftovers (only if there's a spare minute, don't make a session of it):** `citys` → `areas` in `31-string-helpers`; Shipment Tracker case 3 could use `FindIndex` too (README "add next" lists it; it can go into v2)
- **Uncommitted at day-end (26 Oct):** `CLAUDE.md`, `PROGRESS.md`, `lessons/glossary.md`, `career/linkedin/02-phase-1-done.md`, the book (3 chapters, README, journey, template, index). The student commits them with one day-end commit (commands given in chat). Check `git status` first on Tue
- **Naming:** lessons are `lessons/phase-XX/NN-kebab-name`. Phase 2 so far: `lessons/phase-02/01-classes-objects` (the Product exercise is inside it too). Next lesson folder: `02-...` (list the folder first). Book: Phase 1 ends at **1.26** (debugging); Phase 2 has **2.1** Git branches and **2.2** classes/objects; the next chapter is `book/phase-02/03-...` (2.3). Projects: Tracker v2 stays in `projects/03-shipment-tracker` (on a branch); the next new project is `projects/04-library-management`. List the folder before naming anything
- **Claude writes** READMEs, LinkedIn drafts and book chapters; the student reviews them in 2 min. The student types all code
- **Work dates:** the student's own resumes and LinkedIn are the source of truth for job dates (confirmed 15 and 17 Oct). The Day 9 "Career" notes below were a rough chat story. Don't use them to question the dates
- **Career context (told on Day 9):** KPOST's backend is ASP.NET, so from Phase 6 suggest they ask their senior to let them write real endpoints. Phase 14 main project = **KACT** charity app rebuild (see ROADMAP Phase 14). Private career plans are in Claude's local memory only, never in this public repo
- **How to teach this student:**
  - **Give EXACT steps for where to type code** (Day 15: "type it in a new scratch project" without a folder or command made them upset: "teach me as a good professor"). Always give: the folder, the `dotnet new console -o ...` command, the file to open, `cd` + `dotnet run`
  - **Explain "predict" in plain words** when using it: "guess the output before you run it" (Day 15 they didn't know the word)
  - **Run EVERY example in the scratchpad before sending it** (Day 13: Claude gave two overloaded `PrintLabel` local functions in top-level statements → CS0128. The student was rightly upset: "this is my life, take full responsibility"). Overloads need a `static class` + `public static`
  - **Dart/Flutter level is intermediate, not expert** (Day 9). Compare only with basic Dart
  - **Weak at mental maths** (they said so). In traces, ask them to write each sum out (`12 + 7 =`) and check the answer a second way. They didn't know `%` = remainder (thought percent/divide), and Windows Calculator's `%` is percent
  - **Keep messages SHORT.** On Day 9 a 3-part message (string `==` + placement + `break`) made them say "I'm not understanding". One idea, one blank, one test
  - **Be exact when listing "ideas for later":** they read "What I'd add next: Play again" as an instruction and started coding it. Say "only write this in the README, don't code it"
  - **Keep Git short** (they asked on Day 8 if Git is worth the time; they want to finish .NET fast). Commit **right after each exercise** (1 minute). No long fix-up sessions. A typo in a message: point it out, amend only if not pushed and it takes 10 seconds. No new Git until Phase 2 (branches)
  - **They forget a folder in `git add`** (Day 4 and Day 8, the same mistake). Always check the "N files changed" number against the expected one
  - **Check the clock before saying "morning" / "tonight"**. Schedule (26 Oct): duty **10 AM–10 PM for about 2 weeks** (until ~8 Nov), study only in free gaps (on Mon 26 the chat opened at 10 AM, but the real work ran ~6:40–9:30 PM). Fri off (1 hr review on the home laptop). Before this: Sun–Thu 6:30 AM–6:30 PM, Sat 1–9 PM. On Saturday they are at the OFFICE PC, not home
  - **Analogies must not be real tech words** (25 Oct: the cookie story confused them, "is cookie a real term?"). Use KPOST stories: the **shipment form** works for classes
  - **Predict the whole line**, not just the variable (Day 10: predicted "Hawalli" for `$"Delivering to {city}"`). And write out both sides of `||` / `&&` before answering
  - They predict from the **English meaning** of a keyword (`continue` = "carry on normally"). For new keywords, give the C# meaning in one line before asking for a prediction
  - The prediction habit is working: they predict in chat **before** running now ✅. Keep asking
  - Tracing: half-filled trace tables work. Their remaining mistake is the **final answer**: it doesn't come from the last row (Day 8: table said 6, answered 10). Ask "which row is the last true one?"
  - When they write code, things often end up **outside** the loop or block they belong to (the standalone block after `while (...);`). Ask "which lines must repeat?"
  - "done" without output: ask for the output **every** time. Read the file yourself before accepting
  - ONE step per message, fill-in templates with blanks (worked well for the flag fix)
  - Day 8: started 11:00 AM, stopped around 9:30 PM
  - **Method parameters are new and hard** (Day 11): they put the **method name** in `{ }` instead of the parameter name, twice. Before an exercise with parameters, ask "which words on line 1 are the parameter names?"
  - When they copy a line, they forget to change the part inside `{ }` (Day 11, twice). Ask them to read the **label** next to the code
  - **They delete correct code when unsure** (Day 12: wrote `else`, then removed it). Tell them: "keep it and run it, the output tells you"
  - **Output can hide bugs** (Day 12: `fee = 0.5` on the bad path, output still looked right). Always read the file, especially the paths the output doesn't show
  - Fill-in templates with 4 blanks still work well (TryGetFee fix ✅). The hint ladder (trace one call → template) solved both bugs on Day 12
  - **In projects, give the EXPECTED output; don't ask them to guess their own new code** (Day 16: "think like a human, how is the guess possible?"). Their job is to compare expected vs actual line by line. Guessing stays for small examples and quizzes
  - **They skip parts of a multi-part step and still commit** (Day 16: the `citys` rename, 4 polish fixes asked twice, `Program.cs` left out of a commit). When a step has more than 1 edit, give the **exact replacement lines**, and check the file + `git status` before moving on
  - **Commenting out old code is a habit** (5 times by Day 16). In examples files: keep old code running. In projects: delete it, Git keeps it
  - Day 16 pace (a full study day): 4 topics + a 93-line project in ~9.5 hrs (11:25 AM–8:15 PM, plus the day-end). A topic with exercise + quiz takes ~1–1.5 hrs, more than planned

---

## Day 18: Mon 26 Oct 2026 · Phase 2: classes, objects and properties

(Office PC, new duty 10 AM–10 PM. The chat opened at 10:09 AM, but work kept them busy; the lesson ran from about 6:40 PM to 9:30 PM.)

**Learned**

- **Shipment form story** (replaces the cookie story): blank form = **class**, filled form = **object / instance**, a box = **property**, the folder = `List<T>`
- A 3rd object (Omar) in the list → `foreach` runs **3 rounds**, one per object; `students.Count` = 3
- **Accumulator over a property**: `totalAge = totalAge + s.Age;` inside the loop, declared before it
- **One variable per job**: a local `lineValue` inside the loop (fresh every round) + the `totalPrice` accumulator before the loop (keeps its value)
- `new Product()` = **one object**; `new List<Product>()` = an **empty list**
- Classes go **under** the top-level code, or **CS8803**. A build error is a **compile error**, not "thrown" (throw = exceptions at run time)

**Built**

- `01-classes-objects`: a 3rd student + total age. Commits `Add classes and objects example`, `Sum student ages with an accumulator`
- **Product list exercise** (same folder): `Product` class (Name/`decimal` Price/Quantity), 3 products, line values + total value `15.500 KD`. Commit `Add product list exercise`

**Quiz scores**

- Check question (Omar): rounds ✅, whole output ½ (wrote only the newest line)
- Total age prediction ✅ (`20 + 22 = 42`, `42 + 25 = 67`, written out)
- **Classes and objects quiz: 2.5/5** (Q1 ❌: the question was unclear, Claude's fault; Q2 ❌: said `new Product()` creates an empty list; Q3 ✅; Q4 ½: right reason, but added an unneeded local variable and didn't write the line; Q5 ✅). Re-check "which line makes the list, which makes the object" ✅

**Mistakes to remember (review these)**

- **Whole output again:** wrote only `Omar | 25` and put `Total: 3` on the same line. `foreach` prints **every** object, and every `WriteLine` is its own line
- `totalPrice = p.Price * p.Quantity;` → **overwrote** the accumulator (total = the last product, 7.000)
- `totalPrice +=` and printed `totalPrice` per line → running totals (8.500, 15.500) in the product lines: **one variable doing two jobs**
- `new Product()` vs `new List<Product>()` (the folder vs one form)
- Still **commented out** old code in the examples file (the `s1`/`s2` block, the 6th time)
- ✅ Wins: fixed both accumulator bugs from the output alone with 1 hint each; wrote the sum out step by step; checked "files changed" on all 3 commits; `Omar and Sara` right

**Claude's mistakes (so they don't happen again)**

- Quiz Q1 was worded badly ("what is the real term for...") and they didn't understand it. Ask it plainly: "the blank form is called a ___ in C#"

**Career**

- ✅ **LinkedIn post 02 published** (Phase 1 done + 3 things that surprised me as a Dart developer). The "Next:" line was updated to "I started classes this week"
- Shift: 10 AM–10 PM for the next 2 weeks (CLAUDE.md updated)

---

## Day 17: Sun 25 Oct 2026 · Phase 1 done: debugging + Git branches practice

(Office PC, a short evening session, stopped about 7:50 PM: they felt cold. No day-end that night; written on Mon 26.)

**Learned**

- **Debugging** in VS Code on the Shipment Tracker: F9 breakpoint, F5 start / continue, F10 step over, F11 step into (`FindIndex`), Shift+F5 stop, hover / Variables / Watch. Put the old `<= 0` bug back for a minute and saw `index = 0` go to the "not found" line
- **Git branches in practice:** `git switch -c feature/menu-spacing` → fixed the menu spacing leftover → commit → `git switch main` → `git merge` (fast-forward) → `git branch -d` → `git push`
- First look at **classes**: a `Student` class with `Name`/`Age`, two objects, a `List<Student>` + `foreach`; predictions correct

**Built**

- Commits `Mark phase 1 done`, `Move empty line above the menu` (made on the branch, merged into `main`)
- ✅ **Phase 1 done** (ROADMAP ticked 25 Oct)

**Quiz scores**

- **Debugging quiz: 3/5** (missed: the yellow line has NOT run yet; F5 while paused = continue to the next breakpoint)

**Mistakes to remember (review these)**

- The yellow line is the **next** line to run, not the one that just ran
- F5 while paused = **continue**, not restart

**Claude's mistakes (so they don't happen again)**

- The **cookie** story for classes confused them ("is cookie a real term?", it is a web term). Switched to the KPOST shipment form

---

## Day 16: Sat 24 Oct 2026 · Phase 1: nullable, exceptions, DateTime + Project 03 Shipment Tracker

(Office PC, a full study day. Fri 23 Oct had no study (too much work at home), so the string helpers exercise moved here. Started 11:25 AM, stopped at about 8:15 PM.)

**Learned**

- **Warm-up:** `name.Trim();` alone → the new string is thrown away (immutable) → `name = name.Trim();` ✅. Predicted `[ Omar ]` (1 space) for `"  Omar  "` (2 spaces) ½
- **Nullable:** `int?` can be null (`int x = null` → CS0037); null prints as **nothing** in `$"..."`; `.HasValue`; `??` fallback (CS0266 without it); `?.` skips the call on null (no `NullReferenceException`, warning CS8602); `??=` fills only if empty. `??` reads, `??=` writes
- **Exceptions:** `try` / `catch (FormatException)`: the rest of `try` is skipped; several `catch` blocks top to bottom, specific first (`Exception` first → CS0160); `catch (Exception ex)` + `ex.Message`; `finally` always runs; `throw new ArgumentException(...)` to **fail fast** instead of `return 0`; `{ex}` prints the **stack trace**, `{ex.Message}` only the text
- **DateTime:** `new DateTime(...)`, `DateTime.Now`, `AddDays` (immutable), format strings (`dd MMM yyyy HH:mm`, `MM` month vs `mm` minutes), `.DayOfWeek`, `due - sent` = `TimeSpan`, `.Days`; this PC's culture is `en-US` (month first)
- **Project 03:** parallel lists, `new List<string>()` (CS0168 → CS0165), `Console.ReadLine() ?? ""`, auto-generated ID `KP{1001 + numbers.Count}`, `for` with an index (not `foreach`), `IndexOf` → `-1`, off-by-one (`<= 0`), a `static` method with a `List<string>` parameter that throws, `try` / `catch` around the `switch`, shared scope across `case` blocks (CS0128)
- **Git branches (theory only, practice on Sun):** branch = a photocopy of the official notebook; `git switch -c feature/...`, `git branch`, `git switch main`, `git merge`; `feature/` and `fix/`; protected `main` + PRs
- Asked when the UI comes: Swagger in Phase 6 (Dec), HTML/CSS in Phase 9 (late Jan), Angular in Phase 10 (Feb). Offered console colours / Spectre.Console in Phase 3 (optional)

**Built**

- `31-string-helpers` exercise (clean a messy customer: Trim/ToUpper, `Replace().Replace()`, `Split` + `Trim` per part, `IsNullOrWhiteSpace` in an `if`). Commits `Add string helpers exercise`, `Restore string helpers examples`
- `32-nullable` examples + exercise (parcel details: floor, phone, coupon, branch). Commit `Add nullable examples and exercise`
- `33-try-catch` examples + exercise (`BoxesPerDriver` throws, 2 `catch` blocks + `finally`, 3 test runs). Commit `Add try/catch examples and exercise`
- `34-datetime` example. Commit `Add DateTime examples` (Project 03 was the DateTime exercise)
- **Project 03 Shipment Tracker** (93 lines): add, list, search, mark delivered, error handling. 6 commits from `Add Shipment Tracker menu skeleton` to `Polish Shipment Tracker names and messages`, plus the README (Claude drafted it)

**Quiz scores**

- Warm-up: Q2 ✅ Q3 ✅ Q1 ½ (spaces)
- Nullable predictions: Part 1 `[null]` ❌ (Dart habit), Part 2 values ✅ (not whole lines), Part 3 **4/4** ✅ (incl. `??=` ignoring `Jahra`)
- **Nullable quiz: 4.5/5** (Q5 ½: `??=` instead of `??`)
- try/catch predictions: Part 1 ✅ (missed `Start`/`End`), Part 2 **3/3** ✅ with reasons, Part 3 ✅ (missed `Error: `)
- **Exceptions quiz: 4.5/5** (Q4 ½: the main reason for `throw` is that `0` hides the bug)
- DateTime: 5/5 lines right; **DateTime quiz: 4/5** (Q4 ❌ said `string`, it's `TimeSpan`)

**Mistakes to remember (review these)**

- **Whole-line predictions slipped again:** `1` / `4` instead of `Boxes: 1`, missed `Start` / `End` and `Error: `, `3 days` instead of `3`
- Dart habits: `[null]` (C# prints nothing), `false` (C# prints `False`)
- `branch = "Main";` instead of `??=`: the output looked right because `branch` was null. Test with a value
- Copy-paste labels: `Driver:` on the phone line; `BOxes`, `more then`, `deliveyNumber`
- `{ex}` instead of `{ex.Message}` (found it in test run 3 ✅)
- `List<string> numbers;` with no `new` (the CS0168 warning was the hint) and `new {""}`
- `for (int i = numbers.Count; i <= 2; i++)` with `[0]` inside: start, stop and row were all fixed values
- `if (index <= 0)`: off-by-one, index 0 is valid
- `??` vs `??=` (quiz), `TimeSpan` (quiz)
- Commented out old code (the 5th time). Skipped parts of steps and committed anyway (rename, polish twice, `Program.cs` left out of a commit)
- ✅ Wins: found and fixed 3 real bugs with tests (`{ex}`, `<= 0`, the loop crash); `drivers <= 0` (blocked negatives too); explained why the 2nd `catch` ran; `01 Jan 2027` rollover; tested both paths on every exercise; checked "files changed" on most commits; a 93-line app that never crashes

**Claude's mistakes (so they don't happen again)**

- Asked them to guess the output of their own new project code. They pushed back, rightly: in projects, give the expected output to compare
- The plan at 11:25 AM was too optimistic (string + nullable alone took until 3 PM), so debugging and Phase 2 moved to Sun. Plan ~1–1.5 hrs per topic
- Drafted the README example before running the app: the empty-line position was wrong. Fixed at day-end from a real run
- During the day-end, re-saved `journey.json` with a different format (a 418-line diff); restored it and added only the new day

**Career**

- LinkedIn post 02 drafted for review: `career/linkedin/02-phase-1-done.md` (Phase 1 done + 3 things that surprised me as a Dart developer)
- Resume: Shipment Tracker project bullet added to `career/RESUME.md`

---

## Day 15: Thu 22 Oct 2026 · Phase 1: string helpers

(Office PC, duty 6:30 AM–6:30 PM. Started 7:10 AM with the warm-up, then busy at work most of the day; the string helpers lesson ran in the late afternoon, stopped at about 6:15 PM.)

**Learned**

- **Warm-up:** where does the default `= 2` go? Said "call site" ❌ → **method header** ✅ after the explanation (same mistake as Day 14 Q4). `PrintDelivery(5)` → CS1503, `city` is required and first
- **String methods:** `Trim`, `ToUpper`, `ToLower`, **method chaining** (`city.Trim().ToUpper()`)
- **Immutable:** a string method returns a **new** string; the original doesn't change. Keep it with `name = name.Trim();`
- `Contains` returns a `bool` and is **case-sensitive** (`ToLower()` first). C# prints `True` / `False`
- `Replace("-", "")` deletes with an **empty string**; `Split(",")` returns a `string[]`, the **separator** is removed
- `string.IsNullOrWhiteSpace(x)` is a **static method**: `True` for `null`, `""` or only spaces
- **CS0136:** declared `c` again after `foreach (string c in parts)` → the name is used in the enclosing scope. Fixed by renaming

**Built**

- `31-string-helpers`: all 5 examples in one file. Commit `Add string helpers examples`, 2 files ✅ (the exercise is still to do, in the same folder)

**Quiz scores**

- Warm-up (header vs call site): ❌ → ✅ on re-check
- Predictions: `Trim` 4 lines (immutable line 4 ✅, missed the `[ ]` and an `L`), `Contains` new example 2/2 ✅, `Replace` idea ✅ (one 5 missing, `195` slip), `Split` 5 lines ✅ (wrote `length = 3`), `IsNullOrWhiteSpace` 3/3 ✅
- String helpers quiz: **4.5/5** (Q3 ½: said "immutable" but called `name.Trim();` a typo; the fix is to assign it back)

**Mistakes to remember (review these)**

- Header vs call site, the 2nd day in a row. Ask it again in a warm-up next week
- Didn't know the word "predict" → it means "guess the output before you run it"
- Predicted without the `[ ]` brackets and wrote `length = 3`: predict the **whole line**, only what is in the quotes
- Copying slips: `HAWALI`, `9655551234`, `195`. Join the parts one by one and compare digit by digit
- Commented out all the old code when CS0136 appeared (the 3rd time commenting out). Read the error code first; delete dead code, Git keeps it
- Quiz Q3: `name.Trim();` alone is not a typo, the new string is just thrown away → `name = name.Trim();`
- ✅ Wins: understood **immutable** straight away; fixed CS0136 by renaming by themself; checked "2 files changed" on the commit; quiz 4.5/5

**Claude's mistakes (so they don't happen again)**

- Said "type it in a new scratch project" with no folder or command → gave exact steps after
- Named the example variable `c` without checking that their file already had `foreach (string c ...)` → CS0136

**Career**

- Nothing today. LinkedIn post 02 (Calculator v2) is still planned for Fri 23 Oct

---

## Day 14: Wed 21 Oct 2026 · Phase 1: optional and named parameters, Calculator v2 with methods

(Office PC, duty 6:30 AM–6:30 PM. Started 7:57 AM, studied in gaps through the day, stopped at about 6:15 PM; no time after duty.)

**Learned**

- **Warm-up:** `int GetFee(int)` + `double GetFee(int)` is not a valid overload: same parameter list, return type ignored ✅
- **Optional parameter:** a **default value** in the **method header** (`int days = 2`); leave it out at the call and the default is used
- **Named arguments** (`days: 5, city: "Hawalli"`) are matched by name, so the order doesn't matter; **positional arguments** follow the order (they worked this out by themself)
- **Optional parameters go last** (**CS1737**); a required parameter must be passed (**CS7036**)
- **Method header** vs **call site**
- **Calculator v2:** `IsValidOperator` (`==` with `||`) replaced the long `&&` check; **my own Try pattern** `TryCalculate(a, op, b, out double result)`: `false` + `result = 0` on divide by zero, `true` + the answer otherwise
- **CS8509:** a switch expression without `_` is not exhaustive → add the **discard arm**
- **Git:** `git restore <file>` throws away scratch edits; `git add -A` stages everything (check `git status` and the "N files changed" number)
- VS Code vs Visual Studio: stay on VS Code now; try Visual Studio Community in Phase 6 (ASP.NET Core)

**Built**

- `30-delivery-days`: `Courier.PrintDelivery(string city, int days = 2)` with a default, positional and named call. Correct on all 3 calls first time. Commit `Add optional and named parameters exercise`, 2 files ✅
- `projects/02-console-calculator` **v2**: commit `Extract operator check into IsValidOperator method` (1 file) ✅, then `TryCalculate` + loop rewrite + README "Versions" section (Claude drafted) + ROADMAP ticks. Commit `Calculator v2: move logic into IsValidOperator and TryCalculate`, 4 files ✅

**Quiz scores**

- Warm-up (overload by return type): ✅
- Quick check (`SendSms` header valid?): ✅ with the reason
- Optional / named parameters quiz: **3.5/5** (Q1 ½: missed the optional part, Q4 ❌: header vs call; re-check ✅)
- Predictions: `1 copy` default ✅, `Omar: 2 copy` ✅ (ran before writing it), exercise 30 logic ✅ (text `Deliver` vs `Delivery` ½), `5 + 3 = 8` ✅, `10 * 4 = 40` ✅

**Mistakes to remember (review these)**

- Typed the first example into `29-box-fee` and commented the old code out (fixed with `git restore`). Use a scratch place, or don't commit it
- Answered a question instead of writing the prediction; added a line instead of replacing it. Write the prediction first
- Predicted `Deliver to...` but their code printed `Delivery to...`: predict from **your own code**, read the text in quotes
- Quiz Q1: answered only half (required, but not optional + default)
- Quiz Q4: didn't know **method header** vs **call site**
- Tested only the bad path of `IsValidOperator` first; asked to test the good path too
- `TryCalculate`: last arm `"/"` instead of `_` (CS8509), `true` / `false` swapped, `result = a` instead of `0` on failure. Fixed one at a time from hints
- Commented out the old `switch` again (Day 13 lesson): delete dead code, Git keeps it
- Typo `dicide`
- ✅ Wins: worked out by themself that named arguments don't need the order; exercise 30 perfect first time; `IsValidOperator` blanks right first time; fixed `true`/`false` from a small hint; tested both paths in one run; checked "N files changed" every commit

**Career**

- Nothing today. Next: LinkedIn post 02 (Calculator v2 with methods) on Fri 23 Oct; Claude drafts it

---

## Day 13: Tue 20 Oct 2026 · Phase 1: `ref` / `out` quiz, method overloading

(Office PC, first day of the new shift 6:30 AM–6:30 PM. Started 7:04 AM, focused until about 8:15 AM, busy at work until 5:36 PM, stopped at about 6:30 PM.)

**Learned**

- **Parameter = type + name:** in `double AddDeliveryFee(double price)` the second `double` is the **parameter type** and `price` is the **parameter name**
- **`ref` vs `out` recap:** `ref` needs a value **before** the call (two-way); `out` is filled **by the method** (one-way out). Using an empty variable with `ref` gives **CS0165**
- **`TryParse` is all-or-nothing:** `"12a"` → `false` and `number = 0` (the default), not `12`
- **Overloading:** the same name with different parameters (**count** or **types**). C# picks the overload that **matches the arguments** (overload resolution), not by order in the file
- The **return type doesn't count** (CS0111). **Local functions** in top-level statements **can't be overloaded** (CS0128 + CS1501), so overloads go in a `static class` with `public static`
- **Compile-time error** (doesn't build) vs **runtime error** (crashes while running)
- **Don't reassign a parameter** (`boxes = boxes * 2` makes the name lie); **DRY**: overload 2 calls `GetFee(boxes)`

**Built**

- `28-print-label`: `PrintLabel` overloads by count in `static class Labels`, then `Prices.Show(int)` / `Show(double)`. Commits `Add print label overloading example` (2 files) and `Add price overloading by type` (2 files, with the `ref` practice in `23-methods`) ✅
- `29-box-fee`: `Fees.GetFee(int)` and `GetFee(int, string)` (+3 KD for Jahra). All paths right on the first try; review fixes: local `fee` variable, then overload 2 calls overload 1. Commit `Add box fee overloading exercise`, 2 files ✅

**Quiz scores**

- Warm-up (label line 1): 2/3 (parameter name ❌)
- `ref` / `out` quiz: **4/5** (Q3 swapped ½, Q5 `number = 12` ½)
- Quick check `Prices.Show(10)`: ✅ with the reason
- Overloading quiz: **3/5** (Q2 reason ½, Q4 reason ½, Q5 ❌)

**Mistakes to remember (review these)**

- Said the parameter name is `double` (again, same as Day 12): it's `price`. Type, then name
- Swapped `ref` / `out`: put the empty `a` with `ref` and `b = 10` with `out`
- Thought `TryParse("12a")` keeps `12`: it gives `0`
- Called a compile error a "runtime error"
- `Lables` typo (3 places, still ran). Use F2 rename
- `boxes = boxes * 2;` (reassigned the parameter) and `boxes * 2` in both overloads (duplicated logic)
- Quiz: "overloads must have the same return type" (backwards: the return type is ignored)
- Quiz: "it runs from top to bottom" (C# picks by matching arguments)
- ✅ Wins: predicted both `PrintLabel` lines and `Whole price: 10 KD` with the reason; exercise 29 correct on every path first time with the `else` kept; commented out old code by themself to keep it (taught: Git keeps the history, so delete it); ran the check themself before saying done

**Career**

- Nothing today (busy shift)

---

## Day 12: Mon 19 Oct 2026 · Phase 1: methods part 2 (`bool` methods, a method calling a method), `ref` / `out`

(Office PC, duty day. Started 10:15 AM, studied in free gaps, focused from about 7:30 PM, stopped around 10 PM.)

**Learned**

- **Line 1 of a method:** the type **before the name** is the **return type** (what it gives back). Inside `( )` comes the **parameter**: type + **name** (`price`)
- **`bool` methods:** return `true` / `false`; `return` **stops the method** right away. Call them straight inside `if (IsHeavy(12))`. C# prints `True` / `False` with a capital letter
- **`else` has no condition and no `;`.** `else IsHeavy(4.5);` ends the `else`, so the `{ }` after it is a standalone block that **always** runs
- **Threshold** (the limit, 10 kg, lives in one method) and **boundary value** (`10 > 10` is false → bike)
- **A method that calls a method:** `PrintBill` → `AddTax`, `PrintVehicle` → `IsHeavy`. Three big `if` / `else` blocks became three one-line calls. Two methods can each have their own `weight` parameter (separate **scope**)
- **Pass by value** (a copy, the default) vs **`ref`** (the original; `ref` in both places; needs a value first)
- **`out`:** an extra result; the method must fill it before **every** `return` (**CS0177**). The **Try pattern** = `bool` "did it work?" + the result through `out`, like `int.TryParse`

**Built**

- `23-methods`: `IsAdult` + `if`, `AddTax`/`PrintBill`, `AddBonus` by value and `ref`, `SplitPrice` with `out`. Commits `Add bool method practice` (1 file), part of `Add method calling method practice and delivery vehicle`, `Add ref and out practice` (1 file) ✅
- `25-heavy-parcel` (`IsHeavy` + 3 `if` / `else`). Commit `Add heavy parcel bool method exercise`, 2 files ✅ (typo `exerise` amended before the push)
- `26-delivery-vehicle` (`PrintVehicle` calls `IsHeavy`). Perfect on the first try. Commit with `23-methods`, 3 files ✅
- `27-parcel-fee` (`TryGetFee` with `out`). Commit `Add parcel fee out parameter exercise`, 2 files ✅

**Quiz scores**

- Methods quiz: **3.5/5** (Q1 return type ½, Q2 parameter = name ½, Q3 ✅, Q4 CS1503 ½, Q5 ✅)
- Quick checks / predictions: **8.5/10** (`IsAdult` ✅, `if (IsAdult(15))` ✅, IsHeavy line 1 + boundary ✅, `AddTax` numbers only ½, `PrintVehicle` full lines ✅, by value ✅, `ref` ✅, `SplitPrice` line ½, CS0177 return count ✅, TryGetFee line 1 missing comma ½)
- `ref` / `out` quiz: first thing tomorrow

**Mistakes to remember (review these)**

- Said `double` in `double AddDeliveryFee(...)` means "accepts only double": mixed up the **return type** and the **parameter type**
- Said the parameter is `double`: the parameter is the **name** (`price`)
- Knew the "same order" rule, but not the result: a **compile error CS1503**
- Exercise 25: no `else`, so only 1 line printed. Had written `else`, then **deleted it** because unsure. Then `else IsHeavy(4.5);` + a standalone block: the output was right **by accident**
- `AddTxt` typo; left ` KD` out of the string; predicted only the numbers, not the whole line
- `SplitPrice`: worked out `5` and `true` correctly, then predicted `50 5` (the line prints `{ok}`, not the total). The answer didn't come from the working (same as Day 8)
- `TryGetFee` line 1 without the comma between parameters
- `TryGetFee` v1: `return weight <= 0;` (backwards: `true` for a bad weight) and no bad-weight path (−2 → `Fee: -1 KD`)
- **Hidden bug:** `fee = 0.5;` on the bad path (the rule said 0). The output looked right because the `else` never prints the fee
- Pasted code in chat that didn't match the file (`true` / `false` swapped)
- No prediction before running exercise 25 and the first run of exercise 27
- ✅ Wins: boundary 10 → bike with the right reason (`>` not `>=`); asked "what is the base weight?" (→ **threshold**); exercise 26 perfect with full-line predictions; pass by value and `ref` predicted right; **experimented on their own** (`total > 51` → `False 5`) and understood that the `out` value is filled either way

**Career**

- Nothing new today (code day). LinkedIn post 02 is planned for Fri 23 Oct

## Day 11: Sun 18 Oct 2026 · Phase 1: `List<T>`, methods part 1 (`void`, parameters, `return`)

(Office PC, duty day. Started 12:29 PM, studied in free gaps, focused from about 8 PM, stopped around 10 PM.)

**Learned**

- **Arrays revision:** the last index is **`Length - 1`** (arrays are **zero-based**). An accumulator inside the loop resets every round **and** is out of **scope** after `}`
- **`List<T>`:** a list that can grow. `new List<string>()`, `.Add`, `.Remove`, **`.Count`** (arrays use `.Length`), index `[0]`, `foreach`. `<T>` is the **type parameter**, so it's a **generic** type. Use a list when the number of items changes while the program runs
- **Methods:** a named block of code. **Define** it once, **call** it many times. Every call runs the **whole method body** (3 calls × 2 lines = 6 lines)
- **`void`** = does a job, gives nothing back. A **return type** (`double`) + `return value;` sends a value back to the caller, and the method stops there
- **Parameters** (`string city, double cost`) are filled by the **arguments** in the call, in the **same order**. Inside the method you use the **parameter name**: `{city}`, not `{PrintReceipt}`
- **One method, one job:** `CalculateShipping` calculates, `PrintReceipt` prints. Store the return value, then pass it on
- `*` is the multiply operator (`+ - * /`)

**Built**

- `21-list` (drivers list), `22-delivery-queue` (Add/Remove/Count/[0]/foreach, nothing hard-coded). Commit `Add List and delivery queue lessons`, 4 files ✅
- `23-methods` (`PrintLabel`, `AddDeliveryFee`), `24-shipping-cost` (`CalculateShipping` + `PrintReceipt`, 2 parcels). Commit `Add methods and shipping cost lessons`, 5 files ✅
- Day 10 files committed: `Add Day 10 progress and book chapters`, 11 files ✅

**Quiz scores**

- Arrays quiz: **3.5/5** (Q1 rule `Length - 1` ½, Q2 ✅, Q3 ✅, Q4 scope only ½, Q5 loop variable vs accumulator ½)
- `List<T>` quiz: **4.5/5** (Q4 "when to use a list" ½)
- Methods quick checks: **2/2** (4 calls × 3 lines = 12 ✅, `Ravi → stop 12` ✅)
- Methods quiz: first thing tomorrow

**Mistakes to remember (review these)**

- Knew the last index was 3 but not the rule `Length - 1`
- Arrays Q4: only said "can't use it after `}`", missed that it **resets to 0 every round**
- `First driver: {drivers.Count}`: copied the line above and didn't change the `{ }` part; then fixed the **wrong line** (both lines swapped). Read the label next to the code
- Ran the delivery queue before saving (6 lines instead of 7); wrote `Still waiting: 3: {parcels.Count}` (a hand-typed `3`)
- Predicted 4 lines for 3 `PrintLabel` calls: thought the dashes print once. Every call runs the whole body
- Typo `Totol`
- Shipping cost: `weightKg + fee` for "0.5 KD per kg" (should be `*`); then wrote `,`: didn't know `*` is multiply
- Put the **method name** inside `{ }` (`{CalculateShipping}`, then `{PrintReceipt}` → printed `System.Action...`) instead of the parameter names `city` / `cost`. Needed the answer
- Passed the weight (`4`) straight in as the cost, so `CalculateShipping` was never called (warning CS8321)
- No prediction before running the shipping cost exercise
- ✅ Wins: predictions right for the drivers list, the delivery queue and `AddDeliveryFee` (with the sums written out); read `parcels[1]` **before** `Remove` (smart); asked "then what is the use of CalculateShipping?" (exactly the right question)

**Career**

- Nothing new today (code day)

---

## Day 10: Sat 17 Oct 2026 · Phase 1: career catch-up, Calculator v1, arrays + `foreach`

(Office PC. Started 12:43 PM, stopped around 8:50 PM. Friday's home-laptop plan didn't happen: .NET was installed at home on Fri night, but it was 10 PM, so the work moved to today.)

**Learned**

- **`int ÷ int` cuts off the decimals** (`7 / 2` = 3, `7.0 / 2` = 3.5). `double` keeps them
- **`double.TryParse(input, out double x)`**: like `int.TryParse`. The `out` box must be plain `double`, not `double?` (CS1503)
- **`double / 0` gives `∞`** (Infinity) instead of crashing (`0.0 / 0` = NaN), so add a guard: `if (secondNumber == 0)`. Only the divisor matters
- **`switch` on a string**: `case "+":`, exact match, one case runs
- **Operator guard** right after reading it: `op != "+" && op != "-" && ...` (with `||` every operator is rejected). Keep `default` as a safety net
- **`while (true)` + `break`** = an infinite loop with a break exit
- **Arrays**: `int[] weights = { 12, 7, 30 }`, index `0` to `Length - 1`, fixed size, `IndexOutOfRangeException`
- **`foreach (double parcelWeight in weights)`** + accumulator + counter declared before the loop, results printed after it

**Built**

- **Career:** LinkedIn post 01 (Number Guessing Game) **posted** ✅, resume **Experience** + Education rewritten from the KPOST-HR and KPOST IT code (dev-only bullets), new LinkedIn headline (with .NET keywords). Commits: `Add LinkedIn post 01 and resume experience` (only PROGRESS.md, `career` was forgotten) + `Add LinkedIn post 01, resume experience and screenshots` (5 files ✅)
- **Project 02: Console Calculator v1**: `while (true)`, `q` to quit, `double.TryParse` guards for both numbers, operator guard with `&&`, zero guard, switch on a string. All 5 tests pass. README (Claude will draft future ones). Commit `Add console calculator v1`, 5 files ✅
- `18-double-tryparse` (renamed from `DoubleTryParse`), `19-arrays`, `20-parcel-weights`. Commit `Add arrays and parcel weights lessons`, 8 files ✅

**Quiz scores**

- Revision quiz (`%`, `||` edges, `break`/`continue`, exit reason): **3/4 + bonus** (the exit reason went from 0 on Thursday to correct today)
- Calculator quiz: **3.5/5** (Q1 `7 / 2` ½, Q2 ✅, Q3 `"+ "` ½, Q4 `||` trap ½, Q5 ✅)
- Arrays: the exercise was done; the quiz is first thing tomorrow

**Mistakes to remember (review these)**

- Said `5 % 7` is "false" (`%` always gives a number: 5)
- Wrote `18 < 17` for `age < 18` with age 17 (keep the order, swap only the value)
- Added up the values in a `WriteLine(i)` trace (1, 3, 7, 12). No `sum` in the code → nothing adds up
- `while (firstNumber == secoundNumber)` as the loop condition; then suggested `!=` and `firstNumber == 'q'`. The loop should be `while (true)` with the `q` break
- `double? firstNumber` with `out` → CS1503
- `break` instead of `continue` in the operator guard (the same mix-up as Day 9)
- Predicted that a switch prints 2 cases; said `7 / 2` = 3.5
- Answered the `||` question from the rule without writing out the sides
- README: saved in the wrong folder, no code block (the formatter turned `*` into `_`), placeholders left, "returns cannot divide by zero" instead of ∞
- Arrays exercise: hard-coded `"Heavy parcels: 2"` inside the loop, named the loop box `totalWeight`, `weight[0 + 1 + 2 + 3 + 4]` → crash, `if (total > 10)` → 4 instead of 2
- Forgot the `career` folder in `git add` again (4th time). Always compare the "N files changed" number
- ✅ Win: in the arrays exercise both results were printed **after** the loop on the first try

**Career**

- Shared the LinkedIn PDF. KPOST real dates: joined **24 Jun 2023 as IT Support Specialist**, Flutter apps since **Jan 2024**, still doing both. The developer resume has no IT-support bullets (their choice) and no videography. The 1-month course after 10th standard is **not** a postgraduate degree: removed from the resume; they will remove it from LinkedIn too, plus the duplicate BSc entry
- Second app found: **KPOST IT** (assets by department, barcode PC lookup, network wall-box/patch-panel mapping). They also add features and upgrade packages in 2–3 of their senior's apps
- Told Claude firmly: be careful with everything (naming, facts, commands). It's their next 10 years

---

## Day 9: Thu 15 Oct 2026 · Phase 1: `%`, `||`, guard clauses in loops, Guessing Game v1.1

(Started 10:07 AM, studied in free hours during a full-day duty, stopped around 7:30 PM.)

**Learned**

- **`%` = the remainder (modulo)**, not percent and not divide: `7 % 3` = 1 (7 sweets, 3 kids, 1 left over), `6 % 3` = 0. `x % 3 == 0` = "x is a multiple of 3"
- **Tracing with the update before `continue`:** the condition checks `6 < 7`, then `i++` makes 7, and 7 is still processed (sum = 19). A row with `continue` = yes can't change `sum`
- **`||` (OR):** one true is enough; `&&` (AND): both must be true. `>` is strictly greater (40 > 40 is false), `>=` includes the edge
- **Range check:** `guessNumber < 1 || guessNumber > 100` keeps 1 and 100 allowed. The check goes **before** `numberOfAttempts++`
- **Guard clauses with `continue`:** reject the bad case first (`!int.TryParse` → message → `continue`), so the loop body is flat instead of a staircase. Order matters: quit → not a number → out of range → count
- **String `==`:** `input == "q"`, double quotes, case-sensitive (`Q` doesn't quit)
- **`break` vs `continue` in the game:** `break` after a bad guess ended the whole game; `continue` asks again
- **The exit reason:** a loop with a `break` has 2 exits (won or quit), so after the loop check `guessNumber == secretNumber` before printing "Correct!"
- **CS0162 unreachable code:** lines after `break` in the same block can never run (a yellow warning)

**Built**

- `projects/01-number-guessing-game` **v1.1**: range check (not counted), flat guard clauses, `q` to quit with `The number was N.`, "Correct!" only if they really won. Tested: `abc`, `hi`, `500`, `0`, `Q`, `q`, a win in 5 and 6 attempts ✅. README updated (real example, 3 new "practiced" bullets, 3 ideas for later)
- Commit `Add range check and wuit to guessing game` (typo `wuit`, already pushed, left as is), **2 files changed** ✅ (the `git add` count was right this time)

**Quiz scores**

- Warm-up trace 1 (`while` + `continue`, skip multiples of 3): **½** (finished with step-by-step help: `%` unknown, added the remainder instead of `i`, said row 7 doesn't run, 12 + 7 = 21)
- Warm-up trace 2 (`do-while` + `break`): **1** (one fix: `1 < 3` → yes)
- `||` temperatures: **3/4** (40 > 40 → said "Danger")
- v1.1 quiz: **3.5/5** (Q1 `%` ✅, Q2 `||` ✅, Q3 "why `q` before TryParse" ½, Q4 break/continue trace ✅, Q5 exit reason ❌, the question was worded badly)

**Mistakes to remember (review these)**

- Thought `%` meant divide / percent; used the Windows Calculator `%` button (that's percent)
- In a trace: added the remainder to `sum` instead of `i`; rows said "continue = yes" but still added; adding slips (7 + 5 = 8, 12 + 7 = 21)
- Thought the last row (`6 < 7` → `i` becomes 7) doesn't run
- Used `break` instead of `continue` for the range check → one bad guess ended the game with "Correct! 0 attempts"
- Range message said the opposite (`Enter number below 1 or grater 100`), `grater` for `greater`
- `{input}` instead of `{secretNumber}` in `The number was ...` (printed `q`)
- Moved the after-loop "Correct!" code **into** the loop twice (once into the `q` block, once above the TryParse guard). The same "inside vs outside the loop" mistake as Day 8
- Deleted `break` because of the CS0162 warning, instead of moving the lines after it
- Started coding "Play again?" because it was listed in the README's "What I'd add next" (my message was unclear)
- README: copied my hint text into a bullet, missing backticks, the old line left next to the new bullets
- Commit typo `wuit`

**Career**

- Told me their real history: BSc IT 2020, web dev 2 months (2021), videography (2022), IT Support Syrma SGS Bengaluru (Jan 2023), IT Support KPOST Kuwait (May 2023 to now), Flutter since Sep 2024 (FITA Academy), 5–7 apps, **KPOST-HR** is in production for company staff (its backend is ASP.NET, written by their senior)
- Talked about how to present the experience honestly: the **real** ~2 years of in-house development count. Idea: get real .NET work inside KPOST from Phase 6
- **Phase 14 main project chosen: KACT** (the charity app), to be rebuilt in ASP.NET Core + SQL Server + Angular, MVP first
- LinkedIn: only the Day 0 post so far → the "Week 1" post is tomorrow, then every Friday

---

## Day 8: Wed 14 Oct 2026 · Phase 1: Git catch-up, `do-while`, `break` / `continue`

(Started 11:00 AM, studied in free hours during a full-day duty with a prayer break, stopped around 9:30 PM.)

**Learned**

- **Git (revision of Day 7, new angles):** the staging area is a **basket**: the order of `git add` doesn't matter, a commit takes everything in the basket. Empty the basket (`git restore --staged`) **before** `--amend`. Amend makes a **new commit ID**, an amend with an empty basket only changes the message. LF/CRLF warnings are harmless. `HEAD -> main` vs `origin/main` in `git log`
- **Tracing `for`:** the `i = 0` row counts as an iteration; `total += i` adds `i`, not `i + 1`; `i` and `total` are separate variables. The answer = the value in the last **true** row
- **`do-while`:** post-test loop, the body runs **at least once**, the `;` after `while (...)` is required. `while` = pre-test, can run 0 times
- **Scope in do-while:** the condition is outside the `{ }` → declare before `do`, assign inside (CS0103 otherwise). Declare vs initialize
- **`bool` flag:** `ok = int.TryParse(input, out number);` then `if (!ok)` / `while (!ok)`. Name it after what `true` means; `== true` is extra; don't call TryParse twice. No dummy value needed (`int number;`)
- **`break`** leaves the whole loop; **`continue`** skips the rest of one iteration (in a `for`, the iterator still runs)

**Built**

- Day 7 in 3 atomic commits (`Add for loop lessons and times table exercise`, `Add project 01 to resume`, `Add Day 7 progress and for loop chapter`), fixed with 2 amends, pushed
- `lessons/phase-01/15-do-while`: while vs do-while demo + the CS0103 scope trap
- `lessons/phase-01/16-times-table-v2` (Exercise 14): ask until valid with a do-while + flag, then the table. Tests: `abc`, `hi`, `7` → 2 error lines + table + `Sum of all answers: 385` ✅
- `lessons/phase-01/17-break-continue`: break at 4, continue at 3
- 2 lesson commits (`Add do-while lessons and times table v2`, `Add break and coutinue lesson`), pushed

**Quiz scores**

- Tracing warm-up (`for`, `i = 0; i < 4`, `total += i`): **0.5/1** (first trace wrong; with a half-filled table: 4 runs ✅, printed 10 instead of 6 ❌)
- `do-while` quiz: **3/5** (Q1 ✅; Q2 "don't know" ❌, then solved with a trace table → 16; Q3 CS0103 ✅; Q4 (a) ✅ (b) didn't understand "empty list" ½; Q5 line A ✅, called CS0642 an error ½)
- `break` vs `continue` check: **2/2** ✅ (after 2 wrong predictions)

**Mistakes to remember (review these)**

- `git add` on `14-times-table` only, `13-for-loop` forgotten ("2 files changed" instead of 4). **The same mistake as Day 4**
- Staged the book chapter right before amending the lesson commit (it would have gone into the wrong commit)
- Commit typos: `excercise`, `progres` (amended), `coutinue` (already pushed, left as is), lowercase `project 01`
- Trace: added `i + 1` instead of `i`, let `i` jump to `total`'s value, and the final answer didn't match the table
- Typed `while (x < 5)` instead of `do` at the start of the do-while → only `end` printed
- Accepted an auto-complete that added `using System.Formats.Asn1;`
- Put the error message in a `{ }` **after** `} while (...);` → a standalone block that ran once, after the valid number
- `ok = number;` (an `int` into a `bool`)
- `ok = !int.TryParse(...)` (flag name lies), `if (ok == true)`, TryParse called again in the `while`
- Predicted `break` = skip one value, and `continue` = no effect (the English meaning)
- Said "initialize" for "declare"; called the CS0642 warning an error

**Career**

- Nothing new. Fri 16 Oct: LinkedIn "Week 1" post

---

## Day 7: Tue 13 Oct 2026 · Phase 1: Git cleanup + the `for` loop

(Started 10:26 AM, studied in free hours during a full-day duty, stopped around 9:45 PM. Wrapped up on Wed 14 Oct.)

**Learned**

- **Git:** `git diff` (`-` deletion, `+` addition, a space = **context line**), `git restore <file>` (discard edits, dangerous), `git restore --staged <file>` (unstage only, safe), **atomic commits**, `git commit --amend -m` / `--amend --no-edit` (only before a push), "ahead of origin by 3 commits" → `git push`, `HEAD -> main` vs `origin/main`
- **`for` loop:** initializer (runs **once**), condition (before **every** iteration), iterator (after every iteration). Order: init → check → **body** → iterator → check…
- The first body run uses the **initializer** value. N iterations = **N + 1** checks
- Counting down (`i--`), skipping (`i += 3`), `<` vs `<=` decides the last value (**off-by-one**)
- `for` when you **know the count**, `while` when you loop **until** something happens (their own words ✅)
- **Scope:** the loop variable and anything declared inside dies at the `}` → **CS0103**
- **Accumulator:** declare **before** the loop, update **inside** (`+=`, the compound assignment operator), print **after**. `+= i` sums, `+= 1` counts
- **Guard clause:** `if (!int.TryParse(input, out int number)) { ...; return; }` with `!` (logical NOT) + **early return**. They wrote it themselves from Dart memory (it was also in Day 3's lesson) and explained why `return` matters (without it: `number = 0`, a table of zeros)

**Built**

- Git: restored the accidental blank-line change in lesson 11, 3 atomic commits (`Add PIN lock validation loop lesson`, `Add Number Guessing Game project`, `Add Day 6 progress and guessing game chapter`), pushed. **Project 01 is on GitHub**
- `career/RESUME.md`: first project bullet (Number Guessing Game + GitHub link)
- `lessons/phase-01/13-for-loop`: countdown + accumulator examples
- `lessons/phase-01/14-times-table` (Exercise 13): `for` 1–10, accumulator sum, guard clause. Tests: 7 → 385, 3 → 165, hello → `That's not a number.` ✅. **Not committed yet**

**Quiz scores**

- Validation loops warm-up: **2.5/5** (attempts count ✅; "Your guess" prints on every iteration, 5 not 2 ❌; the success message is **after** the loop, the loop condition ends it ❌; why 0 can't win = the secret is 1–100 (½); "iteration" ❌)
- `for` loop quiz: **2/5** (the 3 parts ½: "iteration" instead of "iterator", forgot "initializer runs once"; `i = 0; i < 3` = 3 times / 4 checks ❌; `i = 2; i += 3` prints 2 first ❌; CS0103 not CS1083 ½; for vs while ✅). Retry with a trace table: the table was right, the output line wasn't (listed 4)

**Mistakes to remember (review these)**

- Answered "yes" to "`-` or `+`?", and thought the `WriteLine` **context line** had changed (only a blank line was deleted)
- Staged **3** things for an atomic commit (`git add` on the book chapter + PIN lesson + project). Caught it with `git status` before committing ✅, then fixed with `git restore --staged`
- Committed the book chapter alone as "Add Number Guessing **Exercise**" (wrong message, wrong grouping). `--amend` fixed the message but **`git add .` was skipped**, so "1 file changed". A second `--amend --no-edit` → 10 files ✅. **Read the "N files changed" line**
- Ran the countdown **before** predicting (3rd time in a row)
- `total += 1` instead of `total += i` → `Total: 4`
- Said "done" on the Times Table without the **sum line**. Then the error text: `That is not a number` → `This is not a number` → finally `That's not a number.` **Copy exact text from the spec**
- Thinks a line **at the top** of a loop only runs for valid input. No: it runs **every iteration**
- Thinks the program "stops" after a correct guess because nothing prints. No: the **loop condition** becomes false, the loop exits, the code **after** it runs
- Forgets that the **first** iteration uses the start value (0 or 2), and that the **body runs before the iterator**
- Trace table correct, but the output line copied values that were never printed (`10,8,6,4`). The output = only the "print" column
- Copy-paste slips in tables (`print 2` on the `i = 3` row). Read the answer once before sending

**Career**

- Project 01 pushed to GitHub, first resume bullet added. LinkedIn "Week 1" post planned for Fri 16 Oct

---

## Day 6: Mon 12 Oct 2026 · Phase 1: Project 01, Number Guessing Game

(Started 10:50 AM, worked between shifts, finished at 10 PM.)

**Learned**

- **Input validation loop:** `while` + `TryParse` + a **nested `if`**. Bad input goes to the `else` and **isn't counted**. `out pin` writes straight into the loop variable
- A line **above** the loop runs **once**, a line **inside** runs **every iteration**. The secret is picked once (they asked about this on their own ✅). `Random` inside the loop **overwrote** the player's guess
- 3 cases (high / low / equal) with `if` / `else if` and no final `else`: on "equal" the loop just ends
- `if` / `else` = **one** path. A line after an `if` with no `else` always runs
- **Testing:** hard-code the secret (`42`), test **every** path, then switch to `Random.Shared.Next(1, 101)`
- **Clean code:** meaningful names (`randomNumber` → `numberOfAttempts` with **F2 Rename Symbol**), formatting (`}` + `else` together, one blank line between blocks)
- **README** in Markdown, written honestly (Ctrl+Shift+V preview). **Binary search** guessing (7 tries or fewer)
- **Git:** renamed a folder + `.csproj` with `Rename-Item`, deleted a stray `obj` folder, `pathspec ... did not match any files` (nothing is staged), `git add .` is OK only when `git status` shows nothing else, "ahead of origin by 2 commits" → push. The LF/CRLF warning is harmless

**Built**

- Git: renamed `11-rool-until-six` → `11-roll-until-six`, 2 atomic commits (`Add while loop and Random lessons`, `Add Day 5 progress and while/Random chapter`), pushed
- `lessons/phase-01/12-pin-lock` (PIN door validation loop, tested with abc / 1111 / 4321 → 2 tries)
- `projects/01-number-guessing-game` + `README.md`: secret 1–100, validation loop, too high / too low, attempts counter, first-try bonus, 0 warnings. Won a real game in 8 attempts. **Not committed yet**

**Quiz scores**

- Warm-up (while + Random): 3/3 ✅ (zero iterations, the off-by-one explained in their own words, `Next(1, 10)` = 1–9 because the max is exclusive)
- No 5-question quiz today: do one at the start of Day 7

**Mistakes to remember (review these)**

- Typed the word `atomic` into a `git add` path blank → `fatal: pathspec`. Then staged `11-roll-until-six` twice and missed `10-random` (caught it with `git status` ✅)
- A typo created the stray folder `11-ro11l-until-six`
- Typed the PIN example into the **project's** `Program.cs` instead of the lesson folder
- Changed correct code (`tries = 0` → `1` → `2`) when only asked to **explain** why it printed 2. **Trace first, change second**
- Used `Random` for the **guess** (the player types the guess), and `Random` inside the loop **overwrote** the input. Also two variables for one guess (`guessNumber` + `inputNumber`)
- Counter named `randomNumber` (it's not random) → `numberOfAttempts`
- Bonus without `else`: a first-try win printed **two** lines. And only one of the two tests was run
- README first draft: "tested with 50" (it was 42), "max is 100" (the max passed is 101, exclusive), hint text left in, a leading space in the example
- ` I'm thinking...` had a space inside the quotes. `Too Low!` had a capital L (fixed)
- The prediction comment was skipped again
- Binary search: started at 42 instead of 50 → 8 tries instead of ≤ 7

**Career**

- Project 01 has a README. Resume bullet + LinkedIn mention after it's pushed (Day 7 / Fri 16 Oct)

---

## Day 5: Sun 11 Oct 2026 · Phase 1: `while` loops + `Random`

(A long day with work breaks in between: started 11:46 AM, finished after 9 PM.)

**Learned**

- **`while` loop**: the condition is checked **before** every **iteration**; when it's false, C# jumps past the `}`
- **Zero iterations**: if the condition is false at the start, the body never runs (tested with `bites = 0`)
- **Infinite loop**: nothing in the body changes the condition → the app **hangs** → **Ctrl+C**
- **Tracing / dry run** with a table (round, value at the check, true/false, output, value after)
- **`Random.Shared.Next(min, max)`**: `min` inclusive, `max` **exclusive** (`Next(1, 7)` = 1–6). Output is **non-deterministic**, but the range and the number of lines are predictable
- **Sentinel loop** ("loop until"): declare before the loop, a starting value that makes the condition true, update inside the loop. `"YES" != "yes"` (case-sensitive)
- **Off-by-one error**: `rolls++` after the print → total one too high. Fix: start at 0 and increment **before** the print
- Testing random code: **hard-code** the value for a moment (`Next(6, 7)`), test the edge case, then **revert**

**Built**

- `lessons/phase-01/09-while-loop` (the plate loop: 3 → 2 → 1 → "Plate empty")
- `lessons/phase-01/10-random` (3 dice rolls + the "Are you ready?" sentinel loop, tested with no / Yes / YES / yes)
- `lessons/phase-01/11-rool-until-six` (exercise: roll until a 6, count the rolls, "Lucky! First try!" bonus, 0 warnings. Got a real first-try 6!)

**Quiz scores**

- Warm-up (switch): 2/3 (CS8510 code forgotten, said a missing `break` gives no error, but it's CS0163)
- while + Random quiz: 2/5 (Q1 zero iterations wrong, Q2 + Q4 missing the why / error code, Q5 copied the model answer)

**Mistakes to remember (review these)**

- `Writeline` → **CS0117**. C# is case-sensitive: `WriteLine`
- `while (bites > 0) ;` → **CS0642** + the program hung. Then **moved** the `;` to the next line instead of deleting it. **Never** a `;` between `)` and `{`
- Ran without saving: the file hadn't changed. Look for the white dot ● on the tab, Ctrl+S
- First try of the exercise: `while (rolls <= 5)` (fixed count) instead of "until a 6". The loop must be controlled by `dice`
- `dice` declared inside the loop → the condition can't see it (scope). Declare before, `dice = ...` inside without `int`
- `"Got a {}"`: no `$` and no variable. And `$` is not needed when there's no `{ }`
- Off-by-one (spotted it without help ✅, then tried `rolls = 0`, which moved the bug to "Roll 0")
- Quiz: forgot to do the **first check** (`5 < 3` is false → zero iterations)
- The prediction comment was skipped in 2 of 3 programs. **"Done" = every step**
- Spelling: missging → **missing**, decler → **declare** (again), worng → **wrong**, rool → **roll**, realy → **really**

**Career**

- Nothing today (the LinkedIn "Week 1" post moves to Friday 16 Oct)

---

## Day 4: Sat 10 Oct 2026 · Phase 1: `switch` + Git skill

(Fri 9 Oct skipped: busy with other work. Today was an evening session, about 3 hrs.)

**Learned**

- **switch statement**: `case` / `break` / `default`; **stacked cases** (`case "Fri": case "Sat":`); every case needs `break` or you get **CS0163** (no fall-through, unlike Dart 3)
- **switch expression**: `var x = value switch { pattern => result, _ => ... };`, which returns a value. **Relational patterns** (`>= 90`), **`or` patterns** (`6 or 7`), the **discard** `_`
- Wrong order in a switch expression = **CS8510 unreachable** (a build error). In an if-else chain the same mistake gives a wrong answer silently
- **Exhaustive**: a switch expression without `_` → warning **CS8509**, and a **runtime crash** (`SwitchExpressionException`) when nothing matches. A switch statement without `default` just skips (no warning)
- Warning (yellow, still runs) vs error (red, no build); exception = runtime error; reading a **stack trace** ("Unmatched value was C", line 22)
- Error location `Program.cs(5,5)` = line 5, column 5
- `char` values need single quotes (`'A'`); without them C# looks for a variable called `A` → CS0103
- **Git:** `git status`, `git diff`, `git show --stat HEAD`, good commit messages (verb first, present tense, ~50 chars, "If applied, this commit will..."), **atomic commits**, `git commit --amend` (only before push, it makes a new ID), `--no-edit`, `git restore`, `git restore --staged`, `git revert <id>` (safe after push), the pager (`q`), escaping Vim (`Esc` → `:cq`), the LF/CRLF warning is harmless

**Built**

- `lessons/phase-01/07-switch` (traffic light switch statement + temperature switch expression)
- `lessons/phase-01/08-grade-calculator` (exercise: TryParse + range guard, switch expression for the grade, switch statement for the comment, all 9 tests pass)
- Git practice: 2 atomic commits, amend, restore, unstage, revert

**Quiz scores**

- Revision quiz (Day 3 weak spots): 4/5 (Q4 + Q5 missing the "why")
- Switch quiz: 3.5/5 (missed the CS8510 trap in Q1, the missing `break` in Q2, and team words in Q5)

**Mistakes to remember (review these)**

- Typo `'B' or 'D'` instead of `'C' or 'D'` → crash on 65. **Test every branch**, not only one value
- Added `_ => "Invalid"` to silence the warning, which hid the real missing case. `_` is a safety net, not a fix
- Range guard again without `return;`, and edges `<= 0` / `>= 100` refused valid marks 0 and 100
- `<= 50` as the last arm overlapped `>= 50`. Use `_` for "everything else"
- Ran before saving (old output for 0). Ctrl+S first
- Skipped the experiment steps and the test comments until reminded. **"Done" = every step** (Definition of Done)
- Git: forgot to `git add` one folder, so check `git status` (green) before commit. Commit message without quotes → Vim opened
- Commit messages: `Updated` → `Update` (present tense); keep it short
- Spelling: swich → **switch**, pratice → **practice**, Grate → **Great**, becaus → **because**, then → **than**, deceler → **declare**

**Career**

- Nothing today (Friday LinkedIn skipped, moved to next week)

---

## Day 3: Thu 8 Oct 2026 · Phase 1: `if` / `else`

**Learned**

- `if` / `else if` / `else`: checked top to bottom, **first match wins**, the rest is skipped
- Comparison `== != > < >= <=`; `=` **saves**, `==` **checks** (same as Dart)
- Edge numbers / boundary testing: `>=` includes the edge, `>` keeps it out (`0 <= 0` is true, `18 > 18` is false)
- `&&` (and), `||` (or), `!` (not); `"Y" == "y"` is false (capitals count)
- `return;` stops the program → **guard pattern**: check bad input first, stop, then the happy path
- `if (!int.TryParse(...))`: TryParse returns a bool, so it can go straight into the `if`
- A variable can change: `fee = fee * 0.5m` (no type the second time)
- **Scope**: a variable born inside `{ }` dies at `}`. Need it later → create it before the `{`, only change it inside
- Factory line: one box, each `if` changes it, print once at the end → no repeated code, no `else` needed
- "Cap" = maximum limit (`if (fee > Max) fee = Max;`); the order of discount vs cap is a business rule
- 50% off = × 0.5 (= ÷ 2); multiplying by less than 1 makes it smaller
- Save (Ctrl+S) before `dotnet run`: it only sees the saved file. Shift+Alt+F formats the file

**Built**

- `lessons/phase-01/04-parking-meter`: finished (`wholeHours` variable, typo fixed)
- `lessons/phase-01/05-if-else` (example: water temperature)
- `lessons/phase-01/06-parking-meter-v2` (exercise: guards, resident discount, daily cap 1.500 KWD). Went from 2/7 tests → 4/7 → all pass, with test comments

**Quiz scores**

- Warm-up (TryParse vs cast): results right, but gave the same "why" for both → TryParse **refuses** (false, 0), cast **cuts** (2)
- Scope check: 1.5/3 (did the experiment and saw CS0103 itself)
- if/else quiz: 1/5 → retry 2/4 → mini-check 2/2 (missed `>` at the edge, `=` vs `==`, first-match-wins, scope)

**Mistakes to remember (review these)**

- Forgot `return;` in a guard block → the program kept going (two messages, or asked the resident question after "Max 24 hours")
- `(int)PerHourRate` cut 0.250 → 0 so every fee was 0. Money stays `decimal`, never cast to `int`
- Used `TryParse` to check `y`/`n`. TryParse is only for numbers; compare text with `==`
- Variable born inside `if`/`else` → had to write the calculation + print twice. Born outside, change inside
- Did the fee math twice (`fee * PerHourRate` again in the print). Once the box has a value, just print the box
- Discount 0.125 vs 0.5: a discount is a multiplier (50% off = × 0.5), not a new rate
- `is...` names are only for bools (`isKuwaiti` held text → `residentAnswer`)
- Ran before saving → saw an old result (2.500). Ctrl+S first
- Spelling: hole → **whole**, becaus → because, fasle → false, ture → true, Confortable → Comfortable
- "Done" means every checklist item: the test comment was forgotten until reminded

**Career**

- Nothing today (LinkedIn is on Fridays)

---

## Day 2: Wed 7 Oct 2026 · Phase 1 started (4 days early)

**Learned**

- Data types: `int`, `double` (approximate), `decimal` (exact, `m` suffix, use for money), `bool`, `char` (single quotes), `string` (double quotes)
- `0.1 + 0.2` in double = `0.30000000000000004`; decimal = `0.3`
- Safe vs unsafe conversions: int → decimal/double is automatic (nothing lost); decimal and double can't be mixed
- `:F3` for KWD (3 fils digits). `:F` alone depends on the PC's region, so always write the number
- `var` (type is inferred and locked, must have a value), `const` (PascalCase, value known when you write the code)
- Casting `(int)2.75` → 2 (cuts, does not round)
- `Parse` crashes on bad input; `TryParse` returns bool + `out` value (0 on failure) and handles null, so there's no CS8604 warning
- `Console.Write` (same line) vs `Console.WriteLine` (new line)
- `string?` means "may be null"
- C# naming: camelCase for local variables, PascalCase for constants (and later classes/methods)

**Built**

- `lessons/phase-01/01-data-types` (example), `02-cafe-bill` (exercise)
- `lessons/phase-01/03-parse-tryparse` (example), `04-parking-meter` (exercise, one small fix left)

**Quiz scores**

- Data types quiz: 1.5/5 → retry 2/2 (missed the "safe vs unsafe pour" idea, and why double is bad for money)
- var/const/TryParse quiz: 2/5 → retry 3/3 (missed `var x;` without a value, why Parse warns on null, VAT should be decimal)

**Mistakes to remember (review these)**

- Dart habits: `String` → `string`; `'text'` is a char error in C#
- Rename with **F2**, not by hand (hand-renaming broke the build twice)
- Run `dotnet run` before saying "fixed" or "done"; "done" = every item on the checklist
- Read the output like a customer ("x1.000 cakes", "Fee: 0.750" with no currency)
- `F3` only on money, and always write the number (`:F3`, not `:F`)
- Cast syntax is `(int)value`, not `int(value)`
- TryParse failing → 0 (refuses) vs cast → cuts (`2.75` → 2). Two different tools
- Quiz answers need the **why**, not just the answer

**Career**

- Nothing today (LinkedIn is on Fridays)

---

## Day 1: Tue 6 Oct 2026 · Phase 0 ✅ complete

**Setup**

- .NET SDK 10.0.401 (runtime 10.0.12), Visual Studio 2026 Insiders (stable Community recommended), VS Code, Git 2.53
- GitHub repo: https://github.com/basithcreation/dotnet-fullstack-journey
- Git email changed from the work email to the personal email

**Learned**

- .NET = platform, C# = language, SDK = tools for developers (create/build), CLR = engine that runs the app for users
- `dotnet new console`, `dotnet run`, `dotnet build`; `.csproj` ≈ `pubspec.yaml` (TargetFramework, Nullable, OutputType, packages)
- `bin/` and `obj/` = generated build output; never commit them
- Top-level statements (no `Main` needed), `Console.WriteLine`, `Console.ReadLine` (returns `string?`)
- `int.Parse` (text → number), string interpolation `$"...{x}..."`, operators `+ - * / %`
- Integer division: `10 / 3 = 3` in C# (Dart gives 3.33; Dart uses `~/` for whole-number division)
- `DateTime.Now.Year`; magic numbers are bad
- Visual Studio Output window (debugger log) vs the console window; exit code 0 = success
- Git: init, add, commit, push, `.gitignore`, `git status --untracked-files=all`, README in Markdown, LF/CRLF warning is harmless

**Built**

- Project 00: Greeting CLI (name + birth year → age) → pushed to GitHub

**Quiz scores**

- Phase 0 quiz: 3.5/5 (re-learned SDK vs CLR, `.csproj` contents, integer division)
- Git quiz: 3.5/5 (commit = local snapshot, not just a message; Git only saves what you commit, so commit often)

**Mistakes to remember (review these)**

- Variable names must describe what is inside (`birthYear`, not `age`, for 2000)
- Delete dead commented code; keep notes in `lessons/`
- Check spelling before committing (`Imporve READMR` 😄)

**Career**

- LinkedIn post 00 published: https://lnkd.in/p/d6fXGat8
