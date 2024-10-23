using App.DTOs;
using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class UserRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public UserRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User?>> GetAll() => await _dbContext.Users.ToListAsync();

        public async Task<User> FindOrFail(int id) => await _dbContext.Users.FindAsync(id) ?? throw new Exception("User not found.");

        public async Task<User> FindByCredentialsOrFail(UserCredentialsDTO userCredentialsDTO) => await _dbContext.Users.Where(
                u => u.Email == userCredentialsDTO.Email && u.Password == userCredentialsDTO.Password
            ).FirstOrDefaultAsync() ?? throw new Exception("This credentials not match with our records.");

        public async Task<User> Store(UserInputDTO userInputDTO)
        {
            User user = new(
                userInputDTO.Name,
                userInputDTO.Email,
                userInputDTO.Password
            );

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
