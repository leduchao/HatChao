using HatChao.Api.DTOs;
using HatChao.Modules.User.Application.Commands;
using HatChao.Modules.User.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HatChao.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IMediator sender) : ControllerBase
{
    private readonly IMediator _sender = sender;

    [HttpGet("get-users")]
    public IActionResult GetUsers()
    {
        return Ok("Get users");
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
    {
        var result = await _sender.Send(new RegisterUserCommand(request.Username, request.Email, request.Password));
        return result.Succeeded ? Ok("Register user success") : BadRequest("Register user fail");
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> RegisterUser(SignInRequest request)
    {
        var result = await _sender.Send(new SignInQuery(request.Email, request.Password));
        return result.Succeeded ? Ok(result) : BadRequest(result);
    }
}
