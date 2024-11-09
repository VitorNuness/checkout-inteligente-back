using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product?> Products { get; set; } = [];
    public string ImageUrl { get; set; } = "http://localhost:5102/files/images/categories/0.png";

    public Category(
        string name,
        string imageUrl
    )
    {
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public Category(string name) => this.Name = name;

    public Category(
        int id,
        string name,
        string imageUrl
    )
    {
        this.Id = id;
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    private Category() { }
}
