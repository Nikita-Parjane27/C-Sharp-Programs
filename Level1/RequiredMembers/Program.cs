// Program.cs
// Demonstration of Required Members in C# 11

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("=== Required Members ===");

// Must provide all required members
var student = new Student
{
    Id = 1,
    Name = "Nikita",
    Email = "nikita@email.com",
    Age = 20 // Optional
};
student.Display();

Console.WriteLine("\n=== Employee ===");
var emp = new Employee
{
    Name = "Ashwini",
    Department = "IT",
    Salary = 50000
    // Role is optional
};
emp.Display();

Console.WriteLine("\n=== Address Struct ===");
var address = new Address
{
    Street = "MG Road",
    City = "Pune",
    State = "Maharashtra",
    Zip = "411001"
};
Console.WriteLine(address);

Console.WriteLine("\n=== Product with Constructor ===");
var product = new Product("Laptop", 50000, "Electronics");
product.Display();

Console.WriteLine("\n=== List of Students ===");
var students = new List<Student>
{
    new() { Id = 1, Name = "Nikita", Email = "n@email.com" },
    new() { Id = 2, Name = "Ashwini", Email = "a@email.com" },
    new() { Id = 3, Name = "Shubhangi", Email = "s@email.com" }
};

students.ForEach(s => s.Display());


// =======================
// Classes & Structs
// =======================

// 1. Basic required members
class Student
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public int Age { get; set; } = 18; // Optional

    public void Display()
    {
        Console.WriteLine($"ID:{Id} | {Name} | {Email} | Age:{Age}");
    }
}

// 2. Required with validation-style structure
class Employee
{
    public required string Name { get; set; }
    public required string Department { get; set; }
    public required double Salary { get; set; }
    public string Role { get; set; } = "Staff"; // Optional

    public void Display()
    {
        Console.WriteLine($"{Name} | {Department} | {Salary:C} | {Role}");
    }
}

// 3. Required in struct
struct Address
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public string Zip { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {Zip}";
    }
}

// 4. Using SetsRequiredMembers in constructor
class Product
{
    public required string Name { get; set; }
    public required double Price { get; set; }
    public required string Category { get; set; }

    [SetsRequiredMembers]
    public Product(string name, double price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"{Name} | {Price:C} | {Category}");
    }
}