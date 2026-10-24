// Console.WriteLine("Start");
// try
// {
//     int boxes = int.Parse("abc");
//     Console.WriteLine($"Boxes: {boxes}");
// }
// catch (FormatException)
// {
//     Console.WriteLine("That is not a number");
// }
// Console.WriteLine("End");


// int[] shelves = { 10, 20, 30 };
// try
// {
//     Console.WriteLine(shelves[5]);
//     Console.WriteLine("Found it");
// }
// catch (FormatException)
// {
//     Console.WriteLine("Bad number");
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Problem: {ex.Message}");
// }
// finally
// {
//     Console.WriteLine("Shelf check done");
// }





// try
// {
//     Console.WriteLine(GetFee(2));
//     Console.WriteLine(GetFee(-3));
//     Console.WriteLine(GetFee(5));
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
// }

// static double GetFee(double kg)
// {
//     if (kg <= 0)
//     {
//         throw new ArgumentException("Weight must be more than 0");
//     }
//     return kg * 1.5;
// }

// ---- Exercise: split boxes ----

string boxInput = "12";
int drivers = 0;

try
{
    int boxCount = int.Parse(boxInput);
    int boxesEach = BoxesPerDriver(boxCount, drivers);

    Console.WriteLine($"Each driver gets {boxesEach} boxes");
}
catch (FormatException)
{
    Console.WriteLine("Boxes must be a number");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Split finished");
}


static int BoxesPerDriver(int boxes, int drivers)
{
    if (drivers <= 0)
    {
        throw new ArgumentException("Need at least 1 driver");
    }
    return boxes / drivers;

}