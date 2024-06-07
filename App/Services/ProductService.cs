using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository Repository;

        public ProductService()
        {
            this.Repository = new ProductRepository();
        }

        public List<Product>? GetAll(int? category = null, string? sort = null)
        {
            List<Product>? products = this.Repository.GetAll(category);

            if (products != null && sort == "popularity")
            {
                products = products.OrderByDescending(p => p.Views).ToList();
            }

            return products;
        }

        public Product? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public void Create(Product data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Product data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
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
