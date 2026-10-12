// //Prediction: Roll 1 : you got {dice} then 2 then 3


// int rolls = 1;

// while (rolls <= 3)
// {
//     int dice = Random.Shared.Next(1, 7);
//     Console.WriteLine($"Roll {rolls}: you got {dice}");
//     rolls++;
// }


string? answer = "";

while (answer != "yes")
{
    Console.Write("Are you ready? (yes/no): ");
    answer = Console.ReadLine();
}

Console.WriteLine("Let's go");