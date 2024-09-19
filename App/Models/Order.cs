using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using App.Enums;

namespace App.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required User User { get; set; }
        public List<OrderItem?> Items { get; set; } = [];
        public double TotalAmount { get; private set; }
        public EOrderStatus Status { get; private set; } = EOrderStatus.CURRENT;

        [SetsRequiredMembers]
        public Order(User user)
        {
            User = user;

            CalculateTotal();
        }

        private Order() { }

        public void CalculateTotal()
        {
            TotalAmount = Items?.Sum(i => i?.Total) ?? 0;
        }

        public void CompleteOrder()
        {
            Status = EOrderStatus.COMPLETE;
        }

        public void AddProduct(Product product)
        {
            if (Status != EOrderStatus.CURRENT)
            {
                return;
            }

            OrderItem? orderItem = Items?.Find(i => i?.Product == product);

            if (orderItem != null)
            {
                orderItem.AddQuantity();
            }
            else
            {
                orderItem = new(product, this);
                Items?.Add(orderItem);
            }

            CalculateTotal();
        }

        public void RemoveProduct(Product product)
        {
            if (Status != EOrderStatus.CURRENT)
            {
                return;
            }

            OrderItem? orderItem = Items?.Find(i => i?.Product == product);

            orderItem?.RemoveQuantity();

            if (orderItem?.Quantity <= 0)
            {
                Items?.Remove(orderItem);
            }

            CalculateTotal();
        }
    }
}
