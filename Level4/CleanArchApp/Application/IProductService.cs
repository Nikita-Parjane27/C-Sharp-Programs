public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    void Delete(int id);
}