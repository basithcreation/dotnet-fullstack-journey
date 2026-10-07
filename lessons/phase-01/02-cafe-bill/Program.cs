string customerName = "Fatima";
char tableLetter = 'C';
bool isTakeaway = false;

Console.WriteLine($"Customer:{customerName} Table:{tableLetter} Takeaway:{isTakeaway}");

int latteQuantity = 2;
decimal lattePrice = 1.350m;
decimal totalLatteAmount = latteQuantity * lattePrice;

Console.WriteLine($"Spanish latte x{latteQuantity} {totalLatteAmount:F3} KWD");

int cakeQuantity = 1;
decimal cakePrice = 2.100m;
decimal totalCakeAmonut = cakeQuantity * cakePrice;

Console.WriteLine($"Cake x{cakeQuantity} {totalCakeAmonut:F3} KWD");

decimal totalBillAmount = totalLatteAmount + totalCakeAmonut;

Console.WriteLine("------------------------------");

Console.WriteLine($"Total {totalBillAmount:F3} KWD");
