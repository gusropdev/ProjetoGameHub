using GameHub.Application.Common.Responses;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeactivateGame;

public record DeactivateGameCommand (Guid Id): IRequest<Result>;