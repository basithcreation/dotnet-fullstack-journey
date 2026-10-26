# Post 02: Phase 1 done, Shipment Tracker (posted Mon 26 Oct 2026)

Copy everything between the lines into LinkedIn as plain text.
(LinkedIn does not support Markdown, so no [links](...) and no `backticks`.)

---

3 weeks of C#, and I finished the basics with a small courier app.

I work at a courier company, so my third project is a Shipment Tracker: add a shipment, list them all, search by tracking number, and mark it as delivered. It's a console app, 93 lines, and it doesn't crash when you type a wrong tracking number.

3 things in C# that surprised me as a Dart developer:

• Null looks the same, but prints differently. int?, ??, ?. and ??= work just like in Dart. But Dart prints the word "null" and C# prints nothing at all. I guessed "[null]" and got "[]".
• throw is better than return 0. If the weight is -3 kg, returning 0 looks like a real fee and the bug hides. Throwing an exception stops it loudly. I learned the phrase "fail fast".
• Index 0 is a real index. I wrote "if (index <= 0) not found", and my first shipment, KP1001, was "not found". One test with the first item showed the bug. Now I always test the first and the last item.

Now: object-oriented programming. I started classes this week, and my 4 separate lists (numbers, names, statuses, dates) are going to become one Shipment class.

Code: https://github.com/basithcreation/dotnet-fullstack-journey/tree/main/projects/03-shipment-tracker

#dotnet #csharp #100DaysOfCode #learninpublic

---

**Screenshot:** the terminal during one real run: add 2 shipments, list them (with dates), mark KP1001 as delivered, list again, then search for KP5555 to show the "Error: Shipment KP5555 not found" line.
