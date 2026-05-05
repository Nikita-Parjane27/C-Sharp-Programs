// Program.cs
// Demonstration of Primary Constructors in C# 12

using System;

Console.WriteLine("=== Primary Constructors ===");

// 1. Student
var student = new Student("Nikita", 20, "A");
student.Display();

Console.WriteLine("\n=== Bank Account ===");
var account = new BankAccount("Nikita", 10000);
account.Deposit(5000);
account.Withdraw(3000);
account.Withdraw(20000);

Console.WriteLine("\n=== Order Service with Logger ===");
var logger = new Logger("OrderService");
var service = new OrderService(logger);
service.PlaceOrder("Laptop", 2);
service.CancelOrder(101);

Console.WriteLine("\n=== Struct with Primary Constructor ===");
var p1 = new Point(0, 0);
var p2 = new Point(3, 4);

Console.WriteLine($"Point 1: {p1}");
Console.WriteLine($"Point 2: {p2}");
Console.WriteLine($"Distance: {p1.DistanceTo(p2)}");


// =======================
// Classes & Structs
// =======================

// 1. Basic primary constructor
class Student(string name, int age, string grade)
{
    public string Name => name;
    public int Age => age;
    public string Grade => grade;

    public void Display()
    {
        Console.WriteLine($"Student: {name}, Age: {age}, Grade: {grade}");
    }
}

// 2. Primary constructor with logic
class BankAccount(string owner, double initialBalance)
{
    private double _balance = initialBalance;

    public string Owner => owner;
    public double Balance => _balance;

    public void Deposit(double amount)
    {
        _balance += amount;
        Console.WriteLine($"{owner} deposited {amount:C}. Balance: {_balance:C}");
    }

    public bool Withdraw(double amount)
    {
        if (amount > _balance)
        {
            Console.WriteLine($"Insufficient funds for {owner}!");
            return false;
        }

        _balance -= amount;
        Console.WriteLine($"{owner} withdrew {amount:C}. Balance: {_balance:C}");
        return true;
    }
}

// 3. Dependency Injection style
class Logger(string prefix)
{
    public void Log(string message)
    {
        Console.WriteLine($"[{prefix}] {DateTime.Now:HH:mm:ss} - {message}");
    }
}

class OrderService(Logger logger)
{
    public void PlaceOrder(string item, int qty)
    {
        logger.Log($"Order placed: {item} x{qty}");
    }

    public void CancelOrder(int orderId)
    {
        logger.Log($"Order #{orderId} cancelled");
    }
}

// 4. Struct with primary constructor
struct Point(double x, double y)
{
    public double X => x;
    public double Y => y;

    public double DistanceTo(Point other)
    {
        return Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}