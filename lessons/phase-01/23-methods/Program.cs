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

// bool IsAdult(int age)
// {
//     if (age >= 18)
//     {
//         return true;
//     }
//     return false;
// }

// Console.WriteLine(IsAdult(25));
// Console.WriteLine(IsAdult(12));

// if (IsAdult(15))
// {
//     Console.WriteLine("Can drive");
// }
// else
// {
//     Console.WriteLine("Too young");
// }


// double AddTxt(double price)
// {
//     return price + 2;
// }

// void PrintBill(string item, double price)
// {
//     double total = AddTxt(price);
//     Console.WriteLine($"{item}: {total} KD");
// }

// PrintBill("Shoes", 10);
// PrintBill("bag", 5);


// void AddButton(ref int points)
// {
//     points = points + 10;
//     Console.WriteLine($"Inside: {points}");
// }

// int myPoints = 5;
// // AddButton(myPoints);
// AddButton(ref myPoints);
// Console.WriteLine($"Outside: {myPoints}");


bool SplitPrice(double total, out double tax)
{
    tax = total * 0.1;
    return total > 51;
}

bool ok = SplitPrice(50, out double myTax);
Console.WriteLine($"{ok} {myTax}");

