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

## Tools and workflow

| Easy word | Real term | Team sentence |
|---|---|---|
| my test notes at the top | **test cases** (input → **expected** vs **actual** output) | "What's the expected output for this test case?" |
| detective line by line | **tracing** / **dry run** | "Let's trace the code with input 10." |
| program stops with red error | **compile error** (build error), e.g. `CS0103` | "It doesn't compile, `name` is out of scope." |
| Shift+Alt+F | **format document** / **code formatting** | "Run the formatter before you commit." |
| F2 rename | **rename refactoring** | "Use rename, don't edit by hand." |
| teacher checks my code | **code review** | "I left two comments on your PR." |
