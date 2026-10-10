# Learning Progress Log

Newest day at the top. Claude reads this at the start of each new chat to continue from the right place.

---

## ▶️ Next session starts here

- **First 5 minutes:** commit + push `ROADMAP.md`, `PROGRESS.md`, `CLAUDE.md`, `lessons/glossary.md` (one commit is fine: "Update Day 4 progress log"). Check spelling before Enter
- **Sun 11 Oct (2 hrs):** quick 3-question warm-up (switch expression order → CS8510, missing `break` → CS0163, why `gradeComment` is declared before the switch). Then teach a basic **`while` loop** and **`Random`** (`Random.Shared.Next(1, 101)`, the upper number is excluded) with small examples, then a small exercise
- **Mon 12 Oct:** **Project 01: Number Guessing Game** (Part 1) + README. Needs: `while`, `Random`, TryParse guard, `if`/`else`, a counter
- **LinkedIn "Week 1" post** was skipped on Friday. Draft it this week in `career/linkedin/` (Phase 0 done + data types, TryParse, if/else, switch, Git undo)
- Still to tick in ROADMAP: "Operators, string interpolation" (quick check, already used a lot)
- **How to teach this student:** ONE step per message with a fill-in template. Check the clock before suggesting breaks (sessions are often in the evening). Open the file before accepting "done": test comments and experiments were skipped 3 times today until reminded

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
