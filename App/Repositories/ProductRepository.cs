using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using App.Repositories.Interfaces;

namespace App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CheckoutDbContext DbContext;

        public ProductRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Product> GetAll()
        {
            return this.DbContext.Products.ToList();
        }

        public Product Get(int id)
        {
            return this.DbContext.Products.Where(p => p.Id == id).First();
        }

        public void Store(Product data)
        {
            this.DbContext.Products.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, Product data)
        {
            Product product = this.Get(id);
            product = data;
            this.DbContext.Products.Update(product);
            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.DbContext.Products.Remove(this.Get(id));
            this.DbContext.SaveChanges();
        }

    }
}
