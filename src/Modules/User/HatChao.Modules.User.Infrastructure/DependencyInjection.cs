using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Infrastructure.Data;
using HatChao.Modules.User.Infrastructure.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HatChao.Modules.User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}
