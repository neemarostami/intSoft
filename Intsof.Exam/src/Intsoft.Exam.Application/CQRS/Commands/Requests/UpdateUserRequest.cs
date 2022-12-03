using Intsoft.Application.CQRS.Commands.Responses;
using MediatR;

namespace Intsoft.Application.CQRS.Commands.Requests;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ulong NationalCode { get; set; }
    public ulong PhoneNumber { get; set; }
}
