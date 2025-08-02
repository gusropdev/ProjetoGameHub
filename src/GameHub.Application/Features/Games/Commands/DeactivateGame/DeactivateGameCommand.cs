using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeactivateGame;

public record DeactivateGameCommand (Guid GameId): IRequest<bool>;