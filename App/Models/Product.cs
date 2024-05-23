using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int Views { get; set; }

        public Product(string? name, Category category, double quantity, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Quantity = quantity;
            this.Price = price;
            this.Views = 0;
        }

        private Product() { }
    }
}
