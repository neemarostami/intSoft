using Intsoft.Application.CQRS.Queries.Requests;
using Intsoft.Application.CQRS.Queries.Responses;
using Intsoft.Domain.Repositories;
using MediatR;

namespace Intsoft.Application.CQRS.Queries.Handlers;

public class GetSingleUserQueryHandler : IRequestHandler<GetSingleUserRequest, GetSingleUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetSingleUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetSingleUserResponse> Handle(GetSingleUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _userRepository.GetUserById(request.UserId);

            if(response == null)
            {
                throw new Exception("User not found.");
            }

            return new GetSingleUserResponse
            {
                UserId = response.UserId,
                FirstName = response.FirstName,
                LastName = response.LastName,
                NationalCode = response.NationalCode,
                PhoneNumber = response.PhoneNumber,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
