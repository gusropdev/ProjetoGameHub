using GameHub.Application.Common.Responses;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public record AddStockGameCommand (Guid Id, int Quantity) : IRequest<Result>;