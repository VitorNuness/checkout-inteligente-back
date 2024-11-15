namespace Core.DTOs;

using Core.Models;

public class OrderItemDTO
{
    public double Quantity { get; set; }
    public double Total { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public OrderItemDTO(
        OrderItem orderItem
    )
    {
        this.ProductId = orderItem.Product.Id;
        this.Product = orderItem.Product;
        this.Quantity = orderItem.Quantity;
        this.Total = orderItem.Total;
    }
}
