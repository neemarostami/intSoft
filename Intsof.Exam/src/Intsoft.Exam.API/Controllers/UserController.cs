using Intsoft.Application.CQRS.Commands.Requests;
using Intsoft.Application.CQRS.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intsoft.Exam.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Route.CREATE)]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut(Route.UPDATE)]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet(Route.GET)]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(await _mediator.Send(new GetSingleUserRequest { UserId = id }));
    }
}
