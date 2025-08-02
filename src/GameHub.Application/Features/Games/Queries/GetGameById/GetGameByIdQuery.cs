using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public class GetGameByIdQuery : IRequest<GameDto>
{
    public Guid Id { get; set; }
}