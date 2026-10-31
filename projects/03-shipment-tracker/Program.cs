



List<string> numbers = new List<string>();
List<string> receivers = new List<string>();
List<string> statuses = new List<string>();
List<DateTime> createdTimes = new List<DateTime>();

List<Shipment> shipments = new List<Shipment>();



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
                string number = $"KP{1001 + shipments.Count}";
                Console.Write("Receiver name: ");
                string receiver = (Console.ReadLine() ?? "").Trim();
                Shipment s = new Shipment { Number = number, Receiver = receiver };
                shipments.Add(s);
                Console.WriteLine($"Added {number}");
                break;
            case "2":
                if (shipments.Count == 0)
                {
                    Console.WriteLine("No shipments yet");
                }
                else
                {
                    foreach (Shipment shipment in shipments)
                    {
                        Console.WriteLine($"{shipment.Number} | {shipment.Receiver} | {shipment.Status} | {shipment.CreatedAt.ToString("dd MMM yyyy HH:mm")}");
                    }
                }
                break;
            case "3":
                Console.Write("Tracking number: ");
                string searchNumber = (Console.ReadLine() ?? "").Trim().ToUpper();
                Shipment found = FindShipment(shipments, searchNumber);
                Console.WriteLine($"{found.Number} | {found.Receiver} | {found.Status} | {found.CreatedAt.ToString("dd MMM yyyy HH:mm")}");
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

static Shipment FindShipment(List<Shipment> list, string number)
{

    foreach (Shipment shipment in list)
    {
        if (shipment.Number == number)
        {
            return shipment;
        }
    }
    throw new ArgumentException($"Shipment {number} not found");
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


class Shipment
{
    public required string Number { get; init; }
    public required string Receiver { get; init; }
    public string Status { get; set; } = "In transit";
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}