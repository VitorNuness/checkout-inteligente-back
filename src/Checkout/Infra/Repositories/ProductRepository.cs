namespace Infra.Repositories;

using Core.Models;
using Core.Repositories;
using Infra.Repositories.Database;
using Microsoft.EntityFrameworkCore;

public class ProductRepository(CheckoutDbContext dbContext) : IProductRepository
{
    private readonly CheckoutDbContext _dbContext = dbContext;

    public async Task<IList<Product>> GetAll() => await this._dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Campaigns)
            .ToListAsync();

    public async Task<IList<Product>> GetBestSellers() => await this._dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Campaigns)
            .OrderByDescending(p => p.Sales)
            .Take(15)
            .ToListAsync();

    public async Task<IList<Product>> GetWhereIdsOrFail(List<int?> productsIds) => await this._dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Campaigns)
            .Where((p) => productsIds.Contains(p.Id))
            .ToListAsync();

    public async Task<Product> FindOrFail(int id) => await this._dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Campaigns)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync() ??
            throw new Exception("Product not exist.");

    public async Task<Product> Store(Product product)
    {
        this._dbContext.Products.Add(product);
        await this._dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Update(Product oldProduct, Product newProduct)
    {
        oldProduct.Category = newProduct.Category;
        this._dbContext.Entry(oldProduct).CurrentValues.SetValues(newProduct);

        await this._dbContext.SaveChangesAsync();

        return newProduct;
    }

    public async Task Delete(Product product)
    {
        this._dbContext.Remove(product);

        await this._dbContext.SaveChangesAsync();
    }
}
