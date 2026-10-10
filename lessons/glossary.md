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

## Tools and workflow

| Easy word | Real term | Team sentence |
|---|---|---|
| my test notes at the top | **test cases** (input → **expected** vs **actual** output) | "What's the expected output for this test case?" |
| detective line by line | **tracing** / **dry run** | "Let's trace the code with input 10." |
| program stops with red error | **compile error** (build error), e.g. `CS0103` | "It doesn't compile, `name` is out of scope." |
| Shift+Alt+F | **format document** / **code formatting** | "Run the formatter before you commit." |
| F2 rename | **rename refactoring** | "Use rename, don't edit by hand." |
| teacher checks my code | **code review** | "I left two comments on your PR." |
