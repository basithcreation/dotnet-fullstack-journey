// PrintLabel("Salmiya");
// PrintLabel("Jahra");
// PrintLabel("Fahaheel");

// void PrintLabel(string city)
// {
//     Console.WriteLine("----------");
//     Console.WriteLine($"To: {city}");
// }

// double total = AddDeliveryFee(4.0);
// Console.WriteLine($"Total: {total} KD");
// Console.WriteLine($"Big order: {AddDeliveryFee(10.0)} KD");

// double AddDeliveryFee(double price)
// {
//     double fee = 1.5;
//     return price + fee;
// }


// void PrintStop(String driver, int stopNumber)
// {
//     Console.WriteLine($"{driver} -> stop {stopNumber}");
// }

// PrintStop("Ali", 3);
// PrintStop("Omar", 7);

bool IsAdult(int age)
{
    if (age >= 18)
    {
        return true;
    }
    return false;
}

Console.WriteLine(IsAdult(25));
Console.WriteLine(IsAdult(12));

if (IsAdult(15))
{
    Console.WriteLine("Can drive");
}
else
{
    Console.WriteLine("Too young");
}