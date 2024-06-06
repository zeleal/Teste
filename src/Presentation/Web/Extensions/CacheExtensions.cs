using Infrastructure;
using Shared.Constants;
using Shared.Extensions;
using Shared.AppSettings;

namespace Web.Extensions;

internal static class CacheExtensions
{
    internal static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        var inMemoryOptions = configuration.GetOptions<InMemoryOptions>(AppSettingsKeys.InMemoryOptions);
        if (inMemoryOptions.Cache)
        {
            services.AddMemoryCache().AddMemoryCacheService();
        }
        else
        {
            var connections = configuration.GetOptions<ConnectionStrings>(AppSettingsKeys.ConnectionStrings);

            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "master";
                options.Configuration = connections.Cache;
            }).AddDistributedCacheService();
        }

        return services;
    }
}