// File-scoped namespace - applies to entire file
// No curly braces needed!
namespace MyApp.Models;

class Product
{
    public int    Id       { get; set; }
    public string Name     { get; set; }
    public double Price    { get; set; }
    public string Category { get; set; }

    public void Display()
        => Console.WriteLine($"ID:{Id} | {Name} | {Price:C} | {Category}");
}

class Order
{
    public int      Id       { get; set; }
    public string   Customer { get; set; }
    public List<Product> Items { get; set; } = new();
    public double Total => Items.Sum(i => i.Price);

    public void Display()
    {
        Console.WriteLine($"Order #{Id} for {Customer}");
        Items.ForEach(i => i.Display());
        Console.WriteLine($"Total: {Total:C}");
    }
}