using HatChao.BuildingBlocks.Application.Response;

namespace HatChao.Modules.User.Application.Errors;

public static class AuthError
{
    public static readonly Error UserNotFound = new("UserNotFound", "User not found");
    public static readonly Error PasswordIncorrect = new("PasswordIncorrect", "Password is incorrect");
    public static readonly Error EmailExists = new("EmailExists", "Email has already registered");
}
