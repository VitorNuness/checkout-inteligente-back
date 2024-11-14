namespace App.Repositories;

using App.Repositories.Database;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly CheckoutDbContext _dbContext;

    public CategoryRepository(CheckoutDbContext checkoutDbContext) => this._dbContext = checkoutDbContext;

    public async Task<IList<Category?>> GetAll() => await this._dbContext.Categories
        .Include(c => c.Products)
        .ToListAsync();

    public async Task<Category> FindOrFail(int id) => await this._dbContext.Categories
        .Include(c => c.Products)
        .Where(p => p.Id == id)
        .FirstOrDefaultAsync() ??
        throw new Exception("Category not exist.");

    public async Task<Category> Store(Category category)
    {
        this._dbContext.Categories.Add(category);
        await this._dbContext.SaveChangesAsync();

        return category;
    }

    public async Task<Category> Update(Category oldCategory, Category newCategory)
    {
        newCategory.Id = oldCategory.Id;
        this._dbContext.Entry(oldCategory).CurrentValues.SetValues(newCategory);
        await this._dbContext.SaveChangesAsync();

        return newCategory;
    }

    public async Task Delete(Category category)
    {
        this._dbContext.Categories.Remove(category);

        await this._dbContext.SaveChangesAsync();
    }
}
