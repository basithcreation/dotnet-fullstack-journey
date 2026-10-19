bool TryGetFee(double weight, out double fee)
{

    if (weight <= 0)
    {
        fee = 0;
        return false;
    }
    fee = weight * 0.5;
    return true;
}

if (TryGetFee(4, out double fee1))
{
    Console.WriteLine($"Fee: {fee1} KD");
}
else
{
    Console.WriteLine($"Invalid weight");
}

if (TryGetFee(-2, out double fee2))
{
    Console.WriteLine($"Fee: {fee2} KD");
}
else
{
    Console.WriteLine($"Invalid weight");
}