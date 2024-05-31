using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository Repository;

        public CategoryService()
        {
            this.Repository = new CategoryRepository();
        }

        public List<Category> GetAll()
        {
            return this.Repository.GetAll();
        }

        public Category? GetById(int id, string? sort)
        {
            Category? category = this.Repository.Get(id);

            if (category == null)
            {
                return category;
            }

            if (sort == "trend")
            {
                if (category.Products != null)
                {
                    category.Products = category.Products.OrderByDescending(p => p.Views).ToList();
                }
            }

            return category;
        }

        public void Create(Category data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Category data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}
