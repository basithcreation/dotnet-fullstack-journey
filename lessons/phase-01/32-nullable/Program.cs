int? weight = null;
Console.WriteLine($"[{weight}]");
Console.WriteLine($"[{weight.HasValue}]");

weight = 12;
Console.WriteLine($"[{weight}]");
Console.WriteLine($"[{weight.HasValue}]");

int? boxes = null;
int total = boxes ?? 1;
Console.WriteLine($"Boxes: {total}");

boxes = 4;
total = boxes ?? 1;
Console.WriteLine($"Boxes: {total}");

string? driver = null;
Console.WriteLine($"Driver: {driver ?? "Not Assigned"}");


// example NullReferenceException and ??= sets the default only if it's still null
string? sender = null;
Console.WriteLine($"[{sender?.ToUpper()}]");
Console.WriteLine($"[{sender?.ToUpper() ?? "UNKNOWN"}]");

sender = "omar";
Console.WriteLine($"[{sender?.ToUpper()}]");

string? area = null;
area ??= "Hawalli";
area ??= "Jahra";
Console.WriteLine(area);

// ---- Exercise: parcel details ----
int? floor = null;
string? phone = null;
// string? coupon = "kpost10";
string? coupon = null;
// string? branch = null;
string? branch = "Jahra";

Console.WriteLine($"Floor: {floor ?? 0}");
Console.WriteLine($"Phone: {phone ?? "No phone"}");

Console.WriteLine($"Coupon: {coupon?.ToUpper() ?? "NONE"}");
branch ??= "Main";
Console.WriteLine($"Branch: {branch}");

