namespace App.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Image
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public int? ProductId { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; }
    public string FileName { get; set; }
    public string Path { get; set; }

    public Image(Product? product, int? productId, string fileName, string path)
    {
        this.Product = product;
        this.ProductId = productId;
        this.FileName = fileName;
        this.Path = path;
    }

    private Image() { }
}
