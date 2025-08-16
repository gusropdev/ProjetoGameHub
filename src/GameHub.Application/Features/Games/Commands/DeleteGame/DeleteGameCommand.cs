using GameHub.Application.Common.Responses;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeleteGame;

public record DeleteGameCommand (Guid Id) : IRequest<Result>;