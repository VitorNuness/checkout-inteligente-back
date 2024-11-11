namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public int Sales { get; set; }
    public string ImageUrl { get; set; } = "http://localhost:5102/files/images/products/0.png";
    public Category Category { get; set; }
    public List<Campaign> Campaigns { get; set; } = [];

    public Product(
        string name,
        int quantity,
        double price,
        Category category,
        string imageUrl
    )
    {
        this.Name = name;
        this.Quantity = quantity;
        this.Price = price;
        this.Category = category;
        this.ImageUrl = imageUrl;
    }

    public Product(
        string name,
        int quantity,
        double price,
        Category category
    )
    {
        this.Name = name;
        this.Quantity = quantity;
        this.Price = price;
        this.Category = category;
    }

    public Product(
        int id,
        string name,
        int quantity,
        double price,
        Category category,
        int sales,
        string imageUrl
    )
    {
        this.Id = id;
        this.Name = name;
        this.Quantity = quantity;
        this.Price = price;
        this.Category = category;
        this.Sales = sales;
        this.ImageUrl = imageUrl;
    }

    private Product() { }

    public void AddSale() => this.Sales++;
}
