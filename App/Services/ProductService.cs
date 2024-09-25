using App.DTOs;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryService _categoryService;
        private readonly FileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public ProductService(
            ProductRepository productRepository,
            CategoryService categoryService,
            FileService fileService,
            IWebHostEnvironment environment
        )
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _fileService = fileService;
            _environment = environment;
        }

        public async Task<IEnumerable<Product?>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetWhereIds(List<int> productIds)
        {
            return await _productRepository.GetWhereIdsOrFail(productIds);
        }

        public async Task<IEnumerable<Product>> GetBestSellers()
        {
            return await _productRepository.GetBestSellers();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.FindOrFail(id);
        }

        public async Task<Product> Create(ProductInputDTO productInputDTO, IFormFile? image)
        {
            Category category = await _categoryService.GetById(productInputDTO.CategoryId);

            Product product = new(
                productInputDTO.Name,
                category,
                productInputDTO.Quantity,
                productInputDTO.Price
            );

            await _productRepository.Store(product);

            if (image?.Length > 0)
            {
                string path = GetProductImagesPath(product.Id);
                await _fileService.SaveFile(image, path);

                product.ImageUrl = GetProductImagesUrl(product.Id);
                await _productRepository.Update(product, product);
            }

            return product;
        }

        public async Task<Product> Update(int id, ProductInputDTO productInputDTO, IFormFile? image)
        {
            Category category = await _categoryService.GetById(productInputDTO.CategoryId);

            Product oldProduct = await _productRepository.FindOrFail(id);

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
                string path = GetProductImagesPath(product.Id);
                await _fileService.SaveFile(image, path);

                product.ImageUrl = GetProductImagesUrl(product.Id);
            }

            return await _productRepository.Update(oldProduct, product);
        }

        public async Task Delete(int id)
        {
            Product product = await GetById(id);
            await _productRepository.Delete(product);

            if (product.ImageUrl != GetProductImagesUrl(0))
            {
                await _fileService.RemoveFile(GetProductImagesPath(id));
            }
        }

        private string GetProductImagesPath(int id) => Path.Combine(_environment.WebRootPath, "files/images/products", id.ToString() + ".png");

        private string GetProductImagesUrl(int id) => "http://localhost:5102/files/images/products/" + id.ToString() + ".png";
    }
}
