namespace App.DTOs;

using App.Models;

public class OrderItemDTO(
    OrderItem orderItem
)
{
    public int ProductId { get; set; } = orderItem.Product.Id;
    public Product Product { get; set; } = orderItem.Product;
    public double Quantity { get; set; } = orderItem.Quantity;
    public double Total { get; set; } = orderItem.Total;
}
