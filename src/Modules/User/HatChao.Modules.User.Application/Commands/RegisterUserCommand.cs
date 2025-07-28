using HatChao.Modules.User.Domain.Entities;
using MediatR;

namespace HatChao.Modules.User.Application.Commands;

public record RegisterUserCommand(string Username, string Email, string Password) : IRequest<bool>;
