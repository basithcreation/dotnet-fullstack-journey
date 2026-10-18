List<string> parcels = new List<string>();

parcels.Add("KP101");
parcels.Add("KP102");
parcels.Add("KP103");
parcels.Add("KP104");

Console.WriteLine($"Parcels waiting: {parcels.Count}");

Console.WriteLine($"Delivered: {parcels[1]}");
parcels.Remove("KP102");
Console.WriteLine($"Next parcel: {parcels[0]}");

foreach (string parcel in parcels)
{
    Console.WriteLine($"- {parcel}");
}

Console.WriteLine($"Still waiting: {parcels.Count}");

