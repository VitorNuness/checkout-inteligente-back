using App.DTOs;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly FileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public CategoryService(
            CategoryRepository categoryRepository,
            FileService fileService,
            IWebHostEnvironment environment
        )
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _environment = environment;
        }

        public async Task<IEnumerable<Category?>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.FindOrFail(id);
        }

        public async Task<Category> Create(CategoryInputDTO categoryInputDTO, IFormFile? image)
        {
            Category category = new(categoryInputDTO.Name);

            await _categoryRepository.Store(category);
            await Update(category.Id, categoryInputDTO, image);

            return category;
        }

        public async Task<Category> Update(int id, CategoryInputDTO categoryInputDTO, IFormFile? image)
        {
            Category oldCategory = await GetById(id);

            Category newCategory = new(categoryInputDTO.Name)
            {
                Id = oldCategory.Id,
                ImageUrl = oldCategory.ImageUrl,
            };

            if (image?.Length > 0)
            {
                string path = GetCategoryImagesPath(newCategory.Id);
                await _fileService.SaveFile(image, path);

                newCategory.ImageUrl = GetCategoryImagesUrl(newCategory.Id);
            }

            return await _categoryRepository.Update(oldCategory, newCategory);
        }

        public async Task Delete(int id)
        {
            Category category = await GetById(id);
            await _categoryRepository.Delete(category);

            if (category.ImageUrl != GetCategoryImagesUrl(0))
            {
                await _fileService.RemoveFile(GetCategoryImagesPath(id));
            }
        }

        private string GetCategoryImagesPath(int id) => Path.Combine(_environment.WebRootPath, "files/images/categories", id.ToString() + ".png");

        private string GetCategoryImagesUrl(int id) => "http://localhost:5102/files/images/categories/" + id.ToString() + ".png";

    }
}
