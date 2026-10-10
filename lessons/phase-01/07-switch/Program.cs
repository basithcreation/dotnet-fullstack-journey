string light = "blue";

switch (light)
{
    case "red":
        Console.WriteLine("Stop");
        break;
    case "yellow":
        Console.WriteLine("Slow down");
        break;
    case "green":
        Console.WriteLine("Go");
        break;
    case "flashing":
    case "off":
        Console.WriteLine("Drive Carefully");
        break;
    default:
        Console.WriteLine("Unknown light");
        break;

}

int temp = 5;

string feel = temp switch

{
    >= 40 => "Very hot",
    >= 25 => "Warm",
    >= 10 => "Cool",
    _ => "Cold"
};

Console.WriteLine(feel);

