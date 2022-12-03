using Intsoft.Application.CQRS.Commands.Handlers;
using Intsoft.Application.CQRS.Queries.Handlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intsoft.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
        services.AddMediatR(typeof(UpdateUserCommandHandler).Assembly);
        services.AddMediatR(typeof(GetSingleUserQueryHandler).Assembly);

        return services;
    }
}
