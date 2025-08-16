using Carter;
using HatChao.Modules.User.Application.Features.SignIn;
using HatChao.Web.Api.DTOs;
using MediatR;

namespace HatChao.Web.Api.Endpoints.User;

public class SignInEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/sign-in", async (SignInRequest request, IMediator sender) =>
        {
            var result = await sender.Send(new SignInQuery(request.Email, request.Password));
            return result.Succeeded ? Results.Ok("Sign in success") : Results.BadRequest(result.Error);
        }).WithTags(EndpointTag.User);
    }
}
