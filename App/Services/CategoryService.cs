using App.DTOs;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(
            CategoryRepository categoryRepository
        )
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category?>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.FindOrFail(id);
        }

        public async Task<Category> Create(CategoryInputDTO categoryInputDTO)
        {
            Category category = new(categoryInputDTO.Name);

            return await _categoryRepository.Store(category);
        }

        public async Task Update(int id, Category data)
        {
            await _categoryRepository.Update(id, data);
        }

        public async Task Delete(int id)
        {
            Category category = await GetById(id);
            await _categoryRepository.Delete(category);
        }
    }
}
