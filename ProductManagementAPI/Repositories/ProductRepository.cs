using ProductManagementAPI.Models;
using ProductManagementAPI.Data;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Product> GetAll()
        {
            //database oncesi kodlar

            //return ProductData.Products;

            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            // database oncesi kodlar

            //foreach(var product in ProductData.Products)
            //{
            //    if (product.Id == id) { return product; } 

            //}
            //return null;

            return _context.Products.Find(id);
        }
        public Product Add(Product product)
        {
            //database oncesi kodlar

            //product.Id = ProductData.NextId; // 1 ile baslatilan id'yi ilk eklenen product'a ver
            //ProductData.NextId++; // sonraki eklenecek product icin arttir
            //ProductData.Products.Add(product);
            //return product;

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;

        }

        public Product? Update(int id, Product product)
        {
            //database oncesi kodlar

            //foreach(var i in ProductData.Products)
            //{
            //    if (i.Id == id)
            //    {
            //        i.Name = product.Name;
            //        i.Price = product.Price;
            //        i.Stock = product.Stock;
            //        i.Description = product.Description;

            //        return i;
            //    } 

            //} return null;

            var existingProduct = _context.Products.Find(id);  

            if (existingProduct == null)
            { return null; }

            existingProduct.Name = product.Name;    
            existingProduct.Description = product.Description; 
            existingProduct.Price = product.Price;  
            existingProduct.Stock = product.Stock;

            _context.SaveChanges();
            
            return existingProduct;
        }

        public bool Delete(int id)
        {
            //database oncesi kodlar

            //foreach (var product in ProductData.Products)
            //{
            //    if (product.Id == id) { ProductData.Products.Remove(product); return true; }
            //}

            var product = GetById(id);

            if (product == null) { return false; }

           _context.Products.Remove(product);
            _context.SaveChanges();

            return true;

        }
    }
}


