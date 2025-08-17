using Carter;
using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.Errors;
using HatChao.Modules.User.Application.Features.GetBasicInfo;
using HatChao.Modules.User.Application.Features.SignIn;
using HatChao.Modules.User.Application.Features.SignUp;
using HatChao.Web.Api.DTOs;
using MediatR;

namespace HatChao.Web.Api.Endpoints;

public class UserModule : CarterModule
{
    public UserModule() : base("api/user")
    {
        
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-up", async (SignUpRequest request, IMediator sender) =>
        {
            var result = await sender.Send(new SignUpCommand(request.Username, request.Email, request.Password));
            return result.Succeeded ? Results.Ok("Register user success") : Results.BadRequest(result);
        })
        .WithTags(EndpointTag.User)
        .WithName("SignUp");

        app.MapPost("/sign-in", async (SignInRequest request, IMediator sender) =>
        {
            var result = await sender.Send(new SignInQuery(request.Email, request.Password));
            return result.Succeeded ? Results.Ok("Sign in success") : Results.BadRequest(result);
        })
        .WithTags(EndpointTag.User)
        .WithName("SignIn");

        app.MapGet("/basic-info", async (string email, IMediator sender) =>
        {
            var result = await sender.Send(new GetBasicInfoQuery(email));
            if (!result.Succeeded)
            {
                return Results.BadRequest(result);
            }

            return result.Data is not null 
                ? Results.Ok(result) 
                : Results.NotFound(Result.Failure(UserError.UserNotFound));
        })
        .WithTags(EndpointTag.User)
        .WithName("GetBasicInfo");
    }
}
