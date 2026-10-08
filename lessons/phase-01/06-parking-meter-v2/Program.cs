// Parking Meter version 2
// Test results:
// "abc"      → Please enter whole hours.  → why: it will false so the code tell please enter whole number
// "-2"       → Hours can't be negative.   → why: Hours can't be negative. because our condition true here 
// "0"        → Free (under 1 hour)        → why: because we have condition ==0 
// "30"       → Max parking is 24 hours.   → why: our condition > 24 not allow 
// "3"  + "n" → Fee: 0.750 KWD             → why: 3*0.250 because non resident
// "3"  + "Y" → Fee: 0.375 KWD             → why: 0.750*0.5 because of y
// "10" + "n" → Fee: 1.500 KWD             → why: max fee we set 1.500 
// "24" + "n" → Fee: 1.500 KWD             → why: max fee we set 1.500
// "10" + "y" → Fee: 1.250 KWD             → why: 10 × 0.250 = 2.500, × 0.5 = 1.250, under the cap so no change

Console.Write("Hours parked: ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int totalHours))
{
    Console.WriteLine("Please enter whole hours.");
    return;
}

if (totalHours < 0)
{
    Console.WriteLine("Hours can't be negative.");
    return;
}
if (totalHours > 24)
{
    Console.WriteLine("Max parking is 24 hours.");
    return;
}

if (totalHours == 0)
{
    Console.WriteLine("Free (under 1 hour)");
    return;
}

const decimal PerHourRate = 0.250m;
const decimal ResidentDiscount = 0.5m;
const decimal MaxDailyFee = 1.500m;

Console.Write("Kuwait resident? (y/n): ");
string? residentAnswer = Console.ReadLine();


decimal fee = totalHours * PerHourRate;


if (residentAnswer == "y" || residentAnswer == "Y")
{
    fee = fee * ResidentDiscount;
}

//cap is applied AFTER the resident discount
if (fee > MaxDailyFee)
{
    fee = MaxDailyFee;
}

Console.WriteLine($"Fee: {fee:F3} KWD");



