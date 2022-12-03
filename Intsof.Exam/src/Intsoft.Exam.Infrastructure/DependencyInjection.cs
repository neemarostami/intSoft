using Intsoft.Domain.Repositories;
using Intsoft.Infrastructure.Persistence;
using Intsoft.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intsoft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IntsoftDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"), builder =>
        builder.MigrationsAssembly(typeof(IntsoftDbContext).Assembly.FullName)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IIntsoftDbContext, IntsoftDbContext>();

        return services;
    }
}
