# Learning Progress Log

Newest day at the top. Claude reads this at the start of each new chat to continue from the right place.

---

## ▶️ Next session starts here

- **First 5 minutes:** finish `04-parking-meter`: store `(int)averageStayHours` in a named variable and print `Average stay (whole hours): 2`; fix the "hole" → "whole" typo in the comment
- **Commit + push** today's work (`lessons/phase-01/`, `PROGRESS.md`, `ROADMAP.md`), e.g. "Day 2: data types, var/const, TryParse"
- **Next lesson: `if` / `else`.** Hook: it fixes the two bugs the student saw on Day 2 ("2026 years old" for `hello`, and "free parking" for `abc`, because TryParse failed and the program kept going with 0)
- Then: `switch` and switch expressions; quick check on operators + interpolation (already used a lot), then tick that roadmap item
- Project after Part 1: **01 Number Guessing Game** (Saturday 10 Oct = project day). It needs a simple loop, so teach a basic `while` first
- Quick warm-up question to start: "What's the difference between TryParse failing and a `(int)` cast?" (this was confusing on Day 2)

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
