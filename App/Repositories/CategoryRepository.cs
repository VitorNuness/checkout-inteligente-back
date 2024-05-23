using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using App.Repositories.Interfaces;

namespace App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CheckoutDbContext DbContext;

        public CategoryRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Category> GetAll()
        {
            return this.DbContext.Categories.ToList();
        }

        public Category Get(int id)
        {
            return this.DbContext.Categories.Where(c => c.Id == id).First();
        }

        public void Store(Category data)
        {
            this.DbContext.Categories.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, Category data)
        {
            Category category = this.Get(id);
            this.DbContext.Categories.Update(category);
            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.DbContext.Categories.Remove(this.Get(id));
            this.DbContext.SaveChanges();
        }
    }
}
