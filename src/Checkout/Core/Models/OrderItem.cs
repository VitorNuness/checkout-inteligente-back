namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public double Total { get; private set; }
    public double Quantity { get; set; } = 1;
    public Order Order { get; set; }
    public Product Product { get; set; }

    public OrderItem(
        Product product,
        Order order
    )
    {
        this.Product = product;
        this.Order = order;

        this.CalculateTotal();
    }

    public OrderItem(
        int id,
        double quantity,
        double total,
        Order order,
        Product product
    )
    {
        this.Id = id;
        this.Quantity = quantity;
        this.Total = total;
        this.Order = order;
        this.Product = product;
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

    public void CalculateTotal() => this.Total = this.Product.Price * this.Quantity;
}
