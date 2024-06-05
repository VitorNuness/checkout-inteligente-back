using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CheckoutDbContext DbContext;

        public ProductRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Product> GetAll(int? category = null)
        {
            if (category == null)
            {
                return this.DbContext.Products.Include(p => p.Category).ToList();
            }
            return this.DbContext.Products.Include(p => p.Category).Where(p => p.CategoryId == category).ToList();
        }

        public Product Get(int id)
        {
            return this.DbContext.Products.Where(p => p.Id == id).First();
        }

        public void Store(Product data)
        {
            Category? category = this.DbContext.Categories.FirstOrDefault(c => c.Id == data.CategoryId);

            if (category != null)
            {
                data.Category = category;
                this.DbContext.Products.Add(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Update(int id, Product data)
        {
            Product product = this.Get(id);
            if (product != null)
            {
                product.Id = id;
                this.DbContext.Entry(product).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.DbContext.Products.Remove(this.Get(id));
            this.DbContext.SaveChanges();
        }

    }
}
