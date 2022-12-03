using Intsoft.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Intsoft.Exam.IntegrationTests.Infrastructure;

public class IntsoftWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                return new DbContextOptionsBuilder<IntsoftDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString(), root)
                .UseApplicationServiceProvider(sp).Options;
            });
        });

        return base.CreateHost(builder);
    }
}
