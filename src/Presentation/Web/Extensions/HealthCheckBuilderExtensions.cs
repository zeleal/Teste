using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Web.HealthChecks;

namespace Web.Extensions;

public static class HealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddGCInfoCheck(this IHealthChecksBuilder builder)
        => builder.AddCheck<GCInfoHealthCheck>("GCInfo", HealthStatus.Degraded, tags: new[] { "memory" });
}