# 🎯 Number Guessing Game

A console game in C#: the computer picks a secret number from 1 to 100, and you guess it with "too high / too low" clues.

## How to run

```
dotnet run
```

## Example

```
I'm thinking of a number between 1 and 100.
Your guess: 42
Too high!
Your guess: 10
Too low!
Your guess: 25
Too high!
Your guess: 20
Too high!
Your guess: 18
Too high!
Your guess: 15
Too high!
Your guess: 12
Too low!
Your guess: 14
🎉 Correct! You got it in 8 attempts.
```

## What I practiced

- `while` loop that runs until the guess matches the secret number
- `int.TryParse` so letters like "abc" are rejected and don't count as an attempt
- Nested `if` / `else if` for "Too high!" and "Too low!"
- `Random.Shared.Next(1, 101)`: max is exclusive, so 101 gives numbers up to 100
- Testing with a hard-coded secret (42) first, then switching to random

## What I'd add next

- A range check: reject guesses below 1 or above 100
