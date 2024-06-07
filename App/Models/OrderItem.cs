using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

        public OrderItem(int productId, Product product, double quantity, int orderId, Order order)
        {
            this.ProductId = productId;
            this.Product = product;
            this.Quantity = quantity;
            this.OrderId = orderId;
            this.Order = order;

            this.Total = product.Price * quantity;
        }

        private OrderItem() { }
    }
}
