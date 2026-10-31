CashBox box = new CashBox();
box.Deposit(20.5m);
Console.WriteLine($"Balance: {box.Balance} KD");

box.Deposit(-500);
Console.WriteLine($"Balance: {box.Balance} KD");

if (box.Withdraw(5))
{
    Console.WriteLine($"Paid 5 KD. Balance: {box.Balance} KD");
}
else
{
    Console.WriteLine("Withdraw failed");
}
if (box.Withdraw(100))
{
    Console.WriteLine($"Paid 100 KD. Balance: {box.Balance} KD");
}
else
{
    Console.WriteLine("Withdraw failed");

}

Parcel parcel = new Parcel { Number = "KP2001" };
Console.WriteLine($"{parcel.Number} | {parcel.Weight} kg | {parcel.Status}");

if (parcel.SetWeight(2.5))
{
    Console.WriteLine($"Weight set: {parcel.Weight} kg");
}
else
{
    Console.WriteLine($"Weight rejected: {parcel.Weight} kg");
}
if (parcel.SetWeight(50))
{
    Console.WriteLine($"Weight set: {parcel.Weight} kg");
}
else
{
    Console.WriteLine("Weight rejected: 50 kg");
}

if (parcel.MarkDelivered())
{
    Console.WriteLine("Delivered!");
}
else
{
    Console.WriteLine("Already delivered");
}

Console.WriteLine($"{parcel.Number} | {parcel.Weight} kg | {parcel.Status}");

class CashBox
{
    public decimal Balance { get; private set; }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit must be more than 0");
            return;
        }
        Balance = Balance + amount;
    }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            return false;
        }
        Balance = Balance - amount;
        return true;
    }
}

class Parcel
{
    public required string Number { get; init; }
    public double Weight { get; private set; }
    public string Status { get; private set; } = "In transit";

    public bool SetWeight(double kg)
    {
        if (kg <= 0 || kg > 30)
        {
            return false;
        }
        Weight = kg;
        return true;
    }
    public bool MarkDelivered()
    {
        if (Status == "Delivered")
        {
            return false;
        }
        Status = "Delivered";

        return true;
    }
}