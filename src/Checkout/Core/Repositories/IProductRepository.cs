namespace Core.Repositories;

using Core.Models;

public interface IProductRepository
{
    public Task<IEnumerable<Product?>> GetAll();

    public Task<IEnumerable<Product>> GetBestSellers();

    public Task<IEnumerable<Product>> GetWhereIdsOrFail(List<int> productsIds);

    public Task<Product> FindOrFail(int id);

    public Task<Product> Store(Product product);

    public Task<Product> Update(Product oldProduct, Product newProduct);

    public Task Delete(Product product);
}
