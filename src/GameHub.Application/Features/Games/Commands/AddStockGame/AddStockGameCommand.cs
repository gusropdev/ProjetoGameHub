using MediatR;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public record AddStockGameCommand (Guid GameId, int Quantity) : IRequest<bool>;