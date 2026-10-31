CashBox box = new CashBox();
box.Deposite(20.5m);
Console.WriteLine($"Balance: {box.Balance} KD");

box.Deposite(-500);
Console.WriteLine($"Balance: {box.Balance} KD");

class CashBox
{
    public decimal Balance { get; private set; }
    public void Deposite(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposite must be more then 0");
            return;
        }
        Balance = Balance + amount;
    }
}