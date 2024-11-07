namespace App.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
        this.Product = product;
        this.Order = order;
        this.Quantity = quantity;

        this.CalculateTotal();
    }

    private OrderItem() { }

    public void AddQuantity()
    {
        this.Quantity++;
        this.CalculateTotal();
    }

    public void RemoveQuantity()
    {
        this.Quantity--;
        this.CalculateTotal();
    }

    private void CalculateTotal() => this.Total = this.Product.Price * this.Quantity;
}
