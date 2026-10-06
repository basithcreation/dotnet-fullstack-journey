
Console.WriteLine("What is your name?");
string? name = Console.ReadLine();
Console.WriteLine("What year were you born?");
string? birthYearText = Console.ReadLine();
int birthYear = int.Parse(birthYearText);
int age = DateTime.Now.Year - birthYear;
Console.WriteLine($"Hello {name}! You are {age} years old.");

