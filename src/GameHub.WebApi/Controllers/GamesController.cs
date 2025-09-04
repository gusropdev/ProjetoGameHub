using GameHub.Application.Features.Games.Commands.ActivateGame;
using GameHub.Application.Features.Games.Commands.CreateGame;
using GameHub.Application.Features.Games.Commands.DeactivateGame;
using GameHub.Application.Features.Games.Commands.DeleteGame;
using GameHub.Application.Features.Games.Commands.UpdateGame;
using GameHub.Application.Features.Games.Queries.GetActiveGames;
using GameHub.Application.Features.Games.Queries.GetAllGames;
using GameHub.Application.Features.Games.Queries.GetGameByAgeRating;
using GameHub.Application.Features.Games.Queries.GetGameById;
using GameHub.Application.Features.Games.Queries.GetInactiveGames;
using GameHub.Domain.Enums;
using GameHub.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize(Roles = "User")]
public class GamesController (IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllGamesQuery {PageNumber = pageNumber, PageSize = pageSize};
        var result = await mediator.Send(query);

        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new GetGameByIdQuery(id);
        var result = await mediator.Send(query);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        
        return Ok(result);
    }
    
    [HttpGet("active")]
    public async Task<IActionResult> GetActiveGamesAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetActiveGamesQuery { PageNumber = pageNumber, PageSize = pageSize};
        var result = await mediator.Send(query);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        
        return Ok(result);
    }
    
    [HttpGet("inactive")]
    public async Task<IActionResult> GetInactiveGamesAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetInactiveGamesQuery { PageNumber = pageNumber, PageSize = pageSize};
        var result = await mediator.Send(query);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        
        return Ok(result);
    }

    [HttpGet("AgeRating/{ageRating}")]
    public async Task<IActionResult> GetByAgeRatingAsync(AgeRating ageRating, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) 
    {
        var query = new GetGameByAgeRatingQuery(ageRating);
        var result = await mediator.Send(query);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        return Ok(result);
    }

    // [HttpGet("Genre/{genre}")]
    // public async Task<IActionResult> GetByGenreAsync(Genre genre, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    // {
    //     var query = new GetGameByGenreQuery(genre);
    //     var result = await mediator.Send(query);
    //     
    //     if (result.IsSuccess == false)
    //     {
    //         return result.ToActionResult(this);
    //     }
    //     
    //     return Ok(result);
    // }

    // [HttpGet("Platform/{platform}")]
    // public async Task<IActionResult> GetByPlatformAsync(Platform platform, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    // {
    //     var query = new GetGameByPlatformQuery(platform);
    //     var result = await mediator.Send(query);
    //     
    //     if (result.IsSuccess == false)
    //     {
    //         return result.ToActionResult(this);
    //     }
    //     
    //     return Ok(result);
    // }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateGameCommand command)
    {
        var result = await mediator.Send(command);
        
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }

        return CreatedAtAction("GetById", new { id = result.Data }, result.Data);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await mediator.Send(new DeleteGameCommand(id));

        return result.ToActionResult(this);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateGameRequest request)
    {
        var command = new UpdateGameCommand(
            id,
            request.Title,
            request.Description,
            request.DailyRentalPrice,
            request.PurchasePrice,
            request.ReleaseDate,
            request.AgeRating,
            request.GenreIds,
            request.PlatformIds
        );

        var result = await mediator.Send(command);

        return result.ToActionResult(this);
    }
    
    [HttpPut("{id:guid}/activate")]
    public async Task<IActionResult> ActivateAsync(Guid id)
    {
        var result = await mediator.Send(new ActivateGameCommand(id));
        return result.ToActionResult(this);
    }
    
    [HttpPut("{id:guid}/deactivate")]
    public async Task<IActionResult> DeactivateAsync(Guid id)
    {
        var result = await mediator.Send(new DeactivateGameCommand(id));
        return result.ToActionResult(this);
    }
}