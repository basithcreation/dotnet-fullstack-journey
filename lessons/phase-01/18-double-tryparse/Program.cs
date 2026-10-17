Console.Write("Enter the price: ");
string? input = Console.ReadLine();

if (double.TryParse(input, out double price))
    Console.WriteLine($"With delivery: {price + 1.5}");
else
    Console.WriteLine("That's not a number.");
