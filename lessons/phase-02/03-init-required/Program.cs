Parcel p = new Parcel("KP1001", 2.5);
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");


p.Weight = 3.0;
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");

Courier c = new Courier { Name = "Ali", Area = "Jahra" };
Console.WriteLine($"{c.Name} delivers in {c.Area}");


Customer cu = new Customer { Name = "Fatima", Phone = "55512345" };
Console.WriteLine($"{cu.Name} | {cu.Phone}");

Vehicle v1 = new Vehicle { PlateNo = "12-34567", Model = "Toyota Hiace", Mileage = 85000 };
Vehicle v2 = new Vehicle { PlateNo = "45-11223", Model = "Nissan Urvan", Mileage = 120000 };

v1.Mileage = v1.Mileage + 250;
Console.WriteLine($"{v1.PlateNo} | {v1.Model} | {v1.Mileage} km");
Console.WriteLine($"{v2.PlateNo} | {v2.Model} | {v2.Mileage} km");

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

class Vehicle
{
    public required string PlateNo { get; init; }
    public required string Model { get; init; }
    public required int Mileage { get; set; }
}