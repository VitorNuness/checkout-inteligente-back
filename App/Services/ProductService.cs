using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(
            ProductRepository productRepository
        )
        {
            _productRepository = productRepository;
        }

        public List<Product>? GetAll(int? category = null, string? sort = null)
        {
            List<Product>? products = _productRepository.GetAll(category);

            if (products != null && sort == "popularity")
            {
                products = products.OrderByDescending(p => p.Views).ToList();
            }

            return products;
        }

        public Product? GetById(int id)
        {
            return _productRepository.Get(id);
        }

        public void Create(Product data)
        {
            _productRepository.Store(data);
        }

        public void Update(int id, Product data)
        {
            _productRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public void AddView(int id)
        {
            Product? product = this.GetById(id);
            if (product != null)
            {
                product.Views++;
                this.Update(id, product);
            }
        }
    }
}
