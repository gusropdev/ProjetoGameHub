using FluentValidation;
using GameHub.Application.Common.Interfaces;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommandHandler (IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IValidator<LoginUserCommand> validator,
    IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            return Result<string>.Failure(errorMessages, ErrorType.Validation);
        }

        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null || !user.VerifyPassword(request.Password))
        {
            return Result<string>.Failure("Invalid email or password.", ErrorType.Validation);
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return Result<string>.Success(token);
    }
}