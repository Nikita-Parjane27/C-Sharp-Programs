using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

class InventoryManagement
{
    static List<Product> inventory = new List<Product>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Inventory Management System ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddProduct(); break;
                case 2: ViewProducts(); break;
                case 3: UpdateProduct(); break;
                case 4: DeleteProduct(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice!"); break;
            }
        }
    }

    static void AddProduct()
    {
        Product p = new Product();
        p.Id = nextId++;
        Console.Write("Enter Product Name: ");
        p.Name = Console.ReadLine();
        Console.Write("Enter Quantity: ");
        p.Quantity = int.Parse(Console.ReadLine());
        Console.Write("Enter Price: ");
        p.Price = double.Parse(Console.ReadLine());
        inventory.Add(p);
        Console.WriteLine("Product added successfully!");
    }

    static void ViewProducts()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }
        Console.WriteLine("\nID\tName\t\tQty\tPrice");
        foreach (var p in inventory)
            Console.WriteLine($"{p.Id}\t{p.Name}\t\t{p.Quantity}\t{p.Price:C}");
    }

    static void UpdateProduct()
    {
        Console.Write("Enter Product ID to update: ");
        int id = int.Parse(Console.ReadLine());
        var p = inventory.Find(x => x.Id == id);
        if (p == null) { Console.WriteLine("Product not found!"); return; }

        Console.Write("New Name: ");
        p.Name = Console.ReadLine();
        Console.Write("New Quantity: ");
        p.Quantity = int.Parse(Console.ReadLine());
        Console.Write("New Price: ");
        p.Price = double.Parse(Console.ReadLine());
        Console.WriteLine("Product updated!");
    }

    static void DeleteProduct()
    {
        Console.Write("Enter Product ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        var p = inventory.Find(x => x.Id == id);
        if (p == null) { Console.WriteLine("Product not found!"); return; }
        inventory.Remove(p);
        Console.WriteLine("Product deleted!");
    }
}