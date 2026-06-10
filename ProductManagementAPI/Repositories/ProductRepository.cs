using ProductManagementAPI.Models;
using ProductManagementAPI.Data;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            return ProductData.Products;
        }

        public Product? GetById(int id)
        {
            foreach(var product in ProductData.Products)
            {
                if (product.Id == id) { return product; } 
      
            }
            return null;
        }
        public Product Add(Product product)
        {
            product.Id = ProductData.NextId; // 1 ile baslatilan id'yi ilk eklenen product'a ver
            ProductData.NextId++; // sonraki eklenecek product icin arttir
            ProductData.Products.Add(product);
            return product;
        }

        public Product? Update(int id, Product product)
        {
            foreach(var i in ProductData.Products)
            {
                if (i.Id == id)
                {
                    i.Name = product.Name;
                    i.Price = product.Price;
                    i.Stock = product.Stock;
                    i.Description = product.Description;

                    return i;
                } 

            } return null;
        }

        public bool Delete(int id)
        {
            //foreach (var product in ProductData.Products)
            //{
            //    if (product.Id == id) { ProductData.Products.Remove(product); return true; }
            //}

            var product = GetById(id);

            if (product == null) { return false; }
            ProductData.Products.Remove(product);
            
            return true;

        }
    }
}


