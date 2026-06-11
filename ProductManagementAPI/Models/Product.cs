namespace ProductManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; } // benzersiz olmali
        public string Name { get; set; }

        public string? Description { get; set; } // nullable

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}


