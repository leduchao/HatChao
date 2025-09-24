
using HatChao.Modules.User.Application.Interfaces.Services;

namespace HatChao.Modules.User.Infrastructure.Implements.Services;

public class JwtService : IJwtService
{
    public string GenerateAccessToken(string userId, string username)
    {
        return "access_token";
    }

    public string GenerateRefreshToken()
    {
        return "refresh_token";
    }
}
