Console.WriteLine("I'm thinking of a number between 1 and 100.");

int secretNumber = Random.Shared.Next(1, 101);
int guessNumber = 0;
int numberOfAttempts = 0;

while (guessNumber != secretNumber)
{
    Console.Write("Your guess: ");
    string? input = Console.ReadLine();

    if (input == "q")
    {
        Console.WriteLine($"The number was {secretNumber}.");
        break;
    }

    if (!int.TryParse(input, out guessNumber))
    {
        Console.WriteLine("That's not a number. Try again.");
        continue;
    }

    if (guessNumber < 1 || guessNumber > 100)
    {
        Console.WriteLine("Please guess between 1 and 100.");
        continue;
    }

    numberOfAttempts++;
    if (guessNumber > secretNumber)
    {
        Console.WriteLine("Too high!");
    }
    else if (guessNumber < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
}

if (guessNumber == secretNumber)
{
    if (numberOfAttempts == 1)
    {
        Console.WriteLine("🎯 First try! Amazing!");
    }
    else
    {
        Console.WriteLine($"🎉 Correct! You got it in {numberOfAttempts} attempts.");
    }
}
