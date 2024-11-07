namespace App.Repositories.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface ICategoryRepository
{
    public List<Category> GetAll();
    public Category? Get(int id);
    public void Store(Category data);
    public void Update(int id, Category data);
    public void Delete(int id);
}
