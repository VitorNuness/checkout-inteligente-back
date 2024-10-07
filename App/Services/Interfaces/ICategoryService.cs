namespace App.Services.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface ICategoryService
{
    public List<Category> GetAll();
    public Category? GetById(int id, string? sort);
    public void Create(Category data);
    public void Update(int id, Category data);
    public void Delete(int id);
}
