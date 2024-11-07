namespace App.Repositories.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IProductRepository
{
    public List<Product> GetAll(int? category = null);
    public Product Get(int id);
    public void Store(Product data);
    public void Update(int id, Product data);
    public void Delete(int id);
}
