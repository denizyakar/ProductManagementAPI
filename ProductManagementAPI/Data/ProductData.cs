using ProductManagementAPI.Models;

namespace ProductManagementAPI.Data
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>(); // database yerine static bir list kullaniyoruz

        public static int NextId = 1; // ilk product nesnesinin id'si
    }
}
