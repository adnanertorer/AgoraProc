using System.Reflection;
using Adoroid.Core.Application.Rules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalMediatR.Extensions;
using FluentValidation;
using MinimalMediatR.Behaviors;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application;

public static class BuyingTypeServiceCollection
{
    public static IServiceCollection AddBuyingTypeServiceCollection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), type: typeof(BaseBusinessRule));
        services.AddMinimalMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type,
    Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
