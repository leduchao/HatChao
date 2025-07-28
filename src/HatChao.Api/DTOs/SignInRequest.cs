using MediatR;

namespace HatChao.Api.DTOs;

public record SignInRequest(string Email, string Password) : IRequest<bool>;
