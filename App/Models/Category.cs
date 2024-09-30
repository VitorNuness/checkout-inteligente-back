using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace App.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Product?> Products { get; set; } = [];
        public string ImageUrl { get; set; } = "http://localhost:5102/files/images/categories/0.png";

        [SetsRequiredMembers]
        public Category(string name)
        {
            Name = name;
        }

        private Category() { }
    }
}
