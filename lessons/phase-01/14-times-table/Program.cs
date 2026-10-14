Console.Write("Which times table? ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int number))
{
    Console.WriteLine("That's not a number.");
    return;
}
int sum = 0;
for (int i = 1; i <= 10; i++)
{
    int answer = number * i;
    Console.WriteLine($"{number} x {i} = {answer}");
    sum += answer;
}
Console.WriteLine($"Sum of all answers: {sum}");

