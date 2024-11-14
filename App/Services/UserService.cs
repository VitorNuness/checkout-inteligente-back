namespace App.Services;

using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => this._userRepository = userRepository;

    public async Task<IEnumerable<User?>> GetAll() => await this._userRepository.GetAll();

    public async Task<User> Get(int id) => await this._userRepository.FindOrFail(id);

    public async Task<User> GetByCredentials(UserCredentialsDTO userCredentialsDTO) => await this._userRepository.FindByCredentialsOrFail(userCredentialsDTO);

    public async Task<User> Create(UserInputDTO userInputDTO) => await this._userRepository.Store(userInputDTO);

    public async Task Update(int id, User data) => await this._userRepository.Update(id, data);

    public async Task Delete(int id) => await this._userRepository.Delete(id);
}
