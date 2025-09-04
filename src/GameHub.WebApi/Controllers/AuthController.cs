using GameHub.Application.Features.Users.Commands.LoginUser;
using GameHub.Application.Features.Users.Commands.RegisterUser;
using GameHub.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController (IMediator mediator): ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess == false)
        {
            return result.ToActionResult(this);
        }
        
        return Ok(new { Token = result.Data });
    }
}