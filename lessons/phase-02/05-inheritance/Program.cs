Driver d = new Driver();
d.Name = "Ali";
d.ShowBonus();

Van v = new("KW-1234", 50);
Console.WriteLine($"{v.Plate} | {v.MaxParcels} parcels");
class Vehicle
{
    public string Plate { get; }
    public Vehicle(string plate)
    {
        Plate = plate;
        Console.WriteLine($"Vehicle {plate} registered");
    }
}
class Van : Vehicle
{
    public int MaxParcels { get; }
    public Van(string plate, int maxParcels) : base(plate)
    {
        MaxParcels = maxParcels;
        Console.WriteLine($"Van can carry {maxParcels} parcels");
    }
}
class Employee
{
    public string Name { get; set; } = "";
    protected decimal Salary { get; set; } = 400m;
}

class Driver : Employee
{
    public void ShowBonus()
    {
        decimal bonus = Salary / 10;
        Console.WriteLine($"{Name} gets a bonus of {bonus} KD");
    }
}

