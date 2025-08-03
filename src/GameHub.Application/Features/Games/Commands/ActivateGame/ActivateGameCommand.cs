using MediatR;

namespace GameHub.Application.Features.Games.Commands.ActivateGame;

public record ActivateGameCommand (Guid Id): IRequest<bool>;