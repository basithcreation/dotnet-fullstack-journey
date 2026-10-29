Parcel p = new Parcel("KP1001", 2.5);
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");


p.Weight = 3.0;
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");

Courier c = new Courier { Name = "Ali", Area = "Jahra" };
Console.WriteLine($"{c.Name} delivers in {c.Area}");


Customer cu = new Customer { Name = "Fatima", Phone = "55512345" };
Console.WriteLine($"{cu.Name} | {cu.Phone}");

class Courier
{
    public string Name { get; set; } = "";
    public string Area { get; set; } = "";
}

class Parcel
{
    public string TrackingNo { get; init; }
    public double Weight { get; set; }

    public Parcel(string trackingNo, double weight)
    {
        TrackingNo = trackingNo;
        Weight = weight;
    }
}

class Customer
{
    public required string Name { get; init; }
    public required string Phone { get; init; }
}