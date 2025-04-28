using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServicesExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
