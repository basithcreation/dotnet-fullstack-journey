
// using System.Security.Cryptography;

// Student s1 = new Student();
// s1.Name = "Ali";
// s1.Age = 20;

// Student s2 = new Student();
// s2.Name = "Sara";
// s2.Age = 22;

// Console.WriteLine($"{s1.Name} is {s1.Age}");
// Console.WriteLine($"{s2.Name} is {s2.Age}");

// s1.Age = s1.Age + 1;
// Console.WriteLine($"After birthday: {s1.Name} is {s1.Age}");
// Console.WriteLine($"{s2.Name} is still {s2.Age}");



List<Student> students = new List<Student>();

Student s3 = new Student();
s3.Name = "Ali";
s3.Age = 20;
students.Add(s3);

Student s4 = new Student();
s4.Name = "Sara";
s4.Age = 22;
students.Add(s4);

foreach (Student s in students)
{
    Console.WriteLine($"{s.Name} | {s.Age}");
}

Console.WriteLine($"Total: {students.Count}");






class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
