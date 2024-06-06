using Scrutor;
using Infrastructure.Data;
using Shared.Abstractions;
using Infrastructure.Services;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddScoped<IDateTimeService, DateTimeService>()
            .AddScoped<IHashService, BCryptHashService>()
            .AddScoped<ITokenClaimsService, JwtClaimService>()
            .AddScoped<IUnitOfWork, UnitOfWork>();

    public static IServiceCollection AddMemoryCacheService(this IServiceCollection services)
        => services.AddScoped<ICacheService, MemoryCacheService>();

    public static IServiceCollection AddDistributedCacheService(this IServiceCollection services)
        => services.AddScoped<ICacheService, DistributedCacheService>();

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Assembly scanning and decoration extensions for Microsoft.Extensions.DependencyInjection
        // https://github.com/khellang/Scrutor
        services
               .Scan(scan => scan
                   .FromCallingAssembly()
                   .AddClasses(impl => impl.AssignableTo<IRepository>())
                   .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());

        return services;
    }
}