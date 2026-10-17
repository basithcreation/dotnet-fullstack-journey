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

    if (op != "+" && op != "-" && op != "*" && op != "/")
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

    switch (op)
    {
        case "+":
            Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
            break;
        case "-":
            Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
            break;
        case "*":
            Console.WriteLine($"{firstNumber} x {secondNumber} = {firstNumber * secondNumber}");
            break;
        case "/":
            if (secondNumber == 0)
                Console.WriteLine("Cannot divide by zero");
            else
                Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
            break;
        default:
            Console.WriteLine("Something went wrong");
            break;
    }
}


