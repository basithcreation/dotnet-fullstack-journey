# Learning Progress Log

Newest day at the top. Claude reads this at the start of each new chat to continue from the right place.

---

## ▶️ Next session starts here

- **Thu 15 Oct, warm-up (5 min, chat only): 2 small traces** mixing the new keywords. ① a `while` with `continue` where the update is **before** the `continue` (e.g. skip multiples of 3) ② a `do-while` with `break` inside. Trace table for each. Don't reuse the chapter 1.9 / 1.10 quizzes, they have the answers
- **Thu 15 Oct lesson: Number Guessing Game v1.1** (in `projects/01-number-guessing-game`, it's a project upgrade, so update the README "Features" too):
  1. **Range check:** a guess < 1 or > 100 → `Please guess between 1 and 100.`, **not counted** as an attempt. Needs `||` (logical OR, met on Day 3: do a 2-minute refresher with a different example first)
  2. **Flatten the nested if with `continue`:** `if (!int.TryParse(...)) { ...; continue; }` (a guard clause inside a loop, like the Day 7 guard clause but with `continue` instead of `return`)
  3. **`q` to quit with `break`:** print `The number was {secret}.` Trap to let them discover: after a `break`, the "Correct!" message after the loop still runs. They need a flag (`bool won`) or a check (`guess == secret`). Teach the idea, let them find the fix
  - Show the expected output for every path (bad text, out of range, too high/low, win on 1st try, quit). Test every path before "done"
  - **Commit right after** (new rule): `Add range check and quit option to guessing game`
- **Fri 16 Oct: LinkedIn "Week 1" post** in `career/linkedin/`: Phase 0 + data types, TryParse, if/else, switch, Git undo, all the loops (while, for, do-while, break/continue), and **Project 01** v1.1 (link: https://github.com/basithcreation/dotnet-fullstack-journey/tree/main/projects/01-number-guessing-game, screenshot of a real game). Revise + quiz too
- Still to tick in ROADMAP: "Operators, string interpolation" (quick check: `%`, `||`/`&&`, `$"..."`, used a lot). The loops line only needs `foreach` (comes with arrays/lists)
- **How to teach this student:**
  - **Keep Git short** (they asked on Day 8 if Git is worth the time; they want to finish .NET fast). Commit **right after each exercise** (1 minute). No long fix-up sessions. A typo in a message: point it out, amend only if not pushed and it takes 10 seconds. No new Git until Phase 2 (branches)
  - **They forget a folder in `git add`** (Day 4 and Day 8, the same mistake). Always check the "N files changed" number against the expected one
  - **Check the clock before saying "morning" / "tonight"**. They study in free hours during a full-day duty that ends ~9:30 PM, with a prayer break
  - They predict from the **English meaning** of a keyword (`continue` = "carry on normally"). For new keywords, give the C# meaning in one line before asking for a prediction
  - The prediction habit is working: they predict in chat **before** running now ✅. Keep asking
  - Tracing: half-filled trace tables work. Their remaining mistake is the **final answer**: it doesn't come from the last row (Day 8: table said 6, answered 10). Ask "which row is the last true one?"
  - When they write code, things often end up **outside** the loop or block they belong to (the standalone block after `while (...);`). Ask "which lines must repeat?"
  - "done" without output: ask for the output **every** time. Read the file yourself before accepting
  - ONE step per message, fill-in templates with blanks (worked well for the flag fix)
  - Day 8: started 11:00 AM, stopped around 9:30 PM

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
