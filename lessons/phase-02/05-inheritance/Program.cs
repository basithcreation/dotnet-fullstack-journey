Driver d = new Driver();
d.Name = "Ali";
d.ShowBonus();
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
