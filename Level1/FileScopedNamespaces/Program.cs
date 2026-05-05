using MyApp.Models;
using MyApp.Services;

Console.WriteLine("=== File-Scoped Namespaces Demo ===");

var service = new ProductService();

Console.WriteLine("All Products:");
service.GetAll().ForEach(p => p.Display());

Console.WriteLine("\nElectronics only:");
service.GetByCategory("Electronics").ForEach(p => p.Display());

Console.WriteLine("\nAdd new product:");
service.Add(new Product { Id=4, Name="Tablet", Price=30000, Category="Electronics" });
service.GetAll().ForEach(p => p.Display());

Console.WriteLine("\nCreate Order:");
var order = new Order
{
    Id       = 1,
    Customer = "Nikita",
    Items    = service.GetByCategory("Electronics")
};
order.Display();