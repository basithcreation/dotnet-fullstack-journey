CashBox box = new CashBox();
box.Deposit(20.5m);
Console.WriteLine($"Balance: {box.Balance} KD");

box.Deposit(-500);
Console.WriteLine($"Balance: {box.Balance} KD");

class CashBox
{
    public decimal Balance { get; private set; }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit must be more then 0");
            return;
        }
        Balance = Balance + amount;
    }
}