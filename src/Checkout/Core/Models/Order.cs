namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public double TotalAmount { get; private set; }
    public DateTime? CompletedAt { get; set; }
    public EOrderStatus Status { get; set; } = EOrderStatus.CURRENT;
    public User User { get; set; }
    public List<OrderItem> Items { get; set; } = [];

    public Order(
        User user
    )
    {
        this.User = user;
        this.CalculateTotal();
    }

    public Order(
        int id,
        double totalAmount,
        DateTime? completedAt,
        EOrderStatus status,
        User user
    )
    {
        this.Id = id;
        this.TotalAmount = totalAmount;
        this.CompletedAt = completedAt;
        this.Status = status;
        this.User = user;
    }

    private Order() { }

    public void CalculateTotal() => this.TotalAmount = this.Items?.Sum(i => i?.Total) ?? 0;

    public void CompleteOrder()
    {
        if (this.Status != EOrderStatus.CURRENT || this.TotalAmount <= 0)
        {
            return;
        }

        this.Status = EOrderStatus.COMPLETE;
        this.CompletedAt = DateTime.Now;
    }

    public void AddProduct(Product product)
    {
        if (this.Status != EOrderStatus.CURRENT)
        {
            return;
        }

        var orderItem = this.Items?.Find(i => i?.Product == product);

        if (orderItem != null)
        {
            orderItem.AddQuantity();
        }
        else
        {
            orderItem = new(product, this);
            this.Items?.Add(orderItem);
        }

        this.CalculateTotal();
    }

    public void RemoveProduct(Product product)
    {
        if (this.Status != EOrderStatus.CURRENT)
        {
            return;
        }

        var orderItem = this.Items?.Find(i => i?.Product == product);

        orderItem?.RemoveQuantity();

        if (orderItem?.Quantity <= 0)
        {
            this.Items?.Remove(orderItem);
        }

        this.CalculateTotal();
    }
}
