Driver d = new Driver();
d.Name = "Ali";
d.StaffId = 101;
d.VanNumber = "K-55";

d.SayHello();
d.Drive();

class Employee
{
    public string Name { get; set; } = "";
    public int StaffId { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hi, I am {Name} (ID {StaffId})");
    }
}

class Driver : Employee
{
    public string VanNumber { get; set; } = "";

    public void Drive()
    {
        Console.WriteLine($"{Name} is driving van {VanNumber}");
    }
}
