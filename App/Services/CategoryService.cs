using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(
            CategoryRepository categoryRepository
        )
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category? GetById(int id, string? sort)
        {
            Category? category = _categoryRepository.Get(id);

            if (category == null)
            {
                return category;
            }

            if (sort == "trend")
            {
                if (category.Products != null)
                {
                    category.Products = category.Products.OrderByDescending(p => p.Views).ToList();
                }
            }

            return category;
        }

        public void Create(Category data)
        {
            _categoryRepository.Store(data);
        }

        public void Update(int id, Category data)
        {
            _categoryRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
