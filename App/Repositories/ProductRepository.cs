using App.Models;
using App.Repositories.Database;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public ProductRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAll(int? category = null)
        {
            if (category == null)
            {
                return _dbContext.Products.Include(p => p.Category).Include(p => p.Image).ToList();
            }
            return _dbContext.Products.Include(p => p.Category).Where(p => p.CategoryId == category).ToList();
        }

        public Product Get(int id)
        {
            return _dbContext.Products.Where(p => p.Id == id).Include(p => p.Category).Include(p => p.Image).First();
        }

        public void Store(Product data)
        {
            Category? category = _dbContext.Categories.FirstOrDefault(c => c.Id == data.CategoryId);

            if (category != null)
            {
                data.Category = category;
                _dbContext.Products.Add(data);
            }

            _dbContext.SaveChanges();
        }

        public void Update(int id, Product data)
        {
            Product product = this.Get(id);
            if (product != null)
            {
                product.Id = id;
                _dbContext.Entry(product).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Products.Remove(this.Get(id));
            _dbContext.SaveChanges();
        }
    }
}
