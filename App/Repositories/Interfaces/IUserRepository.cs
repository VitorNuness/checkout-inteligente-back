using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User Get(int id);
        public void Store(User data);
        public void Update(int id, User data);
        public void Delete(int id);
    }
}
