using Microsoft.AspNetCore.Builder;

namespace Gamgaroo.AspNetCore.Kubernetes.Urls.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseUrlsMiddleware(this IApplicationBuilder app,
            string serviceName)
        {
            app.UseMiddleware<UrlsMiddleware>(serviceName);

            return app;
        }
    }
}