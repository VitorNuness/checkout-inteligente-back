using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services.Interfaces;

namespace App.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            return new List<Product>();
        }
        public Product? GetById(int id, string? sort = null)
        {
            return null;
        }
        public void Create(Product data)
        {
            return;
        }

        public void Update(int id, Product data)
        {
            return;
        }

        public void Delete(int id)
        {
            return;
        }
    }
}
