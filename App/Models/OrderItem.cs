using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace App.Models
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required Order Order { get; set; }
        public required Product Product { get; set; }
        public double Quantity { get; set; }
        public double Total { get; private set; }

        [SetsRequiredMembers]
        public OrderItem(
                    Product product,
                    Order order,
                    double quantity = 1
                )
        {
            Product = product;
            Order = order;
            Quantity = quantity;

            CalculateTotal();
        }

        private OrderItem() { }

        public void AddQuantity()
        {
            Quantity++;
            CalculateTotal();
        }

        public void RemoveQuantity()
        {
            Quantity--;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = Product.Price * Quantity;
        }
    }
}
