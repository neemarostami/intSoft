using Intsoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intsoft.Infrastructure.Persistence;

public interface IIntsoftDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync();
}
