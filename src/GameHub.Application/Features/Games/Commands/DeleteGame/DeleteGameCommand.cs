using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeleteGame;

public record DeleteGameCommand (Guid GameId) : IRequest<bool>;