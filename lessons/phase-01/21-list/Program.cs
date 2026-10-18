List<string> drivers = new List<string>();

drivers.Add("Ali");
drivers.Add("Ravi");
drivers.Add("Omar");
Console.WriteLine($"Drivers: {drivers.Count}");

drivers.Remove("Ravi");
Console.WriteLine($"After remove: {drivers.Count} ");
Console.WriteLine($"First driver: {drivers[0]} ");


foreach (string driver in drivers)
{
    Console.WriteLine($"- {driver}");

}