Parcel p = new Parcel("KP1001", 2.5);
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");


p.Weight = 3.0;
Console.WriteLine($"{p.TrackingNo} weighs {p.Weight} kg");


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