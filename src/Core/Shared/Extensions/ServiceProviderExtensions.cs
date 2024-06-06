using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Abstractions;

namespace Shared.Extensions;

public static class ServiceProviderExtensions
{
    public static TOptions GetOptions<TOptions>(this IServiceProvider serviceProvider) where TOptions : BaseOptions
        => serviceProvider.GetRequiredService<IOptions<TOptions>>().Value;
}