using System;
using System.Collections.Generic;

class Employee { public int Id; public string Name; public string Dept; public double Salary; }
class Product2 { public int Id; public string Name; public int Stock; }

class MiniERP
{
    static List<Employee> employees = new List<Employee>();
    static List<Product2> products = new List<Product2>();
    static int empId = 1, prodId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Mini ERP System ===");
            Console.WriteLine("1. Employee Module");
            Console.WriteLine("2. Inventory Module");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) EmployeeModule();
            else if (ch == 2) InventoryModule();
            else break;
        }
    }

    static void EmployeeModule()
    {
        Console.WriteLine("\n-- Employee Module --");
        Console.WriteLine("1. Add  2. View");
        int ch = int.Parse(Console.ReadLine());
        if (ch == 1)
        {
            Console.Write("Name: "); string n = Console.ReadLine();
            Console.Write("Dept: "); string d = Console.ReadLine();
            Console.Write("Salary: "); double s = double.Parse(Console.ReadLine());
            employees.Add(new Employee { Id = empId++, Name = n, Dept = d, Salary = s });
            Console.WriteLine("Employee added!");
        }
        else
        {
            foreach (var e in employees)
                Console.WriteLine($"ID:{e.Id} | {e.Name} | {e.Dept} | {e.Salary:C}");
        }
    }

    static void InventoryModule()
    {
        Console.WriteLine("\n-- Inventory Module --");
        Console.WriteLine("1. Add  2. View");
        int ch = int.Parse(Console.ReadLine());
        if (ch == 1)
        {
            Console.Write("Product Name: "); string n = Console.ReadLine();
            Console.Write("Stock: "); int s = int.Parse(Console.ReadLine());
            products.Add(new Product2 { Id = prodId++, Name = n, Stock = s });
            Console.WriteLine("Product added!");
        }
        else
        {
            foreach (var p in products)
                Console.WriteLine($"ID:{p.Id} | {p.Name} | Stock:{p.Stock}");
        }
    }
}
