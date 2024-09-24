using App.DTOs;
using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CategoryRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public CategoryRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category?>> GetAll()
        {
            return await _dbContext.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> FindOrFail(int id)
        {
            return await _dbContext.Categories.Include(c => c.Products).Where(p => p.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Category not exist.");
        }

        public async Task<Category> Store(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Update(int id, Category newCategory)
        {
            Category category = await FindOrFail(id);

            newCategory.Id = category.Id;
            _dbContext.Entry(category).CurrentValues.SetValues(newCategory);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task Delete(Category category)
        {
            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
        }
    }
}
