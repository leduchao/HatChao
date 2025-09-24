using System.Reflection;

using Azure.Core;

using HatChao.API.DTOs;
using HatChao.Modules.User.Application.Features.SignIn;
using HatChao.Modules.User.Application.Features.SignUp;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HatChao.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : BaseController
{
    public AuthController(ISender sender) : base(sender) { }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync(SignInRequest request)
    {
        var result = await Sender.Send(new SignInQuery(request.Email, request.Password));
        return HandleResult(result);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUpAsync(SignUpRequest request)
    {
        var result = await Sender.Send(new SignUpCommand(request.Username, request.Email, request.Password));
        return HandleResult(result);
    }
}
