using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Entities;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler (IUserRepository userRepository, IUnitOfWork unitOfWork, IValidator<RegisterUserCommand> validator)
    : IRequestHandler<RegisterUserCommand, Result>
{
    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            return Result.Failure(errorMessages, ErrorType.Validation);
        }
        
        var existingUser = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        
        if (existingUser != null)
        {
            return Result.Failure("Email is already in use.", ErrorType.Conflict);
        }
        
        var user = new User(
            request.FullName,
            request.Email,
            request.PhoneNumber,
            Role.User
        );
        
        user.SetPassword(request.Password);
        
        await userRepository.AddAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}