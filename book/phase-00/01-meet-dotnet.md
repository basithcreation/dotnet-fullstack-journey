# Chapter 0.1: Meet .NET and your first program

> Learned: Tue 6 Oct 2026 · Code: `projects/00-greeting-cli`, `lessons/phase-00/notes.md`

---

## 🧸 LKG story

.NET is a **big toy box** from Microsoft. Inside are toys that can become websites, APIs, desktop apps, games and mobile apps.

**C#** is the **language** you speak to the toys. You tell them what to do in C#.

There are two helpers:
- The **SDK** is the **toolbox for the builder** (you, the developer). It has tools to create and build apps.
- The **CLR** is the **engine** inside the toy. It makes the app run on the user's computer.

🎬 **Animation idea:** a developer opens a toolbox (SDK) and builds a toy car. The car drives away on its own, powered by an engine labelled CLR. A user who only *plays* with the car never sees the toolbox.

---

## 💻 Real explanation

| Word | What it really is |
|---|---|
| **.NET** | The **platform**: runtime + libraries + tools. Free, open source, runs on Windows, Linux and Mac. |
| **C#** | The **programming language** you write. (.NET also supports F# and VB, but C# is the main one.) |
| **SDK** (Software Development Kit) | What **developers** install: the compiler, the `dotnet` command, templates. |
| **Runtime** / **CLR** (Common Language Runtime) | What **users** need to *run* the app. It runs your compiled code, manages memory (garbage collection), and more. |
| **.NET Framework** | The **old**, Windows-only version (up to 4.8). Don't learn it for new work. |
| **Modern .NET** | .NET 5, 6, 7, 8, 9, 10... We use **.NET 10 (LTS** = Long-Term Support, supported for 3 years). |

My setup: .NET SDK 10.0.401, VS Code, Visual Studio 2026, Git 2.53.

### The three commands you use every day

```
dotnet new console -o my-app    // create a new console project in folder my-app
dotnet run                      // build + run the project
dotnet build                    // only build (check for errors), don't run
```

### What's inside a project

```
my-app/
├── my-app.csproj   ← project settings (like pubspec.yaml)
├── Program.cs      ← your code
├── bin/            ← built app (generated, never commit)
└── obj/            ← temporary build files (generated, never commit)
```

The `.csproj` file holds:
- `TargetFramework`: which .NET version (`net10.0`)
- `OutputType`: `Exe` = a program you can run
- `Nullable`: `enable` = warn me about possible nulls
- Package references (later): the libraries you add

### Your first program

Modern C# uses **top-level statements**: you write code directly in `Program.cs`, without wrapping it in a `class` and a `Main` method.

```csharp
Console.WriteLine("What is your name?");
string? name = Console.ReadLine();
Console.WriteLine($"Hello {name}!");
```

- `Console.WriteLine(...)`: print a line of text
- `Console.ReadLine()`: wait for the user to type and press Enter. It returns `string?` (text that **may be null**)
- `$"Hello {name}!"`: **string interpolation**. Put a variable inside `{ }` in a `$` string.

### Text → number: `int.Parse`

`ReadLine` always gives you **text**. To do math, convert it:

```csharp
string? birthYearText = Console.ReadLine();
int birthYear = int.Parse(birthYearText);
int age = DateTime.Now.Year - birthYear;
Console.WriteLine($"Hello {name}! You are {age} years old.");
```

`DateTime.Now.Year` gives the current year from the computer clock.
(`int.Parse` crashes on bad input like `abc`. Chapter 1.2 shows the safe way: `TryParse`.)

### Math operators

| Operator | Meaning | Example | Result |
|---|---|---|---|
| `+` | add | `7 + 2` | `9` |
| `-` | subtract | `7 - 2` | `5` |
| `*` | multiply | `7 * 2` | `14` |
| `/` | divide | `7 / 2` | `3` ⚠️ |
| `%` | remainder (modulo) | `7 % 2` | `1` |

⚠️ **Integer division:** when both numbers are `int`, C# **throws away the decimal part**: `10 / 3` is `3`, not `3.33`. To get decimals, use a decimal type: `10.0 / 3` → `3.333...`

🎬 **Animation idea:** 10 cookies shared by 3 kids. Each kid gets 3 cookies (`10 / 3`), and 1 cookie is left on the plate (`10 % 3`).

### Exit code
When a program finishes, it returns an **exit code**. `0` = success. Visual Studio shows this in the Output window ("exited with code 0").

---

## 🎯 Dart comparison

| | Dart / Flutter | C# / .NET |
|---|---|---|
| Project file | `pubspec.yaml` | `.csproj` |
| Create | `dart create` / `flutter create` | `dotnet new console` |
| Run | `dart run` / `flutter run` | `dotnet run` |
| Entry point | `void main() { }` | top-level statements (or `static void Main()`) |
| Print | `print('Hi')` | `Console.WriteLine("Hi")` |
| Read input | `stdin.readLineSync()` → `String?` | `Console.ReadLine()` → `string?` |
| Interpolation | `'Hi $name'` / `'${a + b}'` | `$"Hi {name}"` / `$"{a + b}"` |
| Text → int | `int.parse('5')` | `int.Parse("5")` |
| `10 / 3` | `3.333...` (always a double) | `3` (int ÷ int = int) |
| Whole-number division | `10 ~/ 3` → `3` | `10 / 3` → `3` |

---

## 🐞 Errors and lessons from my code

| What happened | Why | Lesson |
|---|---|---|
| Named a variable `age` but stored the birth year (2000) in it | The name lied about the content | Names must describe what's inside: `birthYear` |
| Left lots of old code commented out in `Program.cs` | "Dead code" makes files hard to read | Delete it. Keep notes in `lessons/`, Git remembers old versions |
| `2030 - DateTime.Now.Year` with `2030` typed directly | A **magic number**: nobody knows what 2030 means | Give it a name: `const int TargetYear = 2030;` |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| toy box | **platform** / **framework** | "We're on .NET 10, the current LTS." |
| builder's toolbox | **SDK** | "Install the .NET 10 SDK to build the project." |
| engine | **runtime** / **CLR** | "The server only needs the runtime, not the SDK." |
| settings file | **project file** (`.csproj`) | "Add the package reference to the csproj." |
| generated folders | **build output** / **build artifacts** (`bin/`, `obj/`) | "Don't commit bin and obj." |
| code straight in Program.cs | **top-level statements** | "It's a minimal console app with top-level statements." |
| `$"Hi {x}"` | **string interpolation** | "Use interpolation instead of `+`." |
| unnamed number | **magic number** | "Extract that magic number into a constant." |

---

## 📋 Summary

- **.NET** = platform, **C#** = language, **SDK** = developer tools, **CLR** = engine that runs the app
- `dotnet new console`, `dotnet run`, `dotnet build`
- `.csproj` ≈ `pubspec.yaml`; never commit `bin/` and `obj/`
- `Console.WriteLine` prints, `Console.ReadLine` reads text (`string?`)
- `int.Parse` turns text into a number (it crashes on bad input)
- `int / int` = whole number (`10 / 3 = 3`); `%` gives the remainder

---

## 📝 Quiz

1. What is the difference between the SDK and the CLR?
2. Which two folders should never be committed, and why?
3. What does `10 / 3` give in C#? And in Dart?
4. What does `17 % 5` give?
5. What type does `Console.ReadLine()` return, and what does the `?` mean?

<details>
<summary>Answers</summary>

1. The **SDK** is for developers, to create and build apps. The **CLR** (runtime) is the engine that runs the app. Users only need the runtime.
2. `bin/` and `obj/`. They are **generated** every time you build, so they're not your source code. They're big and change all the time.
3. C#: `3` (int ÷ int throws away the decimal part). Dart: `3.3333333333333335` (Dart's `/` always gives a double).
4. `2` (17 = 5 × 3 + **2**)
5. `string?`, which is text that **may be null** (for example, when there is no more input).

</details>
