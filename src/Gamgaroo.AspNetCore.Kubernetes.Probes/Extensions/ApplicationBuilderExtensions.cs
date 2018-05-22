using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;
using Microsoft.AspNetCore.Builder;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private const string DefaultLivenessPath = "/api/alive";
        private const string DefaultReadinessPath = "/api/ready";

        public static IApplicationBuilder UseHttpLivenessEndpoint(this IApplicationBuilder app,
            string path = DefaultLivenessPath)
        {
            app.UseMiddleware<ProbeMiddleware<ILivenessService>>(path);

            return app;
        }

        public static IApplicationBuilder UseHttpReadinessEndpoint(this IApplicationBuilder app,
            string path = DefaultReadinessPath)
        {
            app.UseMiddleware<ProbeMiddleware<IReadinessService>>(path);

            return app;
        }
    }
}