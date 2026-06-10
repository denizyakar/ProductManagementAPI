using ProductManagementAPI.Repositories;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; //

        public ProductService(IProductRepository productRepository) /// Dependency Injection
        {
            _productRepository = productRepository; //
        }

        //getall
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        //getbyid
        public Product? GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        //add
        public Product? Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name)) { return null; }

            if (product.Price < 0) { return null; }

            if (product.Stock < 0) { return null; }

            return _productRepository.Add(product); 
        }

        //update
        public Product? Update(int id, Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name)) { return null; }

            if (product.Price < 0) { return null; }

            if (product.Stock < 0) { return null; }

            return _productRepository.Update(id, product);
        }

        //delete

        public bool Delete(int id)
        {
            return (_productRepository.Delete(id));
        }

    }
}
