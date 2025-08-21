using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.WebApi.Extensions;

public static class ApiExtension
{
    public static IActionResult ToActionResult(this Result result, ControllerBase controller)
    {
        if (result.IsSuccess)
        {
            return controller.NoContent();
        }
        return HandleFailure(result.ErrorType, result.Errors, controller);
    }
    
    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        if (result.IsSuccess)
        {
            return controller.Ok(result.Data);
        }
        return HandleFailure(result.ErrorType, result.Errors, controller);
    }

    private static IActionResult HandleFailure(ErrorType errorType, List<string> errors, ControllerBase controller)
    {
        return errorType switch
        {
            ErrorType.NotFound => controller.NotFound(errors),       // 404 Not Found
            ErrorType.Conflict => controller.Conflict(errors),       // 409 Conflict
            ErrorType.Validation => controller.BadRequest(errors),   // 400 Bad Request
            _ => controller.BadRequest(errors)                        // Padrão
        };
    }
}