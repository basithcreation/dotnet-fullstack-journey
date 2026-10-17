# Post 01: Number Guessing Game (post on Sat 17 Oct 2026)

Copy everything between the lines into LinkedIn as plain text.
(LinkedIn does not support Markdown, so no [links](...) and no `backticks`.)

---

Two weeks of learning C#, and I built my first real console game.

It picks a secret number from 1 to 100 and you guess until you get it. Simple idea, but it made me use everything I learned so far: if/else, switch, while, do-while, break and continue.

3 things that surprised me:

• int.Parse crashes if the user types "abc". int.TryParse doesn't crash. It returns false, so you can show a message and ask again.
• % in C# is not percent. It's the remainder: 7 % 3 = 1. I really thought it meant percent at first.
• break and continue look similar but do very different things. I used break for a wrong input, and one typo ended the whole game with "Correct! 0 attempts" 😅 continue was the right one: skip this guess and ask again.

Version 1.1 checks the range (500 is rejected and not counted), lets you type q to quit, and only says "Correct!" if you really won.

Code: https://github.com/basithcreation/dotnet-fullstack-journey/tree/main/projects/01-number-guessing-game

Next: arrays and a console calculator.

#dotnet #csharp #100DaysOfCode #learninpublic

---

**Screenshot:** the terminal during one real game: type `abc` (not a number message), `500` (out of range message), a few guesses with "Too high" / "Too low", then the win with the attempt count.
