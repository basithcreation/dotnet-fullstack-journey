//Example water temperature checker

Console.Write("Water temperature (°C): ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int temperature))
{
    Console.WriteLine("Please enter a whole number");
    return;
}

if (temperature <= 0)
{
    Console.WriteLine("Ice 🧊");
}
else if (temperature >= 100)
{
    Console.WriteLine("Steam ♨️");
}
else
{
    Console.WriteLine("Liquid water");
}

bool isComfortable = temperature >= 30 && temperature <= 40;
if (isComfortable)
{
    Console.WriteLine("Nice for a bath 🛁");
}

