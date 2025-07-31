using HatChao.BuildingBlocks.Application.Response;
using HatChao.Modules.User.Application.DTOs;
using MediatR;

namespace HatChao.Modules.User.Application.Queries;

public record SignInQuery(string Email, string Password) : IRequest<Result<UserInfo>>;
