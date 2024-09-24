using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace App.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public string? ImageUrl { get; set; } = "http://localhost:5102/files/images/products/0.png";
        public required Category Category { get; set; }
        public List<Campaign?> Campaigns { get; set; } = [];

        [SetsRequiredMembers]
        public Product(
            string name,
            Category category,
            double quantity = 0,
            double price = 0
        )
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            Price = price;
        }

        private Product() { }
    }
}
