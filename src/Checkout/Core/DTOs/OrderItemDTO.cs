namespace Core.DTOs;

using Core.Models;

public class OrderItemDTO(
    OrderItem orderItem
    )
{
    public double Quantity { get; set; } = orderItem.Quantity;
    public double Total { get; set; } = orderItem.Total;
    public int ProductId { get; set; } = orderItem.Product.Id;
    public Product Product { get; set; } = orderItem.Product;
}
