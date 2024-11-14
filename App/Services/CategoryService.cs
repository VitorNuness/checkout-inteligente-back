namespace App.Services;

using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _environment;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IFileService fileService,
        IWebHostEnvironment environment
    )
    {
        this._categoryRepository = categoryRepository;
        this._fileService = fileService;
        this._environment = environment;
    }

    public async Task<IEnumerable<Category?>> GetAll() => await this._categoryRepository.GetAll();

    public async Task<Category> GetById(int id) => await this._categoryRepository.FindOrFail(id);

    public async Task<Category> Create(CategoryInputDTO categoryInputDTO, IFormFile? image)
    {
        Category category = new(categoryInputDTO.Name);

        await this._categoryRepository.Store(category);
        await this.Update(category.Id, categoryInputDTO, image);

        return category;
    }

    public async Task<Category> Update(int id, CategoryInputDTO categoryInputDTO, IFormFile? image)
    {
        var oldCategory = await this.GetById(id);

        Category newCategory = new(categoryInputDTO.Name)
        {
            Id = oldCategory.Id,
            ImageUrl = oldCategory.ImageUrl,
        };

        if (image?.Length > 0)
        {
            var path = this.GetCategoryImagesPath(newCategory.Id);
            await this._fileService.SaveFile(image, path);

            newCategory.ImageUrl = GetCategoryImagesUrl(newCategory.Id);
        }

        return await this._categoryRepository.Update(oldCategory, newCategory);
    }

    public async Task Delete(int id)
    {
        var category = await this.GetById(id);
        await this._categoryRepository.Delete(category);

        if (category.ImageUrl != GetCategoryImagesUrl(0))
        {
            await this._fileService.RemoveFile(this.GetCategoryImagesPath(id));
        }
    }

    private string GetCategoryImagesPath(int id) => Path.Combine(this._environment.WebRootPath, "files/images/categories", id.ToString() + ".png");

    private static string GetCategoryImagesUrl(int id) => "http://localhost:5102/files/images/categories/" + id.ToString() + ".png";

}
