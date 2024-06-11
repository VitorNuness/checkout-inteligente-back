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
        public bool IsComplete { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<OrderItem>? Items { get; set; }
        public bool FreeShipping { get; set; }

        public Order(User? user, int? userId)
        {
            this.IsComplete = false;
            this.FreeShipping = false;
            this.User = user;
            this.UserId = userId;
            this.Items = new List<OrderItem>();
        }

        private Order() { }
    }
}
