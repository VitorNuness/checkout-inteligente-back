using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Models;

namespace App.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product Get(int id);
        public void Store(Product data);
        public void Update(int id, Product data);
        public void Delete(int id);
    }
}
