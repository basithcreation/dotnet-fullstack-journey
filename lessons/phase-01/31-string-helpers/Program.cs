string city = " hawalli ";
Console.WriteLine($"[{city}]");
Console.WriteLine($"[{city.Trim()}]");
Console.WriteLine($"[{city.Trim().ToUpper()}]");
Console.WriteLine($"[{city}]");


string note = "Please deliver to Salmiya";
Console.WriteLine(note.Contains("Salmiya"));
Console.WriteLine(note.Contains("salmiya"));
Console.WriteLine(note.ToLower().Contains("salmiya"));

string phone = "965-5555-1234";
Console.WriteLine(phone.Replace("-", ""));
Console.WriteLine(phone.Replace("-", " "));
Console.WriteLine(phone);


string cities = "Hawalli,Salmiya,Jahra";
string[] parts = cities.Split(",");
Console.WriteLine(parts.Length);
Console.WriteLine(parts[0]);

foreach (string c in parts)
{
    Console.WriteLine($"- {c}");
}


string a = "Omar";
string b = "";
string d = "  ";
Console.WriteLine(string.IsNullOrWhiteSpace(a));
Console.WriteLine(string.IsNullOrWhiteSpace(b));
Console.WriteLine(string.IsNullOrWhiteSpace(d));

