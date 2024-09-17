using App.Models;

namespace App.DTOs
{
    public class OrderItemDTO(
        OrderItem orderItem
    )
    {
        public int ProductId { get; set; } = orderItem.Product.Id;
        public string Product { get; set; } = orderItem.Product.Name;
        public double Quantity { get; set; } = orderItem.Quantity;
        public double Total { get; set; } = orderItem.Total;
    }
}
