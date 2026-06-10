using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepository 

    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);

        Product? Update(int id, Product product);

        bool Delete(int id);
    }
}
