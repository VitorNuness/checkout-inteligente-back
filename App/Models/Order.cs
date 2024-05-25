using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public User? User { get; set; }
        public List<Product>? Products { get; set; }

        public Order(User? user)
        {
            this.User = user;
            this.Products = new List<Product>();
        }

        private Order() { }
    }
}
