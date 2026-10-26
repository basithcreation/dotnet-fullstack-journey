
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

Student s5 = new Student();
s5.Name = "Omar";
s5.Age = 25;
students.Add(s5);

int totalAge = 0;

foreach (Student s in students)
{
    Console.WriteLine($"{s.Name} | {s.Age}");
    totalAge = totalAge + s.Age;
}

Console.WriteLine($"Total: {students.Count}");
Console.WriteLine($"Total age: {totalAge}");

List<Product> products = new List<Product>();

Product p1 = new Product();
p1.Name = "Pen";
p1.Price = 0.250m;
p1.Quantity = 10;

products.Add(p1);

Product p2 = new Product();
p2.Name = "Notebook";
p2.Price = 1.500m;
p2.Quantity = 4;

products.Add(p2);

Product p3 = new Product();
p3.Name = "Bag";
p3.Price = 7.000m;
p3.Quantity = 1;
products.Add(p3);

decimal totalPrice = 0;

foreach (Product p in products)
{
    decimal lineValue = p.Price * p.Quantity;
    totalPrice += lineValue;
    Console.WriteLine($"{p.Name} | {p.Price} KD x {p.Quantity} = {lineValue} KD");
}

Console.WriteLine($"Products: {products.Count}");
Console.WriteLine($"Total value: {totalPrice} KD");

class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

class Product
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

