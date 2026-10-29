Driver d1 = new Driver("Ali", "Hawalli");
Driver d2 = new Driver("Sara", "Salmiya");

Console.WriteLine($"{d1.Name} drives in {d1.Area}");
Console.WriteLine($"{d2.Name} drives in {d2.Area}");

class Driver
{
    public string Name { get; set; }
    public string Area { get; set; }

    public Driver(string name, string area)
    {
        Name = name;
        Area = area;
        Console.WriteLine($"New driver created: {name}");
    }
}
