string? input;
int number;
bool ok;
do
{
    Console.Write("Which times table? ");
    input = Console.ReadLine();
    ok = int.TryParse(input, out number);
    if (!ok)
    {
        Console.WriteLine("That's not a number.");
    }
}
while (!ok);

int sum = 0;

for (int i = 1; i <= 10; i++)
{
    int answer = number * i;
    Console.WriteLine($"{number} x {i} = {answer}");
    sum += answer;
}
Console.WriteLine($"Sum of all answers: {sum}");

