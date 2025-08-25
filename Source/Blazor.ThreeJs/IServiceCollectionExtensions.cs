using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ThreeJs;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddThreeJs(this IServiceCollection services)
    {
        services.AddScoped<THREE>();
        return services;
    }
}
