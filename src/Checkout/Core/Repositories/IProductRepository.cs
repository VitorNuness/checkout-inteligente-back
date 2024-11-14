namespace Core.Repositories;

using Core.Models;

public interface IProductRepository
{
    public Task<IList<Product?>> GetAll();

    public Task<IList<Product>> GetBestSellers();

    public Task<IList<Product>> GetWhereIdsOrFail(List<int?> productsIds);

    public Task<Product> FindOrFail(int id);

    public Task<Product> Store(Product product);

    public Task<Product> Update(Product oldProduct, Product newProduct);

    public Task Delete(Product product);
}
