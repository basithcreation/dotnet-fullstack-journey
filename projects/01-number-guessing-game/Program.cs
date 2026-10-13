Console.WriteLine("I'm thinking of a number between 1 and 100.");

int secretNumber = Random.Shared.Next(1, 101);
int guessNumber = 0;
int numberOfAttempts = 0;

while (guessNumber != secretNumber)
{
    Console.Write("Your guess: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out guessNumber))
    {
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
    else
    {
        Console.WriteLine("That's not a number. Try again.");
    }
}

if (numberOfAttempts == 1)
{
    Console.WriteLine("🎯 First try! Amazing!");
}
else
{
    Console.WriteLine($"🎉 Correct! You got it in {numberOfAttempts} attempts.");
}