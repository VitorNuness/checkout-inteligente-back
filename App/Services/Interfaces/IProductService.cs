using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product? GetById(int id, string? sort = null);
        public void Create(Product data);
        public void Update(int id, Product data);
        public void Delete(int id);
    }
}
