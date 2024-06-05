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
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int Views { get; set; }

        public Product(string? name, int categoryId, Category category, double quantity, double price)
        {
            this.Name = name;
            this.CategoryId = categoryId;
            this.Category = category;
            this.Quantity = quantity;
            this.Price = price;
            this.Views = 0;
        }

        private Product() { }
    }
}
