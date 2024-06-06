using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions;
using Shared.AppSettings;
using Shared.Constants;

namespace Shared;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static IServiceCollection ConfigureAppSettings(this IServiceCollection services)
    {
        services.AddOptions<AuthOptions>(AppSettingsKeys.AuthOptions);
        services.AddOptions<CacheOptions>(AppSettingsKeys.CacheOptions);
        services.AddOptions<ConnectionStrings>(AppSettingsKeys.ConnectionStrings);
        services.AddOptions<InMemoryOptions>(AppSettingsKeys.InMemoryOptions);
        services.AddOptions<JwtOptions>(AppSettingsKeys.JwtOptions);
        return services;
    }

    private static void AddOptions<TOptions>(this IServiceCollection services, string configSectionPath)
        where TOptions : BaseOptions
    {
        services
            .AddOptions<TOptions>()
            .BindConfiguration(configSectionPath, options => options.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}