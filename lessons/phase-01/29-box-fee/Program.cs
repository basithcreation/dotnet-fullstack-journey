Console.WriteLine(Fees.GetFee(4));
Console.WriteLine(Fees.GetFee(4, "Jahra"));
Console.WriteLine(Fees.GetFee(4, "Hawalli"));



static class Fees
{
    public static int GetFee(int boxes)
    {

        int fee = boxes * 2;
        return fee;

    }
    public static int GetFee(int boxes, string city)
    {
        int fee = GetFee(boxes);
        if (city == "Jahra")
        {
            return fee + 3;
        }
        else
        {
            return fee;
        }
    }
}