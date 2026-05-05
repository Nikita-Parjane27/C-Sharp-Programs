namespace MyApp.Services;

using MyApp.Models;

class ProductService
{
    private static List<Product> _products = new()
    {
        new Product { Id=1, Name="Laptop",  Price=50000, Category="Electronics" },
        new Product { Id=2, Name="Phone",   Price=20000, Category="Electronics" },
        new Product { Id=3, Name="T-Shirt", Price=500,   Category="Clothing"    }
    };

    public List<Product> GetAll()                        => _products;
    public Product GetById(int id)                       => _products.Find(p => p.Id == id);
    public List<Product> GetByCategory(string category)  => _products.Where(p => p.Category == category).ToList();
    public void Add(Product p)                           => _products.Add(p);
}