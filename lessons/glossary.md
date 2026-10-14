# Glossary: real words a dev team uses

Format: easy word I learned with → **real term** → what a teammate would say.

## Phase 1: Variables and types

| Easy word | Real term | Team sentence |
|---|---|---|
| box | **variable** | "Store the result in a variable called `wholeHours`." |
| what the box can hold | **data type** / **type** | "Use `decimal` as the type for money." |
| make the box | **declare** (declaration) | "Declare `fee` before the `if`." |
| put the first value in | **initialize** (initialization) | "Initialize `discount` to `0m`." |
| change the box | **assign** / **reassign** (assignment) | "Reassign `fee` after the discount." |
| rule that never changes | **constant** (`const`) | "Make the rate a constant, don't hard-code it." |
| unnamed number in code | **magic number** | "`1.500` is a magic number. Extract it into a constant." |
| scissors (`(int)2.75` → 2) | **cast** / **explicit conversion**, which **truncates** | "The cast truncates the decimal part, it doesn't round." |
| TryParse refuses | **parsing fails** / returns `false` | "If parsing fails, show an error and return." |
| may be empty (`string?`) | **nullable** type | "`ReadLine` returns a nullable string." |
| `$"Hi {name}"` | **string interpolation** | "Use interpolation instead of `+`." |
| `:F3` | **format specifier** | "Format money with `F3`." |

## Phase 1: `if` / `else`

| Easy word | Real term | Team sentence |
|---|---|---|
| the `{ }` room / walls | **code block** | "Put that line inside the `if` block." |
| born inside `{ }` dies at `}` | **scope** (block scope) | "`discount` is out of scope here, so declare it before the block." |
| born outside | **declared in the outer scope** | "Move the declaration above the `if`." |
| check (`==`) | **comparison** / **equality operator** | "Use the equality operator, not assignment." |
| save (`=`) | **assignment operator** | "That's an assignment, not a comparison." |
| `> < >= <=` | **relational operators** | |
| `&&` `\|\|` `!` | **logical operators** (AND, OR, NOT) | "Combine the two checks with a logical OR." |
| true/false question | **condition** / **boolean expression** | "The condition is always false." |
| first match wins | **if-else chain** is evaluated **top to bottom** | "Order matters in the chain. Put the most specific check first." |
| door guard + `return` | **guard clause** / **early return** | "Add a guard clause for negative hours." |
| edge number | **boundary value** | "Test the boundary values: 0, 24 and 25." |
| edge mistake (`>` instead of `>=`) | **off-by-one error** | "Looks like an off-by-one at 24 hours." |
| cap | **upper limit** / **maximum**; capping a value = **clamping** | "Clamp the fee to `MaxDailyFee`." (Shortcut: `Math.Min(fee, MaxDailyFee)`) |
| factory line | **calculate once, then apply adjustments in order** | "Compute the base fee, then apply the discount, then the cap." |
| same code written twice | **code duplication**; fix = **DRY** (Don't Repeat Yourself) | "This is duplicated, so pull the print out of the `if`/`else`." |
| discount number (0.5) | **multiplier** / **factor** | "The resident discount factor is 0.5." |
| discount before cap | **business rule** / **business logic** | "Confirm the business rule with the product owner." |
| `isComfortable` naming | **boolean naming convention** (`is`/`has`/`can` prefix) | "Only booleans get the `is` prefix." |

## Phase 1: `switch`

| Easy word | Real term | Team sentence |
|---|---|---|
| vending machine (does jobs) | **switch statement** | "A switch statement is fine here, each case just prints." |
| price list (gives back a value) | **switch expression** | "Turn that switch statement into a switch expression, it'll be shorter." |
| each `case "red":` line | **case label**; `default:` = **default case** | "Add a default case for unknown input." |
| sliding into the next case | **fall-through** (C# blocks it: CS0163) | "C# doesn't allow fall-through, add a `break`." |
| each `pattern => value` line | **arm** of the switch expression | "The compiler flagged that arm as unreachable." |
| `>= 90` in a switch | **relational pattern** | |
| `6 or 7` | **`or` pattern** | |
| `_` "anything else" | **discard pattern** | "Add a discard arm at the end." |
| covers every possible value | **exhaustive** | "The switch expression isn't exhaustive, it can throw at runtime." |
| line that can never run | **unreachable code** | "That arm is unreachable, the one above already catches it." |
| long if-else → switch | **refactor** | "This if-else chain is long, let's refactor it to a switch expression." |

## Phase 1: `while` loops and `Random`

| Easy word | Real term | Team sentence |
|---|---|---|
| merry-go-round / "while the plate is not empty" | **loop** (`while` loop) | "Wrap that in a loop instead of copying it 3 times." |
| one round | **iteration** | "On the third iteration, `bites` is 1." |
| the check at the top | **loop condition** | "The loop condition is never false, so it hangs." |
| the code inside `{ }` | **loop body** | "Move `rolls++` to the top of the loop body." |
| never stops | **infinite loop**; the app **hangs** | "The app hung because of an infinite loop." |
| the lonely `;` after `while (...)` | **empty statement** / **stray semicolon** (CS0642) | "There's a stray semicolon after the `while`." |
| body never runs | **zero iterations** | "If the condition is false on entry, it runs zero iterations." |
| loop until "yes" | **sentinel loop** / loop until a condition is met | "Use a sentinel loop until the user types yes." |
| the variable the loop checks | **loop control variable** | "`dice` is the loop control variable." |
| add 1 / take away 1 | **increment** `++` / **decrement** `--` | "Increment the counter before you print it." |
| counter one too big | **off-by-one error** | "It's an off-by-one error: I incremented after printing." |
| lucky-draw box | **random number generator** (`Random.Shared`) | "Use `Random.Shared`, don't create a new `Random` each time." |
| `Next(1, 7)`: 1 in, 7 out | **inclusive lower bound** / **exclusive upper bound** | "`Next(1, 101)` returns 1 to 100, the upper bound is exclusive." |
| different every run | **non-deterministic** | "Random output is non-deterministic, so test the range, not the exact value." |
| capitals count | **case-sensitive** | "String comparison is case-sensitive by default." |
| `Writeline` vs `WriteLine` | **casing typo** (CS0117) | "The build broke because of a casing typo." |
| force the dice to 6 for a test | **hard-code** a value, test the **edge case**, then **revert** | "I hard-coded 6 to test the first-try branch, then reverted it." |

## Phase 1: Project 01, validation loops

| Easy word | Real term | Team sentence |
|---|---|---|
| door that keeps asking | **input validation loop** | "Wrap the `TryParse` in a validation loop." |
| an `if` inside an `if` | **nested `if`** | "The high/low check is a nested `if` inside the parse check." |
| bad input not counted | **invalid input is rejected** | "Invalid input is rejected and doesn't count as an attempt." |
| the random line wiped my guess | **overwrite** a variable | "The random call was overwriting the user's guess." |
| picked once at the top | **initialized once** (before the loop) | "The secret is initialized once, so it stays constant for the whole game." |
| guess the middle | **binary search** | "Binary search finds any number from 1 to 100 in 7 tries or fewer." |
| good names | **meaningful variable names** | "Rename `randomNumber`, nothing about it is random." |
| neat blank lines | **formatting** / **code style** | "`else` goes right after the `}`, no blank line." |
| project front page | **README** (written in **Markdown**) | "Add a README with how to run it and an example." |

## Phase 1: `for` loop

| Easy word | Real term | Team sentence |
|---|---|---|
| run this many times | **`for` loop** / counting loop | "We know the count up front, so use a `for` loop instead of a `while`." |
| ① start (runs once) | **initializer** | "The initializer runs only once, before the first check." |
| ② check | **loop condition** | "The condition is checked before every iteration." |
| ③ step (`i++`) | **iterator** (not "iteration"!) | "The iterator is `i += 3`, so it skips values." |
| `i` | **loop counter** / **loop variable** | "Don't use the loop counter after the loop, it's out of scope." |
| the extra `false` check | **final evaluation** of the condition (N iterations = N + 1 checks) | "The condition is evaluated once more than the body runs." |
| piggy bank | **accumulator** | "Initialize the accumulator before the loop, otherwise it resets on every iteration." |
| `+=` | **compound assignment operator** | "Use `sum += answer` instead of `sum = sum + answer`." |
| `+= 1` vs `+= i` | **counting** vs **summing** | "That's counting the iterations, not summing them. Use `+= i`." |
| `!` flips true/false | **logical NOT operator** / **negation** | "`!` negates the TryParse result." |
| leave at the top if input is bad | **guard clause** + **early return**; the rest is the **happy path** | "Add a guard clause, so the happy path isn't nested in an `else`." |
| output must equal the spec | **matches the expected output** (character for character) | "The test fails, the text doesn't match the expected output exactly." |

## Phase 1: `do-while`, `break`, `continue`

| Easy word | Real term | Team sentence |
|---|---|---|
| waiter serves first, asks after | **`do-while` loop** | "Use a do-while here, because we have to ask the user at least once." |
| check first (can run 0 times) | **pre-test loop** (`while`, `for`) | "A while is pre-test, so it can run zero times." |
| check after (runs 1+ times) | **post-test loop** (`do-while`) | "A do-while is post-test, so the body runs at least once." |
| create the box | **declare** a variable | "Declare `cmd` before the `do` so the condition can see it." |
| give the box its first value | **initialize** a variable | "You don't need to initialize it, `out` assigns it." |
| fake starting value (`int pin = 0;`) | **dummy value** / **placeholder value** | "With a do-while you don't need a dummy value." |
| yes/no box | **flag** (a `bool` variable) | "Store the TryParse result in a flag, then use it in the loop condition." |
| `{ }` not attached to anything | **standalone block** | "That's a standalone block, it's not part of the loop." |
| a `using` line nobody needs | **unused using directive** | "Remove the unused using, the analyzer flags it." |
| `(19,10)` in an error | **line 19, column 10** | "The error is at line 19, column 10, in the while condition." |
| leave the cinema | **`break`** / **exit the loop early** | "We break out of the loop as soon as we find a match." |
| skip one song | **`continue`** / **skip to the next iteration** | "If the input is invalid, we `continue` to skip it." |
| `break`, `continue`, `return` | **jump statements** | "Too many jump statements make a loop hard to follow." |
| stop searching when found | **early exit** | "Add an early exit once the item is found." |

## Errors and testing

| Easy word | Real term | Team sentence |
|---|---|---|
| yellow message, still runs | **warning** | "Don't ignore warnings, this one means it can crash." |
| crash while running | **exception** / **unhandled exception** | "It throws a `SwitchExpressionException` for 65." |
| the `at ...` lines after a crash | **stack trace** | "Can you send me the stack trace?" |
| test every path | **testing every branch** | "Did you test every branch of the switch?" |
| finished = every step done | **Definition of Done** | "It's not done until the tests are in." |

## Git

| Easy word | Real term | Team sentence |
|---|---|---|
| desk | **working directory** / **working tree** | "Your working tree is clean." |
| box | **staging area** (index) | "Stage only the files for this change." |
| photo + caption | **commit** + **commit message** | "Write a commit message that says what changed." |
| latest photo | **HEAD** | "`git show HEAD` shows the last commit." |
| one topic per photo | **atomic commit** | "Split that into smaller, atomic commits." |
| retake the last photo | **amend** | "Don't amend pushed commits." |
| take out of the box | **unstage** (`git restore --staged`) | "I staged the bin folder by mistake, let me unstage it." |
| throw away my edits | **discard changes** (`git restore`) | "Discard your local changes and pull again." |
| new photo that undoes an old one | **revert** | "That commit broke the build, let's revert it." |
| the `:` scroll screen | **pager** (press `q`) | |
| invisible new-line characters | **line endings** (CRLF on Windows, LF on Linux/Mac) | "That's just a line-ending warning, it's harmless." |
| Git couldn't find my path | **pathspec** error (`did not match any files`) | "The add failed, my pathspec had a typo." |
| leftover `obj` folder | **build output** / **stray build folder** | "That's just build output, it's gitignored, delete it." |
| `git add .` | **stage all changes** | "I staged everything because the working tree only had this change." |
| saved on my PC, not on GitHub | **local commits**, **ahead of the remote** | "I'm 2 commits ahead of origin, let me push." |
| old photo next to new file | **diff** of **unstaged changes** (`git diff`) | "Run `git diff` to review your unstaged changes before committing." |
| `-` / `+` / space lines in a diff | **deletion** / **addition** / **context line** | "The diff is one deleted blank line, the rest is context." |
| where GitHub is (`origin/main`) | **remote-tracking branch** | "`origin/main` is still on yesterday's commit, I haven't pushed." |
| keep the message, add files | `git commit --amend --no-edit` | "I forgot a file, I'll amend with `--no-edit`." |
| "1 file changed" line | **commit summary** (check the file count!) | "The commit only shows 1 file changed, I forgot to stage the rest." |
| carry commits to GitHub | **push** to the **remote** | "I pushed, so I won't amend those commits anymore." |
| shopping basket (order doesn't matter) | **staging area**: a commit takes everything staged at that moment | "I staged only the lesson files, so the commit stays atomic." |
| amend throws the old photo away | **amend rewrites history** (new commit ID) | "Amend rewrites history, so never amend a pushed commit." |
| amend with an empty basket | **message-only amend** | "Nothing's staged, so the amend only fixes the message." |

## Tools and workflow

| Easy word | Real term | Team sentence |
|---|---|---|
| my test notes at the top | **test cases** (input → **expected** vs **actual** output) | "What's the expected output for this test case?" |
| detective line by line | **tracing** / **dry run** | "Let's trace the code with input 10." |
| program stops with red error | **compile error** (build error), e.g. `CS0103` | "It doesn't compile, `name` is out of scope." |
| Shift+Alt+F | **format document** / **code formatting** | "Run the formatter before you commit." |
| F2 rename | **rename refactoring** | "Use rename, don't edit by hand." |
| teacher checks my code | **code review** | "I left two comments on your PR." |
