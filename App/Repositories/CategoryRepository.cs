using App.Models;
using App.Repositories.Database;
using App.Repositories.Interfaces;

namespace App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public CategoryRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category? Get(int id)
        {
            return _dbContext.Categories.Where(c => c.Id == id).First();
        }

        public void Store(Category data)
        {
            _dbContext.Categories.Add(data);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Category data)
        {
            Category? category = this.Get(id);
            if (category != null)
            {
                category.Id = id;
                _dbContext.Entry(category).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Category? category = this.Get(id);
            if (category != null)
            {
                category.Id = id;
                _dbContext.Categories.Remove(category);
            }

            _dbContext.SaveChanges();
        }
    }
}
