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

        public Category? Get(int id)
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
            Category? category = this.Get(id);
            if (category != null)
            {
                category.Id = id;
                this.DbContext.Entry(category).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Category? category = this.Get(id);
            if (category != null)
            {
                category.Id = id;
                this.DbContext.Categories.Remove(category);
            }

            this.DbContext.SaveChanges();
        }
    }
}
