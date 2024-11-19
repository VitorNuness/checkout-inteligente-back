namespace Core.DTOs;

using Core.Models;

public class OrderDTO(
    Order order
    )
{
    public int Id { get; set; } = order.Id;
    public string Status { get; set; } = order.Status.ToString();
    public double TotalAmount { get; set; } = order.TotalAmount;
    public int UserId { get; set; } = order.User.Id;
    public List<OrderItemDTO> Items { get; set; } = order.Items?.Select(i => new OrderItemDTO(i)).ToList() ?? [];
}
