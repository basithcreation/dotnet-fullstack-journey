// Tests:
// abc  -> Please enter a number.            
// -5   -> Marks must be between 0 and 100.  
// 101  -> Marks must be between 0 and 100.
// 100  -> Marks: 100 | Grade: A | Great job!
// 90   -> Marks: 90 | Grade: A | Great job!
// 89   -> Marks: 89 | Grade: B | Great job!
// 50   -> Marks: 50 | Grade: D | You passed.
// 49   -> Marks: 49 | Grade: F | Try again.
// 0    -> Marks: 0 | Grade: F | Try again.


Console.Write("Enter your mark (0-100): ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int mark))
{
    Console.WriteLine("Please enter a number.");
    return;
}
else if (mark < 0 || mark > 100)
{
    Console.WriteLine("Marks must be between 0 and 100.");
    return;
}
char grade = mark switch
{
    >= 90 => 'A',
    >= 75 => 'B',
    >= 60 => 'C',
    >= 50 => 'D',
    _ => 'F',
};

//string gradeComment = grade switch
//{
//    'A' or 'B' => "Great job!",
//    'C' or 'D' => "You passed.",
//    'F' => "Try again.",
//    _ => "Invalid"
//};

string gradeComment = "";

switch (grade)
{
    case 'A':
    case 'B':
        gradeComment = "Great job!";
        break;
    case 'C':
    case 'D':
        gradeComment = "You passed.";
        break;
    case 'F':
        gradeComment = "Try again.";
        break;

    default:
        gradeComment = "Unknown grade";
        break;
}

Console.WriteLine($"Marks: {mark} | Grade: {grade} | {gradeComment}");