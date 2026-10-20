Labels.PrintLabel("Hawalli");
Labels.PrintLabel("Salmiya", 3);


static class Labels
{

    public static void PrintLabel(string city)
    {
        Console.WriteLine($"Delivery to {city}");
    }

    public static void PrintLabel(string city, int boxes)
    {
        Console.WriteLine($"Delivery {boxes} boxes to {city}");
    }

}