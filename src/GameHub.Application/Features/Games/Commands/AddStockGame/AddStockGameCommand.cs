using MediatR;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public record AddStockGameCommand (Guid Id, int Quantity) : IRequest<bool>;