bool IsHeavy(double weight)
{
    if (weight > 10)
    {
        return true;
    }
    return false;

}

// another way 
// bool IsHeavy(double weight)
// {
//     return weight > 10;
// }


void PrintVehicle(double weight)
{
    if (IsHeavy(weight))
    {
        Console.WriteLine($"{weight} kg: van");
    }
    else
    {
        Console.WriteLine($"{weight} kg: bike");
    }
}

PrintVehicle(12);
PrintVehicle(4.5);
PrintVehicle(10);