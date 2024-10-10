namespace App.Services;

using App.DTOs;
using App.Models;
using App.Repositories;

public class UserService(
    UserRepository userRepository
    )
{
    private readonly UserRepository _userRepository = userRepository;

    public async Task<IEnumerable<User?>> GetAll() => await this._userRepository.GetAll();

    public async Task<User> Get(int id) => await this._userRepository.FindOrFail(id);

    public async Task<User> GetByCredentials(UserCredentialsDTO userCredentialsDTO) => await this._userRepository.FindByCredentialsOrFail(userCredentialsDTO);

    public async Task<User> Create(UserInputDTO userInputDTO) => await this._userRepository.Store(userInputDTO);

    public async Task Update(int id, User data) => await this._userRepository.Update(id, data);

    public async Task Delete(int id) => await this._userRepository.Delete(id);
}
