const int CurrentYear = 2026;

Console.Write("Enter your birth Year:");
string? input = Console.ReadLine();

bool isNumber = int.TryParse(input, out int birthYear);
Console.WriteLine($"valid number? {isNumber}");
Console.WriteLine($"Birth year: {birthYear}");
Console.WriteLine($"age this year: {CurrentYear - birthYear}");

//casting
var exactHeight = 172.8;
var roundedDown = (int)exactHeight;
Console.WriteLine($"{exactHeight} -> {roundedDown}");