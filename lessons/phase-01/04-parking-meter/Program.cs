// Test results:
// Input "3"   → Valid: True,  Fee: 0.750 KWD → why: this is whole number can fit
// Input "abc" → Valid: False, Fee: 0.000 KWD → why: this is string not fit in to int
// Input "2.5" → Valid: False, Fee: 0.000 KWD → why: int whole only whole number


const decimal PerHourRate = 0.250m;
Console.Write("How many hours did you park:");
string? input = Console.ReadLine();
bool isNumber = int.TryParse(input, out int hoursParked);
Console.WriteLine($"Valid input: {isNumber}");
Console.WriteLine($"Hours: {hoursParked}");

var fee = hoursParked * PerHourRate;
Console.WriteLine($"Fee:{fee:F3} KWD");

double averageStayHours = 2.75;
int wholeHours = (int)averageStayHours;
Console.WriteLine($"Average stay (whole hours): {wholeHours}");
