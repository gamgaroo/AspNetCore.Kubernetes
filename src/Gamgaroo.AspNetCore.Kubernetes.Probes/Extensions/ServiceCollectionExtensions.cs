using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLivenessService<TService>(this IServiceCollection services)
            where TService : class, ILivenessService
        {
            services.AddSingleton<ILivenessService, TService>();

            return services;
        }

        public static IServiceCollection AddReadinessService<TService>(this IServiceCollection services)
            where TService : class, IReadinessService
        {
            services.AddSingleton<IReadinessService, TService>();

            return services;
        }
    }
}