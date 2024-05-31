using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category? GetById(int id, string? sort);
        public void Create(Category data);
        public void Update(int id, Category data);
        public void Delete(int id);
    }
}
