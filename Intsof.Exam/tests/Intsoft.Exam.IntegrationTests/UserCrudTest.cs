using Intsoft.Application.CQRS.Commands.Requests;
using Intsoft.Exam.API;
using Intsoft.Exam.IntegrationTests.Infrastructure;
using Intsoft.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;

namespace Intsoft.Exam.IntegrationTests;

public class UserCrudTest : IClassFixture<IntsoftWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly IntsoftDbContext _context;

    public UserCrudTest(IntsoftWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
        _context = factory.Services.CreateScope().ServiceProvider.GetRequiredService<IntsoftDbContext>();
    }

    [Fact]
    public async Task AddUserShouldResponseSuccessCode()
    {
        CreateUserRequest request = new()
        {
            UserId = 1,
            FirstName = "Nima",
            LastName = "Rostami",
            NationalCode = 1360300716,
            PhoneNumber = 9141197322,
        };

        string json = JsonConvert.SerializeObject(request);
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(Route.CREATE_FULLPATH, httpContent);
        var code = response.StatusCode;

        Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.OK, code);
    }

    [Fact]
    public async Task AddUserShouldResponseFailedCode()
    {
        CreateUserRequest request = new()
        {
            UserId = 1,
            FirstName = "Nima",
            LastName = "",
            NationalCode = 1360300716,
            PhoneNumber = 9141197322,
        };

        string json = JsonConvert.SerializeObject(request);
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(Route.CREATE_FULLPATH, httpContent);
        var code = response.StatusCode;

        Assert.Equal(HttpStatusCode.InternalServerError, code);
    }
}