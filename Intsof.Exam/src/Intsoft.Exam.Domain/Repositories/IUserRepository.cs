using Intsoft.Domain.Entities;

namespace Intsoft.Domain.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task<User?> GetUserById(int id);
}
