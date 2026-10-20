// Labels.PrintLabel("Hawalli");
// Labels.PrintLabel("Salmiya", 3);


// static class Labels
// {

//     public static void PrintLabel(string city)
//     {
//         Console.WriteLine($"Delivery to {city}");
//     }

//     public static void PrintLabel(string city, int boxes)
//     {
//         Console.WriteLine($"Delivery {boxes} boxes to {city}");
//     }

// }

Prices.Show(5);
Prices.Show(2.75);

static class Prices
{
    public static void Show(int amount)
    {
        Console.WriteLine($"Whole price: {amount} KD");
    }

    public static void Show(double amount)
    {
        Console.WriteLine($"Extra price: {amount} KD");
    }
}