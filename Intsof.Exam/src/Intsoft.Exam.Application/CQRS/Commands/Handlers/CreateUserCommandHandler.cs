﻿using Intsoft.Application.CQRS.Commands.Requests;
using Intsoft.Application.CQRS.Commands.Responses;
using Intsoft.Domain.Repositories;
using Intsoft.Domain.ValueObjects;
using MediatR;

namespace Intsoft.Application.CQRS.Commands.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                throw new Exception("First Name is required. Please Enter First Name.");
            }

            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new Exception("Last Name is required. Please Enter Last Name.");
            }

            ulong nationalcode = ValidateNationalCode(request.NationalCode);
            ulong phoneNumber = ValidatePhoneNumber(request.PhoneNumber);

            await _userRepository.AddUserAsync(new Domain.Entities.User
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = nationalcode,
                PhoneNumber = phoneNumber,
            });

            return new CreateUserResponse();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private ulong ValidatePhoneNumber(ulong phoneNumber)
    {
        PhoneNumber phone = new PhoneNumber(phoneNumber);
        return phone.Value;
    }

    private ulong ValidateNationalCode(ulong nationalCode)
    {
        NationalCode nationalCodeValueObject = new NationalCode(nationalCode);
        return nationalCodeValueObject.Value;
    }
}
