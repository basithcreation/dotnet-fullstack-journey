//double vs decimal: the rounding problem,
double a = 0.1;
double b = 0.2;
Console.WriteLine($"double : {a + b}");

decimal c = 0.1m;
decimal d = 0.2m;
Console.WriteLine($"decimal : {c + d}");

//char vs string
char firstLetter = 'B';
string word = "Basith";
Console.WriteLine($"{firstLetter} is the first letter of {word}");

//bool
bool isWeekend = false;
Console.WriteLine($"Weekend? {isWeekend}");

//int -> decimal wokrs automaticaly 
int days = 3;
decimal dailyFee = 0.750m;
decimal fee = days * dailyFee;
Console.WriteLine($"Fee: {fee:F3} KWD");