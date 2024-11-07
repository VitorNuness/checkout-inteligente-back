namespace App.Services.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IProductService
{
    public List<Product>? GetAll(int? category = null, string? sort = null);
    public Product? GetById(int id);
    public void Create(Product data);
    public void Update(int id, Product data);
    public void Delete(int id);
}
