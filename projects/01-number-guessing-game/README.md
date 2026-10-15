# 🎯 Number Guessing Game

A console game in C#: the computer picks a secret number from 1 to 100, and you guess it with "too high / too low" clues.

## How to run

```
dotnet run
```

## Example

```
I'm thinking of a number between 1 and 100.
Your guess: abc
That's not a number. Try again.
Your guess: 500
Please guess between 1 and 100.
Your guess: 50
Too low!
Your guess: 40
Too low!
Your guess: 80
Too high!
Your guess: q
The number was 63.
```

## What I practiced

- `while` loop that runs until the guess matches the secret number
- `int.TryParse` so letters like "abc" are rejected and don't count as an attempt
- Nested `if` / `else if` for "Too high!" and "Too low!"
- `Random.Shared.Next(1, 101)`: max is exclusive, so 101 gives numbers up to 100
- Testing with a hard-coded secret (42) first, then switching to random
- `||` for the range check (1 to 100)
- Guard clauses with `continue`: skip input that is not a number or not between 1 and 100
- `q` to quit with `break`, plus an `if` after the loop that checks the player really won, so quitting doesn't print "Correct!"

## What I'd add next

- Play again? (y/n)
- Accept `Q` too
- A max of 10 attempts
