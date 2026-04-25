// Install: dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// dotnet add package Microsoft.EntityFrameworkCore.Tools

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=.;Database=EFCoreDB;Integrated Security=true;");
}

class EFCoreCRUD
{
    static void Main()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        // Create
        db.Students.Add(new Student { Name = "Nikita", Age = 20 });
        db.SaveChanges();
        Console.WriteLine("Student added.");

        // Read
        var students = db.Students.ToList();
        Console.WriteLine("\nAll Students:");
        foreach (var s in students)
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");

        // Update
        var student = db.Students.FirstOrDefault(s => s.Name == "Nikita");
        if (student != null)
        {
            student.Age = 21;
            db.SaveChanges();
            Console.WriteLine("\nStudent updated.");
        }

        // Delete
        if (student != null)
        {
            db.Students.Remove(student);
            db.SaveChanges();
            Console.WriteLine("Student deleted.");
        }
    }
}