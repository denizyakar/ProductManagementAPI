using ProductManagementAPI.Models;

namespace ProductManagementAPI.Data
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>
            {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 25000,
                Stock = 10,
                Description = "16 GB RAM, 512 GB SSD laptop"
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 450,
                Stock = 50,
                Description = "Kablosuz optik mouse"
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 1200,
                Stock = 25,
                Description = "Mekanik klavye"
            },
            new Product
            {
                Id = 4,
                Name = "Monitor",
                Price = 5000,
                Stock = 15,
                Description = "24 inch Full HD monitor"
            },
            new Product
            {
                Id = 5,
                Name = "Headset",
                Price = 1800,
                Stock = 20,
                Description = "Mikrofonlu oyuncu kulaklığı"
            } 
        };

        public static int NextId = 11; // sonraki product nesnesinin id'si
           
    }
}
