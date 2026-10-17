double[] weights = { 2.5, 12, 0.8, 15.5, 7 };

double total = 0;
int heavyCount = 0;

foreach (double parcelWeight in weights)
{
    total = total + parcelWeight;

    if (parcelWeight > 10)
    {
        heavyCount++;
    }
}
Console.WriteLine($"Total weight: {total} kg");
Console.WriteLine($"Heavy parcels (over 10 kg): {heavyCount}");