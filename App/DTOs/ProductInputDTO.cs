namespace App.DTOs;

using System.Text.Json.Serialization;

public class ProductInputDTO
{
    public string? Name { get; set; }
    [JsonRequired] public double Quantity { get; set; }
    [JsonRequired] public double Price { get; set; }
    public int CategoryId { get; set; }
}
