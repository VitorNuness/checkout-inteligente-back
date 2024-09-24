using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class ProductRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public ProductRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product?>> GetAll()
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> FindOrFail(int id)
        {
            return await _dbContext.Products.Include(p => p.Category).Where(p => p.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Product not exist.");
        }

        public async Task<Product> Store(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product oldProduct, Product newProduct)
        {
            oldProduct.Category = newProduct.Category;
            _dbContext.Entry(oldProduct).CurrentValues.SetValues(newProduct);

            await _dbContext.SaveChangesAsync();

            return newProduct;
        }

        public async Task Delete(Product product)
        {
            _dbContext.Remove(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}
