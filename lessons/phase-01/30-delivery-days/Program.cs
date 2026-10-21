
Courier.PrintDelivery("Jahra");
Courier.PrintDelivery("Salmiya", 1);
Courier.PrintDelivery(days: 5, city: "Hawalli");

static class Courier
{
    public static void PrintDelivery(string city, int days = 2)
    {
        Console.WriteLine($"Delivery to {city} in {days} days");
    }
}

