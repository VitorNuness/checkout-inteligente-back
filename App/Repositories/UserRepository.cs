namespace App.Repositories;

using App.Repositories.Database;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly CheckoutDbContext _dbContext;

    public UserRepository(CheckoutDbContext dbContext) => this._dbContext = dbContext;

    public async Task<IEnumerable<User?>> GetAll() => await this._dbContext.Users.ToListAsync();

    public async Task<User> FindOrFail(int id) => await this._dbContext.Users.FindAsync(id) ?? throw new Exception("User not found.");

    public async Task<User> FindByCredentialsOrFail(UserCredentialsDTO userCredentialsDTO) => await this._dbContext.Users.Where(
            u => u.Email == userCredentialsDTO.Email && u.Password == userCredentialsDTO.Password
        ).FirstOrDefaultAsync() ?? throw new Exception("This credentials not match with our records.");

    public async Task<User> Store(UserInputDTO userInputDTO)
    {
        User user = new(
            userInputDTO.Name,
            userInputDTO.Email,
            userInputDTO.Password
        );

        this._dbContext.Users.Add(user);
        await this._dbContext.SaveChangesAsync();

        return user;
    }

    public async Task Update(int id, User data)
    {
        var user = await this.FindOrFail(id);
        if (user != null)
        {
            user.Id = id;
            this._dbContext.Entry(user).CurrentValues.SetValues(data);
        }

        await this._dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await this.FindOrFail(id);
        if (user != null)
        {
            this._dbContext.Remove(user);
        }
        await this._dbContext.SaveChangesAsync();
    }
}
