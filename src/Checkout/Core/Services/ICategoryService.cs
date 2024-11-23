namespace Core.Services;

using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Http;

public interface ICategoryService
{
    public Task<IEnumerable<Category?>> GetAll();

    public Task<Category> GetById(int id);

    public Task<Category> Create(CategoryInputDTO categoryInputDTO, IFormFile? image);

    public Task<Category> Update(int id, CategoryInputDTO categoryInputDTO, IFormFile? image);

    public Task Delete(int id);
}
