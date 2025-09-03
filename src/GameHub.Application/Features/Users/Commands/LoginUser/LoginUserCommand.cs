using GameHub.Application.Common.Responses;
using MediatR;

namespace GameHub.Application.Features.Users.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<Result<string>>;