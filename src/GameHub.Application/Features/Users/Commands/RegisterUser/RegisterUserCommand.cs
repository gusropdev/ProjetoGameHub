using GameHub.Application.Common.Responses;
using MediatR;

namespace GameHub.Application.Features.Users.Commands.RegisterUser;

public record RegisterUserCommand(string FullName, string Email, string Password, string? PhoneNumber) : IRequest<Result>;