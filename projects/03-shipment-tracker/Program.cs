



List<string> numbers = new List<string>();
List<string> receivers = new List<string>();
List<string> statuses = new List<string>();
List<DateTime> createdTimes = new List<DateTime>();

Console.WriteLine("=== KPOST Shipment Tracker ===");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1) Add 2) List 3) Search 4) Mark delivered q) Quit");
    Console.Write("Choose: ");
    string choice = (Console.ReadLine() ?? "").Trim().ToLower();

    if (choice == "q")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    try
    {
        switch (choice)
        {
            case "1":
                string number = $"KP{1001 + numbers.Count}";

                Console.Write("Receiver name: ");
                string receiver = (Console.ReadLine() ?? "").Trim();
                numbers.Add(number);
                Console.WriteLine($"Added {number}");
                receivers.Add(receiver);
                statuses.Add("In transit");
                createdTimes.Add(DateTime.Now);
                break;
            case "2":
                if (numbers.Count == 0)
                {
                    Console.WriteLine("No shipments yet");
                }
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        Console.WriteLine($"{numbers[i]} | {receivers[i]} | {statuses[i]} | {createdTimes[i].ToString("dd MMM yyyy HH:mm")}");
                    }
                }
                break;
            case "3":
                Console.Write("Tracking number: ");
                string searchNumber = (Console.ReadLine() ?? "").Trim().ToUpper();
                int index = numbers.IndexOf(searchNumber);
                if (index < 0)
                {
                    Console.WriteLine($"Shipment {searchNumber} not found");
                }
                else
                {
                    Console.WriteLine($"{numbers[index]} | {receivers[index]} | {statuses[index]} | {createdTimes[index].ToString("dd MMM yyyy HH:mm")}");

                }
                break;
            case "4":
                Console.Write("Tracking number: ");
                string deliverNumber = (Console.ReadLine() ?? "").Trim().ToUpper();
                int deliverIndex = FindIndex(numbers, deliverNumber);
                statuses[deliverIndex] = "Delivered";
                Console.WriteLine($"{deliverNumber} marked as delivered");
                break;
            default:
                Console.WriteLine("Unknown choice");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


static int FindIndex(List<string> list, string number)
{
    int found = list.IndexOf(number);
    if (found == -1)
    {
        throw new ArgumentException($"Shipment {number} not found");
    }
    return found;
}