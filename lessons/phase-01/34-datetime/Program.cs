DateTime sent = new DateTime(2026, 10, 24, 14, 30, 0);
Console.WriteLine(sent.ToString("dd MMM yyyy HH:mm"));

DateTime due = sent.AddDays(3);
Console.WriteLine(due.ToString("dd MMM yyyy"));
Console.WriteLine(due.DayOfWeek);

TimeSpan wait = due - sent;
Console.WriteLine(wait.Days);
Console.WriteLine(DateTime.Now);
