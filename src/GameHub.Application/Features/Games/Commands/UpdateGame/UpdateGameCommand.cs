using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public record UpdateGameCommand(
    Guid GameId,
    string Title,
    string Description,
    decimal DailyRentalPrice,
    DateTime ReleaseDate,
    AgeRating AgeRating,
    Genre Genre,
    Platform Platform
) : IRequest<bool>;
