Console.WriteLine("Simple Calculator (type q to quit)");

while (true)
{
    Console.Write("First Number: ");
    string? input = Console.ReadLine();
    if (input == "q")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    if (!double.TryParse(input, out double firstNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    Console.Write("Operator (+ - * /): ");
    string? op = Console.ReadLine();

    if (!Calc.IsValidOperator(op))
    {
        Console.WriteLine("Unknown operator. Try again.");
        continue;
    }

    Console.Write("Second number: ");
    string? input2 = Console.ReadLine();
    if (!double.TryParse(input2, out double secondNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    if (!Calc.TryCalculate(firstNumber, op, secondNumber, out double result))
    {
        Console.WriteLine("Cannot divide by zero");
        continue;
    }
    Console.WriteLine($"{firstNumber} {op} {secondNumber} = {result}");

}

static class Calc
{
    public static bool IsValidOperator(string? op)
    {
        return op == "+" || op == "-" || op == "*" || op == "/";
    }

    public static bool TryCalculate(double a, string? op, double b, out double result)
    {
        if (op == "/" && b == 0)
        {
            result = 0;
            return false;
        }
        result = op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            _ => a / b,

        };
        return true;
    }
}

