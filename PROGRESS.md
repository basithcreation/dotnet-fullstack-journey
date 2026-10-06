# Learning Progress Log

Newest day at the top. Claude reads this at the start of each new chat to continue from the right place.

---

## ▶️ Next session starts here
- **Phase 1: C# Bricks, Week 2: Boxes and choices**
- First lesson: data types `int`, `double`, `decimal` (why money must be `decimal`), `bool`, `char`, `string`
- Then: `var`, `const`, `TryParse` (fixes the CS8604 yellow warning properly), `if`/`else`, `switch`
- Project after Week 2: **01 Number Guessing Game**
- Pending from Day 1: rename the screenshot to `00-hello-dotnet.png`, then commit + push ("Complete Phase 0 and add LinkedIn post")

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
