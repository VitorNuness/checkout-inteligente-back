namespace App.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string? ImageUrl { get; set; } = "http://localhost:5102/files/images/products/0.png";
    public int Sales { get; private set; }
    public required Category Category { get; set; }
    public List<Campaign?> Campaigns { get; set; } = [];

    [SetsRequiredMembers]
    public Product(
        string name,
        Category category,
        double quantity = 0,
        double price = 0
    )
    {
        this.Name = name;
        this.Category = category;
        this.Quantity = quantity;
        this.Price = price;
    }

    private Product() { }

    public void AddSale() => this.Sales++;
}
