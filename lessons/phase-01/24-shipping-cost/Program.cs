
double salmiyaCost = CalculateShipping(4);
PrintReceipt("Salmiya", salmiyaCost);

double jahraCost = CalculateShipping(10);
PrintReceipt("Jahra", jahraCost);

double CalculateShipping(double weightKg)
{
    double fee = 0.5;
    return weightKg * fee;
}

void PrintReceipt(string city, double cost)
{
    Console.WriteLine($"City: {city}");
    Console.WriteLine($"Shipping: {cost} KD");
}

