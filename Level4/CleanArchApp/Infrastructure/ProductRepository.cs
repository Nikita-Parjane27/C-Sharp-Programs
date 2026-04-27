public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    void Delete(int id);
}

public class ProductRepository : IProductRepository
{
    private static List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 50000 },
        new Product { Id = 2, Name = "Phone",  Price = 20000 }
    };

    public List<Product> GetAll()   => _products;
    public Product GetById(int id)  => _products.Find(p => p.Id == id);
    public void Add(Product p)      => _products.Add(p);
    public void Delete(int id)      => _products.RemoveAll(p => p.Id == id);
}