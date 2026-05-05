using System;
using System.Threading.Tasks;

Console.WriteLine("=== Top Level Statements Demo ===");

string name = "Nikita";
int age = 20;

Console.WriteLine($"Name: {name}, Age: {age}");

// Call local function
double result = CalculateArea(5);
Console.WriteLine($"Circle area: {result:F2}");

// Loop directly
Console.WriteLine("\n=== Direct Loop ===");
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Number: {i}");
}

// Using class
Console.WriteLine("\n=== Using Classes ===");
var student = new Student("Nikita", 20);
student.Display();

// Async code
Console.WriteLine("\n=== Async Code ===");
await FetchDataAsync();

Console.WriteLine("\nProgram completed!");


double CalculateArea(double radius)
{
    return Math.PI * radius * radius;
}

async Task FetchDataAsync()
{
    await Task.Delay(100);
    Console.WriteLine("Data fetched successfully!");
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Display()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}");
    }
}