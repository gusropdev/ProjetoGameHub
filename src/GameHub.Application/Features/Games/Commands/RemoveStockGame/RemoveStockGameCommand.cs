using MediatR;

namespace GameHub.Application.Features.Games.Commands.RemoveStockGame;

public record RemoveStockGameCommand (Guid Id, int Quantity) : IRequest<bool>;