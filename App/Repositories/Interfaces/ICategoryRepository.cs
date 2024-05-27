using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Models;

namespace App.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category? Get(int id);
        public void Store(Category data);
        public void Update(int id, Category data);
        public void Delete(int id);
    }
}
