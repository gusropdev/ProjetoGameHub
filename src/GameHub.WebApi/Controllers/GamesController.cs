using GameHub.Application.Features.Games.Commands.CreateGame;
using GameHub.Application.Features.Games.Commands.DeleteGame;
using GameHub.Application.Features.Games.Commands.UpdateGame;
using GameHub.Application.Features.Games.Queries.GetAllGames;
using GameHub.Application.Features.Games.Queries.GetGameByAgeRating;
using GameHub.Application.Features.Games.Queries.GetGameByGenre;
using GameHub.Application.Features.Games.Queries.GetGameById;
using GameHub.Application.Features.Games.Queries.GetGameByPlatform;
using GameHub.Domain.Enums;
using GameHub.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController (IMediator mediator) : ControllerBase
{
    [HttpGet("test")]
    public IActionResult TestEndpoint()
    {
        return Ok("O roteamento para GamesController está funcionando!");
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateGameCommand command)
    {
        var result = await mediator.Send(command);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }

        return CreatedAtAction("GetById", new { id = result.Value }, result.Value);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetAllGamesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetGameById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new GetGameByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("ageRating/{ageRating}")]
    public async Task<IActionResult> GetByAgeRatingAsync(AgeRating ageRating) 
    {
        var query = new GetGameByAgeRatingQuery(ageRating);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetByGenreAsync(Genre genre)
    {
        var query = new GetGameByGenreQuery(genre);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("platform/{platform}")]
    public async Task<IActionResult> GetByPlatformAsync(Platform platform)
    {
        var query = new GetGameByPlatformQuery(platform);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateGameRequest request)
    {
        var command = new UpdateGameCommand(
            id,
            request.Title,
            request.Description,
            request.DailyRentalPrice,
            request.ReleaseDate,
            request.AgeRating,
            request.Genre,
            request.Platform
        );

        var result = await mediator.Send(command);

        return result.ToActionResult(this);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await mediator.Send(new DeleteGameCommand(id));

        return result.ToActionResult(this);
    }
}