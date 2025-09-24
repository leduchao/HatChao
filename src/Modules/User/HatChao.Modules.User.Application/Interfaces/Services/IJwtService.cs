namespace HatChao.Modules.User.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateAccessToken(string userId, string username);

    string GenerateRefreshToken();
}
