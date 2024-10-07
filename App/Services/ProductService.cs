namespace App.Services;

using App.DTOs;
using App.Models;
using App.Repositories;

public class ProductService(
    ProductRepository productRepository,
    CategoryService categoryService,
    FileService fileService,
    IWebHostEnvironment environment
    )
{
    private readonly ProductRepository _productRepository = productRepository;
    private readonly CategoryService _categoryService = categoryService;
    private readonly FileService _fileService = fileService;
    private readonly IWebHostEnvironment _environment = environment;

    public async Task<IEnumerable<Product?>> GetAll() => await this._productRepository.GetAll();

    public async Task<IEnumerable<Product>> GetWhereIds(List<int> productIds) => await this._productRepository.GetWhereIdsOrFail(productIds);

    public async Task<IEnumerable<Product>> GetBestSellers() => await this._productRepository.GetBestSellers();

    public async Task<Product> GetById(int id) => await this._productRepository.FindOrFail(id);

    public async Task<Product> Create(ProductInputDTO productInputDTO, IFormFile? image)
    {
        var category = await this._categoryService.GetById(productInputDTO.CategoryId);

        Product product = new(
            productInputDTO.Name,
            category,
            productInputDTO.Quantity,
            productInputDTO.Price
        );

        await this._productRepository.Store(product);

        await this.Update(product.Id, productInputDTO, image);

        return product;
    }

    public async Task<Product> Update(int id, ProductInputDTO productInputDTO, IFormFile? image)
    {
        var category = await this._categoryService.GetById(productInputDTO.CategoryId);

        var oldProduct = await this._productRepository.FindOrFail(id);

        Product product = new(
            productInputDTO.Name,
            category,
            productInputDTO.Quantity,
            productInputDTO.Price
        )
        {
            Id = oldProduct.Id,
            ImageUrl = oldProduct.ImageUrl
        };

        if (image?.Length > 0)
        {
            var path = this.GetProductImagesPath(product.Id);
            await this._fileService.SaveFile(image, path);

            product.ImageUrl = GetProductImagesUrl(product.Id);
        }

        return await this._productRepository.Update(oldProduct, product);
    }

    public async Task Delete(int id)
    {
        var product = await this.GetById(id);
        await this._productRepository.Delete(product);

        if (product.ImageUrl != GetProductImagesUrl(0))
        {
            await this._fileService.RemoveFile(this.GetProductImagesPath(id));
        }
    }

    private string GetProductImagesPath(int id) => Path.Combine(this._environment.WebRootPath, "files/images/products", id.ToString() + ".png");

    private static string GetProductImagesUrl(int id) => "http://localhost:5102/files/images/products/" + id.ToString() + ".png";
}
