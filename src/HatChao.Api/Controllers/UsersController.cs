using HatChao.Api.DTOs;
using HatChao.Modules.User.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HatChao.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet("get-users")]
    public IActionResult GetUsers()
    {
        return Ok("Get users");
    }

    [HttpPost("create-user")]
    public IActionResult CreateUser(RegisterUserRequest request)
    {
        var newUser = new AppUser(request.Username, request.Email, request.Password);
        return Ok(newUser);
    }
}
