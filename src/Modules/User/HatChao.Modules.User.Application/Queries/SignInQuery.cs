using MediatR;

namespace HatChao.Modules.User.Application.Queries;

public record SignInQuery(string Email, string Password) : IRequest<bool>;
