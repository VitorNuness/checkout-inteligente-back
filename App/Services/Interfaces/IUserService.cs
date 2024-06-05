using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User? GetById(int id);
        public void Create(User data);
        public void Update(int id, User data);
        public void Delete(int id);
    }
}
