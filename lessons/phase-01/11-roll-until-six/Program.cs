
int rolls = 0;
int dice = 7;


while (dice != 6)
{
    rolls++;
    dice = Random.Shared.Next(1, 7);
    Console.WriteLine($"Roll {rolls}: {dice}");

}

if (rolls == 1)
{
    Console.WriteLine($"Lucky! First try!");
}
else
{
    Console.WriteLine($"🎉 Got a 6 after {rolls} rolls!");
}

