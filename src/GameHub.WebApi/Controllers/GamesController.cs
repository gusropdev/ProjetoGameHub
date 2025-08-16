using GameHub.Application.Features.Games.Commands.CreateGame;
using GameHub.Application.Features.Games.Commands.DeleteGame;
using GameHub.Application.Features.Games.Commands.UpdateGame;
using GameHub.Application.Features.Games.Queries.GetAllGames;
using GameHub.Application.Features.Games.Queries.GetGameByAgeRating;
using GameHub.Application.Features.Games.Queries.GetGameByGenre;
using GameHub.Application.Features.Games.Queries.GetGameById;
using GameHub.Application.Features.Games.Queries.GetGameByPlatform;
using GameHub.Domain.Enums;
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
            return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Errors),
                ErrorType.Conflict => Conflict(result.Errors),
                ErrorType.Validation => BadRequest(result.Errors),
                _ => BadRequest(result.Errors)
            };
        }

        return CreatedAtAction("GetById", new { id = result.Value }, result.Value);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var query = new GetAllGamesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetGameById")]
    public async Task<ActionResult> GetByIdAsync(Guid id)
    {
        var query = new GetGameByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("ageRating/{ageRating}")]
    public async Task<ActionResult> GetByAgeRatingAsync(AgeRating ageRating) 
    {
        var query = new GetGameByAgeRatingQuery(ageRating);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("genre/{genre}")]
    public async Task<ActionResult> GetByGenreAsync(Genre genre)
    {
        var query = new GetGameByGenreQuery(genre);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("platform/{platform}")]
    public async Task<ActionResult> GetByPlatformAsync(Platform platform)
    {
        var query = new GetGameByPlatformQuery(platform);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateGameCommand command)
    {
        if(id != command.Id)
        {
            return BadRequest($"Game ID in the URL does not match the Game ID in the command.{id} != {command.Id}");
        }
        var result = await mediator.Send(command);
        
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteGameCommand(id);
        var result = await mediator.Send(command);
        
        if (result.IsSuccess == false)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Errors),
                ErrorType.Conflict => Conflict(result.Errors),
                ErrorType.Validation => BadRequest(result.Errors),
                _ => BadRequest(result.Errors)
            };
        }

        return NoContent();
    }
}