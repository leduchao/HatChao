using HatChao.Modules.User.Application.Features.GetBasicInfo;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HatChao.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : BaseController
{
    public UsersController(ISender sender) : base(sender) { }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserBasicInfoAsync(string email)
    {
        var result = await Sender.Send(new GetBasicInfoQuery(email));
        return HandleResult(result);
    }
}
