using Scrutor;
using System.Reflection;
using Shared.Abstractions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    [ExcludeFromCodeCoverage]
    public static class ServicesCollectionExtensions
    {
        private static readonly Assembly[] AssembliesToScan = { Assembly.GetExecutingAssembly() };

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.DisableConstructorMapping(), AssembliesToScan, ServiceLifetime.Singleton);

            services.Scan(scan => scan
                .FromAssemblies(AssembliesToScan)
                .AddClasses(impl => impl.AssignableTo<IAppService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
