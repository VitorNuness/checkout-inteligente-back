namespace Core.DTOs;

using Core.Models;

public class OrderDTO
{
    public int Id { get; set; }
    public string Status { get; set; }
    public double TotalAmount { get; set; }
    public int UserId { get; set; }
    public List<OrderItemDTO> Items { get; set; }

    public OrderDTO(
        Order order
    )
    {
        this.Id = order.Id;
        this.Status = order.Status.ToString();
        this.TotalAmount = order.TotalAmount;
        this.UserId = order.User.Id;
        this.Items = order.Items?.Select(i => new OrderItemDTO(i)).ToList() ?? [];
    }
}
