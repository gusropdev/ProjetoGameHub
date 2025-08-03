using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeactivateGame;

public record DeactivateGameCommand (Guid Id): IRequest<bool>;