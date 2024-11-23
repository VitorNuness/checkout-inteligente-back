namespace Core.Services;

using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Http;

public interface IProductService
{
    public Task<IList<Product?>> GetAll();

    public Task<IList<Product>> GetWhereIds(List<int?> productIds);

    public Task<IList<Product>> GetBestSellers();

    public Task<Product> GetById(int id);

    public Task<Product> Create(ProductInputDTO productInputDTO, IFormFile? image);

    public Task<Product> Update(int id, ProductInputDTO productInputDTO, IFormFile? image);

    public Task Delete(int id);
}
