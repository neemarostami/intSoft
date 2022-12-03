using Intsoft.Domain.Entities;
using Intsoft.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Intsoft.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IntsoftDbContext _context;

    public UserRepository(IntsoftDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task UpdateUserAsync(User user)
    {
        User userObj = await _context.Users.FirstAsync(u => u.UserId == user.UserId);

        userObj.FirstName = user.FirstName;
        userObj.LastName = user.LastName;
        userObj.NationalCode = user.NationalCode;
        userObj.PhoneNumber = user.PhoneNumber;

        _context.Users.Update(userObj);
        await _context.SaveChangesAsync();
    }
}
