using HatChao.BuildingBlocks.Application.Response;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HatChao.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected ISender Sender { get; }

    protected BaseController(ISender sender)
    {
        Sender = sender;
    }

    protected IActionResult HandleResult(Result result)
    {
        return result.Succeeded
            ? Ok(result)
            : result.ErrorType switch
            {
                ErrorType.BadRequest => BadRequest(result.Error),
                ErrorType.Unauthorized => Unauthorized(result.Error),
                ErrorType.Forbidden => Forbid(),
                ErrorType.NotFound => NotFound(result.Error),
                _ => StatusCode(StatusCodes.Status500InternalServerError, result.Error)
            };
    }

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        return result.Succeeded
            ? Ok(result)
            : result.ErrorType switch
            {
                ErrorType.BadRequest => BadRequest(result.Error),
                ErrorType.Unauthorized => Unauthorized(result.Error),
                ErrorType.Forbidden => Forbid(),
                ErrorType.NotFound => NotFound(result.Error),
                _ => StatusCode(StatusCodes.Status500InternalServerError, result.Error)
            };
    }
}
