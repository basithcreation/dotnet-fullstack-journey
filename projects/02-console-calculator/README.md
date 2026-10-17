# 🧮 Console Calculator

A console calculator in C# that does + - \* / with two numbers and handles bad input.

## How to run

    dotnet run

## Example

```
Simple Calculator (type q to quit)
First Number: 7
Operator (+ - * /): -
Second number: 10
7 - 10 = -3
First Number: abc
That's not a number. Try again.
First Number: 9
Operator (+ - * /): /
Second number: xyz
That's not a number. Try again.
First Number: 8
Operator (+ - * /): /
Second number: 0
Cannot divide by zero
First Number: q
Goodbye!
```

## What I practiced

- `while (true)` loop that only stops when the user types `q` (with `break`)
- `double.TryParse` so abc is rejected instead of crashing
- `switch` on a string (`"+"`, `"-"`, `"*"`, `"/"`) to pick the result
- Division by zero guard: `double` doesn't crash on `/ 0`, it returns `∞` (Infinity), so I check `secondNumber == 0` first
- Operator guard with `&&` (not `||`) right after reading it, so the user doesn't type the second number after entering unknow operator
- `continue` (ask again) vs `break` (stop)

## What I'd add next

- Ask only for the second number again when it's wrong (now it restarts from the first)
- after complete on caluclator automatily ask again firstnumber but i need the user want to continue or not
