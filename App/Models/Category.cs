using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public IList<Product>? Products { get; set; }

        public Category(string? name)
        {
            this.Name = name;
            this.Products = new List<Product>();
        }

        private Category() { }
    }
}
