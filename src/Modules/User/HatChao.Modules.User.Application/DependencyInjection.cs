﻿using Microsoft.Extensions.DependencyInjection;

namespace HatChao.Modules.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUserApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}
