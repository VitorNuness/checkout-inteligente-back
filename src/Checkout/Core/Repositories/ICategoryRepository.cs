namespace Core.Repositories;

using Core.Models;

public interface ICategoryRepository
{
    public Task<List<Category?>> GetAll();
    public Task<Category> FindOrFail(int id);
    public Task<Category> Store(Category category);
    public Task<Category> Update(Category oldCategory, Category newCategory);
    public Task Delete(Category category);
}
