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