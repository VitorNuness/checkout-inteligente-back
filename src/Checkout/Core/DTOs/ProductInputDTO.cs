using System;

namespace Core.DTOs;

public class ProductInputDTO
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }

    public ProductInputDTO(
        string name,
        double quantity,
        double price,
        int categoryId
    )
    {
        this.Name = name;
        this.Quantity = quantity;
        this.Price = price;
        this.CategoryId = categoryId;
    }
}
