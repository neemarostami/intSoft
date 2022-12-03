using Intsoft.Application.CQRS.Queries.Responses;
using MediatR;

namespace Intsoft.Application.CQRS.Queries.Requests;

public class GetSingleUserRequest : IRequest<GetSingleUserResponse>
{
    public int UserId { get; set; }
}
