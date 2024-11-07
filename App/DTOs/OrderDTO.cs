namespace App.DTOs;

using App.Models;

public class OrderDTO(
    Order order
)
{
    public int Id { get; set; } = order.Id;
    public IEnumerable<OrderItemDTO?> Items { get; set; } = order.Items?.Select(i => new OrderItemDTO(i)) ?? [];
    public double TotalAmount { get; set; } = order.TotalAmount;
    public string Status { get; set; } = order.Status.ToString();
    public int UserId { get; set; } = order.User.Id;
}
