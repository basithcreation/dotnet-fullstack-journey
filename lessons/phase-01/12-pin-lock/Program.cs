int correctPin = 4321;
int pin = 0;
int tries = 0;

while (pin != correctPin)
{
    Console.Write("Enter PIN: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out pin))
    {
        tries++;
        if (pin != correctPin)
        {
            Console.WriteLine("Wrong PIN.");
        }

    }
    else
    {
        Console.WriteLine("Digits only please");
    }
}

Console.WriteLine($"Unlocked after {tries} tries");