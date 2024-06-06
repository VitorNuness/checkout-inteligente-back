using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int Views { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public Product(string? name, int categoryId, Category category, double quantity, double price, int? imageId = null, Image? image = null)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.Views = 0;

            this.CategoryId = categoryId;
            this.Category = category;

            this.ImageId = imageId;
            this.Image = image;
        }

        private Product() { }
    }
}
