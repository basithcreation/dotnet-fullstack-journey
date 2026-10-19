bool IsHeavy(double weight)
{
    if (weight > 10)
    {
        return true;
    }
    return false;

}

if (IsHeavy(12))
{
    Console.WriteLine($"12 kg: van");
}
else
{
    Console.WriteLine($"12 kg: bike");
}


if (IsHeavy(4.5))
{
    Console.WriteLine($"4.5 kg: van");
}
else
{
    Console.WriteLine($"4.5 kg: bike");
}

if (IsHeavy(10))
{
    Console.WriteLine($"10 kg: van");
}
else
{
    Console.WriteLine($"10 kg: bike");
}

