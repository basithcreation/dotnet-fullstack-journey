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

## Versions

- **v1:** everything inside the `while` loop, with a `switch` statement for the result
- **v2:** the logic moved into methods in a `static class Calc`, so the loop only reads input and prints output

## What I practiced

**v1**

- `while (true)` loop that only stops when the user types `q` (with `break`)
- `double.TryParse` so abc is rejected instead of crashing
- `switch` on a string (`"+"`, `"-"`, `"*"`, `"/"`) to pick the result
- Division by zero guard: `double` doesn't crash on `/ 0`, it returns `∞` (Infinity), so I check `secondNumber == 0` first
- Operator guard with `&&` (not `||`) right after reading it, so the user doesn't type the second number after entering an unknown operator
- `continue` (ask again) vs `break` (stop)

**v2**

- `IsValidOperator(op)`: a `bool` method that replaced the long `&&` check
- `TryCalculate(a, op, b, out double result)`: my own **Try pattern**, like `double.TryParse`. It returns `false` (and `result = 0`) for division by zero, `true` otherwise
- A switch expression with a `_` discard arm, which fixed warning CS8509 (switch not exhaustive)
- Deleted the old commented-out code: Git keeps the history

```csharp
if (!Calc.TryCalculate(firstNumber, op, secondNumber, out double result))
{
    Console.WriteLine("Cannot divide by zero");
    continue;
}
Console.WriteLine($"{firstNumber} {op} {secondNumber} = {result}");
```

## What I'd add next

- Ask only for the second number again when it's wrong (now it restarts from the first)
- After each result, ask the user if they want to continue (now it goes straight back to the first number)
