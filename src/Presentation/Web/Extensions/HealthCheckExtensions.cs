using Shared.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Web.Extensions;

internal static class HealthCheckExtensions
{
    internal static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
        => app.UseHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            AllowCachingResponses = false,
            ResponseWriter = (context, healthReport) => context.Response.WriteAsync(healthReport.ToJson())
        });
}