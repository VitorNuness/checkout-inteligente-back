namespace App.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using App.Enums;

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
        this.User = user;

        this.CalculateTotal();
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
