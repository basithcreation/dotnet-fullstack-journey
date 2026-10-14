// int x = 10;
// while (x < 5)
// {
//     Console.WriteLine("while ran");
// }
// do
// {
//     Console.WriteLine("do-while ran");
// } while (x < 5);
// Console.WriteLine("end");

string? answer;

do
{
    Console.Write("Type yes: ");
    answer = Console.ReadLine();
} while (answer != "yes");
Console.WriteLine("Thanks!");
