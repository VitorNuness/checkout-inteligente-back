namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Campaign
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Active { get; set; } = true;
    public string ImageUrl { get; set; } = "http://localhost:5102/files/images/campaigns/0.png";
    public List<Product> Products { get; set; } = [];

    public Campaign(
        string title
    )
    {
        this.Title = title;
    }

    public Campaign(
        string title,
        string imageUrl
    )
    {
        this.Title = title;
        this.ImageUrl = imageUrl;
    }

    public Campaign(
        int id,
        string title,
        bool active,
        string imageUrl,
        List<Product> products
    )
    {
        this.Id = id;
        this.Title = title;
        this.Active = active;
        this.ImageUrl = imageUrl;
        this.Products = products;
    }

    private Campaign() { }
}
