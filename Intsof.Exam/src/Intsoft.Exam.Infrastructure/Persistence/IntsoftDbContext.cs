using Intsoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Intsoft.Infrastructure.Persistence;

public class IntsoftDbContext : DbContext, IIntsoftDbContext
{
    public DbSet<User> Users { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public IntsoftDbContext(DbContextOptions<IntsoftDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
