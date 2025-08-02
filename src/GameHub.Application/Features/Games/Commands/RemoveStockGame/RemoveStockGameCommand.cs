using MediatR;

namespace GameHub.Application.Features.Games.Commands.RemoveStockGame;

public record RemoveStockGameCommand (Guid GameId, int Quantity) : IRequest<bool>;