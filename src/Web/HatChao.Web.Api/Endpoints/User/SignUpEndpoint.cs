using Carter;
using HatChao.Modules.User.Application.Features.SignUp;
using HatChao.Web.Api.DTOs;
using MediatR;

namespace HatChao.Web.Api.Endpoints.User;

public class SignUpEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/sign-up", async (SignUpRequest request, IMediator sender) =>
        {
            var result = await sender.Send(new SignUpCommand(request.Username, request.Email, request.Password));
            return result.Succeeded ? Results.Ok("Register user success") : Results.BadRequest(result.Error);
        }).WithTags(EndpointTag.User);
    }
}
