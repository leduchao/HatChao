using HatChao.Modules.User.Application.Interfaces;
using HatChao.Modules.User.Infrastructure.Data;
using HatChao.Modules.User.Infrastructure.Implements;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace HatChao.Modules.User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
        services.AddScoped<IDbConnection>(p => new SqlConnection(config.GetConnectionString("SqlServer")));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
